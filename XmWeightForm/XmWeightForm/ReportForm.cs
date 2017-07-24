using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppService;
using AppService.Model;
using Dapper_NET20;
using DevComponents.DotNetBar;
using System.Drawing.Printing;
using gregn6Lib;

namespace XmWeightForm
{
    public partial class ReportForm : Office2007Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        public DataTable QueryDataTable = null;
        private string subTime = string.Empty;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            subTime = string.Empty;
            var startTime = this.startTime.Text;
            var endTime = this.endTime.Text;

            var name = txtname.Text.Trim();
            var idNum = txtIdNum.Text.Trim();

            var whereSql = string.Empty;

            if (!string.IsNullOrEmpty(name))
            {
                whereSql += " and b.hostName like '%" + name + "%'";
            }
            if (!string.IsNullOrEmpty(idNum))
            {
                whereSql += " and b.PIN like '%" + idNum + "%'";
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                if (ValidaterHelper.IsStringDate(startTime))
                {
                    var tempStime = DateTime.Parse(startTime).ToString("yyyyMMdd");
                    int tempStimeInt = int.Parse(tempStime);
                    whereSql += " and b.yearNum >=" + tempStimeInt;

                    subTime = tempStime;
                }

            }
            if (!string.IsNullOrEmpty(endTime))
            {
                if (ValidaterHelper.IsStringDate(endTime))
                {
                    var tempetime = DateTime.Parse(endTime).ToString("yyyyMMdd");
                    int tempetimeInt = int.Parse(tempetime);
                    whereSql += " and b.yearNum <=" + tempetimeInt;

                    if (string.IsNullOrEmpty(startTime))
                    {
                        subTime = "至" + tempetime;
                    }
                    else
                    {
                        subTime = tempetime;
                    }
                }

            }

            if (string.IsNullOrEmpty(subTime))
            {
                subTime = DateTime.Now.ToString("yyyyMMdd");
                
                var dtnow = DateTime.Now.ToString("yyyyMMdd");
                int dtint = int.Parse(dtnow);
                whereSql += " and b.yearNum=" + dtint;
            }

