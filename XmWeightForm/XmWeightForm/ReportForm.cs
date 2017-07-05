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
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var startTime = this.startTime.Text;
            var endTime = this.endTime.Text;

            var name = txtname.Text.Trim();
            var idNum = txtIdNum.Text.Trim();

            var whereSql = string.Empty;
            if (!string.IsNullOrEmpty(name))
            {
                whereSql += " and hostName like '%" + name + "%'";
            }
            if (!string.IsNullOrEmpty(idNum))
            {
                whereSql += " and PIN like '%" + idNum + "%'";
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                if (ValidaterHelper.IsStringDate(startTime))
                {
                    var tempStime = DateTime.Parse(startTime).ToString("yyyyMMdd");
                    int tempStimeInt = int.Parse(tempStime);
                    whereSql += " and yearNum >=" + tempStimeInt;
                }

            }
            if (!string.IsNullOrEmpty(endTime))
            {
                if (ValidaterHelper.IsStringDate(endTime))
                {
                    var tempetime = DateTime.Parse(endTime).ToString("yyyyMMdd");
                    int tempetimeInt = int.Parse(tempetime);
                    whereSql += " and yearNum <=" + tempetimeInt;
                }

            }

            QueryDataTable = GetData(whereSql);
            if (QueryDataTable.Rows.Count == 0)
            {
                MessageBox.Show("未查询到数据");
                return;

            }

            var tempDt = QueryDataTable.Copy();

            tempDt.Columns.Remove("Sort");
            //string[] bottomStr = { "操作人员：Ryan", "打印日期：" + DateTime.Now.ToShortDateString(), "审核人员：", "财务人员：" };
            string[] bottomStr = { "打印日期：" + DateTime.Now.ToShortDateString() };
            string[] header = { "姓名", "身份证", "品名", "数量", "重量", "单价", "金额"};
            DataReprot dr = new DataReprot("屠宰核算统计报表", tempDt, header, bottomStr);
            PrintPreviewDialog p = dr.PrintReport();

            this.groupReport.Controls.Add(p);
            p.Show();
            groupReport.Width += 1;
            this.Refresh();
            tempDt = null;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="wheresql"></param>
        /// <returns></returns>
        private DataTable GetData(string wheresql)
        {
            if (string.IsNullOrEmpty(wheresql))
            {
                var dtnow = DateTime.Now.ToString("yyyyMMdd");
                int dtint = int.Parse(dtnow);
                wheresql = " and yearNum=" + dtint;
            }

            var dt = new DataTable("WeightReport");
            dt.Columns.Add("Sort", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("IdNum", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("ProductNum", typeof(int));
            dt.Columns.Add("Weights", typeof(decimal));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("TotalPrice", typeof(decimal));
            //dt.Columns.Add("WeightTime", typeof(string));
            try
            {
                var batchlist = new List<BatchInput>();
                var weightList = new List<WeighingsRaw>();
                var animalList = new List<AnimalTypes>();
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = "select * from Batches where flag=@flag and 1=1";
                    batchsql += wheresql;
                    batchlist = db.Query<BatchInput>(batchsql, new { flag = true }).ToList();
                    if (batchlist.Any())
                    {
                        var animalType = batchlist.Select(s => s.animalTypeId).Distinct().ToArray();
                        animalList = db.Query<AnimalTypes>("select * from AnimalTypes where animalTypeId in @ids",
                                new { ids = animalType }).ToList();


                        var bids = batchlist.Select(s => s.batchId).ToArray();
                        weightList =
                            db.Query<WeighingsRaw>("select * from WeighingsRaw where batchId in @ids", new { ids = bids })
                                .ToList();

                    }
                }


                if (batchlist.Any() && weightList.Any())
                {
                    int count = 1;
                    foreach (var bItem in batchlist)
                    {
                        var num = weightList.Where(s => s.batchId == bItem.batchId).Sum(s => s.hooksCount);
                        var grossweight = weightList.Where(s => s.batchId == bItem.batchId).Sum(s => s.grossWeights);
                        var price = animalList.Where(s => s.animalTypeId == bItem.animalTypeId).Select(s => s.price).First();
                        var row = dt.NewRow();
                        row["Sort"] = count;
                        row["Name"] = bItem.hostName;
                        row["IdNum"] = bItem.PIN;
                        row["ProductName"] = bItem.animalTypeName;
                        row["ProductNum"] = num;
                        row["Weights"] = grossweight;
                        row["Price"] = price;
                        row["TotalPrice"] = grossweight * price;
                        //if (bItem.weighingBeginTime != null && bItem.weighingFinishedTime != null)
                        //{
                        //    row["WeightTime"] = bItem.weighingBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "至" + bItem.weighingFinishedTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        //}

                        dt.Rows.Add(row);

                        count++;
                    }
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            return dt;
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


            string[] headers = { "序号", "姓名", "身份证", "品名", "数量", "重量", "单价", "金额" };
            string fileName = "屠宰统计";
            string[] colNames = { "Sort", "Name", "IdNum", "ProductName", "ProductNum", "Weights", "Price",
                                    "TotalPrice"};


            var stream = new MemoryStream();
            stream = WorkBookTemplates.WorkBookTemplateDetailInfo(QueryDataTable, fileName, headers, colNames);

            FileStream file = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            file.Write(bytes, 0, bytes.Length);
            file.Close();
            stream.Close();

        }
    }
}