            LoadGridData(whereSql);
            //QueryDataTable = GetGridData(whereSql);
            //if (QueryDataTable != null && QueryDataTable.Rows.Count > 0)
            //{
            //    Report.PrintPreview(true);
            //}
            //else
            //{
            //    MessageBox.Show("未查询到数据");
            //}
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (QueryDataTable == null)
            {
                MessageBox.Show("请先查询数据");
                return;

            }
            if (QueryDataTable.Rows.Count == 0)
            {
                MessageBox.Show("未查询到数据");
                return;
            }

            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "excel(*.xls)|*.xls";
            // f.DefaultExt = "xml";
            //获取或设置一个值，该值指示如果用户省略扩展名，文件对话框是否自动在文件名中添加扩展名。（可以不设置）
            f.AddExtension = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                SaveAsExcel(f.FileName);
            }
        }

        private void SaveAsExcel(string filePath)
        {

            string[] headers = { "身份证", "品名", "毛重", "皮重", "净重", "数量", "单价", "金额" };
            string fileName = "酮体称重统计";
            string[] colNames = { "IdNum", "productName", "Weights", "hookWeights", "JWeight", "ProductNum", "ProductPrice", "totalPrice" };

            var stream = new MemoryStream();
            stream = WorkBookTemplates.WorkBookTemplateDetailInfo(QueryDataTable, fileName, headers, colNames);

            FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            file.Write(bytes, 0, bytes.Length);
            file.Close();
            stream.Close();

        }


        private void LoadGridData(string wheresql)
        {
            try
            {
                int totalCount = 0;
                var batchlist = new List<BatchReport>();
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = @"select b.batchId,b.hostName,b.PIN,b.weighingBeginTime from Batches b where b.flag=@flag and 1=1";
                    batchsql += wheresql;
                    batchlist = db.Query<BatchReport>(batchsql, new { flag = true }).ToList();

                    if (batchlist.Any())
                    {
                        foreach (var batch in batchlist)
                        {
                            string sql = @"SELECT SUM(hooksCount) FROM WeighingsRaw WHERE batchId=@batchId";
                            var sheepCount= db.Query<int?>(sql, new { batchId = batch.batchId }).FirstOrDefault();
                            if (sheepCount != null)
                            {
                                batch.Count = (int)sheepCount;
                                totalCount += batch.Count;
                            }

                        }
                    }
                }



                if (batchlist.Count == 0)
                {
                    MessageBox.Show("未查询到数据");
                }
                lblCount.Text = "总计：" + totalCount + "只";
                gridBatch.DataSource = batchlist;

               
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }



        #region grid++ report
        protected GridppReport Report = new GridppReport();
        IGRField field1;
        IGRField field2;
        IGRField field3;
        IGRField field4;
        IGRField field5;
        IGRField field6;
        IGRField field7;
        IGRField field8;
        IGRField field9;
        IGRField field10;
        private void ReportForm_Load(object sender, EventArgs e)
        {
            gridBatch.AutoGenerateColumns = false;

            var reportfile = Application.StartupPath + @"\report\report.grf";
            Report.LoadFromFile(reportfile);
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

            field1 = Report.FieldByName("Sort");
            field2 = Report.FieldByName("Name");
            field3 = Report.FieldByName("ProductName");
            field4 = Report.FieldByName("Weights");
            field5 = Report.FieldByName("hookWeights");
            field6 = Report.FieldByName("JWeight");
            field7 = Report.FieldByName("ProductNum");
            field8 = Report.FieldByName("ProductPrice");
            field9 = Report.FieldByName("TotalPrice");
            field10 = Report.FieldByName("weighingTime");
        }
        private DataTable GetReportData(string wheresql)
        {
            
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = @"select ROW_NUMBER() OVER(ORDER BY w.batchId desc) as Sort,(b.hostName+'-'+b.PIN) Name,b.animalTypeName ProductName,
                             w.grossWeights Weights,w.hookWeights,(w.grossWeights-w.hookWeights)as JWeight,w.hooksCount ProductNum,w.ProductPrice,(w.grossWeights-w.hookWeights)*w.ProductPrice TotalPrice,w.weighingTime from Batches b join  WeighingsRaw w on b.batchId=w.batchId where b.flag=@flag and 1=1";
                    batchsql += wheresql;
                    batchsql += " order by weighingTime";
                    //batchlist = db.Query<BatchInput>(batchsql, new { flag = true }).ToList();
                    var ds = db.ExecuteDataSet(batchsql, new { flag = true }, null, null, null);
                    if (ds.Tables.Count == 1)
                    {
                        return ds.Tables[0];
                    }
                }

            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            return null;
        }

        private DataTable GetReportData2(string batchId)
        {

            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = @"select ROW_NUMBER() OVER(ORDER BY w.batchId desc) as Sort,(b.hostName+'-'+b.PIN) Name,w.productName ProductName,
                             w.grossWeights Weights,w.hookWeights,(w.grossWeights-w.hookWeights)as JWeight,w.hooksCount ProductNum,w.ProductPrice,(w.grossWeights-w.hookWeights)*w.ProductPrice TotalPrice,w.weighingTime from Batches b join  WeighingsRaw w on b.batchId=w.batchId where b.batchId=@batchId";
                  
                    //batchlist = db.Query<BatchInput>(batchsql, new { flag = true }).ToList();
                    var ds = db.ExecuteDataSet(batchsql, new { batchId = batchId }, null, null, null);
                    if (ds.Tables.Count == 1)
                    {
                        return ds.Tables[0];
                    }
                }

            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            return null;
        }
        private void report_FetchRecord()
        {
            if (QueryDataTable == null || QueryDataTable.Rows.Count == 0)
            {
                return;
            }
            try
            {
                var dt = QueryDataTable;
                var title = Report.ControlByName("SubTitleBox");
                title.AsStaticBox.Text ="统计时间:" +subTime;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Report.DetailGrid.Recordset.Append();
                    field1.Value = dt.Rows[i][0].ToString();
                    field2.Value = dt.Rows[i][1].ToString();
                    field3.Value = dt.Rows[i][2].ToString();
                    field4.Value = dt.Rows[i][3].ToString();
                    field5.Value = dt.Rows[i][4].ToString();
                    field6.Value = dt.Rows[i][5].ToString();
                    field7.Value = dt.Rows[i][6].ToString();
                    field8.Value = dt.Rows[i][7].ToString();
                    field9.Value = dt.Rows[i][8].ToString();
                    field10.Value = dt.Rows[i][9].ToString();
                    Report.DetailGrid.Recordset.Post();
                }


            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

        }
        #endregion

        private void gridBatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    var cell = this.gridBatch.Rows[e.RowIndex].Cells[0];
                    if (cell.Value != null)
                    {
                        string batchId = cell.Value.ToString();
                        QueryDataTable=GetReportData2(batchId);
                        if (QueryDataTable != null && QueryDataTable.Rows.Count > 0)
                        {
                           Report.PrintPreview(true);
                        }
                        else
                        {
                            MessageBox.Show("未查询到数据");
                        }
                    }
                 
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
 
        }

    }
}
