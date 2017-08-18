using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using AppService;
using AppService.Model;
using Dapper_NET20;
using gregn6Lib;

namespace XmWeightForm.SystemManage
{
    public partial class ReportUForm : UserControl
    {
        public ReportUForm()
        {
            InitializeComponent();
        }
        public DataTable QueryDataTable = null;

        private string subTime = string.Empty;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var startTime = this.startTime.Text;
            var endTime = this.endTime.Text;

            var name = txtname.Text.Trim();
            var idNum = txtIdNum.Text.Trim();


            subTime = string.Empty;
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

                    if (!string.IsNullOrEmpty(startTime))
                    {
                        subTime +="至" + tempetime;
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

            GetPsData(whereSql);

        }



      #region 排酸

        private void GetPsData(string wheresql)
        {
            if (string.IsNullOrEmpty(wheresql))
            {
                var dtnow = DateTime.Now.ToString("yyyyMMdd");
                int dtint = int.Parse(dtnow);
                wheresql = " and b.yearNum=" + dtint;
            }

            try
            {
                //var batchlist = new List<BatchInput>();
                //var weightList = new List<WeighingsRaw>();
                //var animalList = new List<AnimalTypes>();
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = @"select 1 Sort,b.batchId,b.hostName,b.PIN,pr.hookId,pr.grossWeight InWeights,pr.weighingTime InTime,po.grossWeight OutWeights ,po.weighingTime OutTime
                                        from Batches b join Weighings w on b.batchId=w.batchId join PreDeAcid pr on w.hookId=pr.hookId and w.attachTime=pr.attachTime
                                        left join PostDeAcid po on w.hookId=po.hookId and w.attachTime=po.attachTime
                                        where b.flag=@flag and 1=1";
                    batchsql += wheresql + " order by pr.weighingTime";
                    //batchlist = db.Query<BatchInput>(batchsql, new { flag = true }).ToList();
                    var ds = db.ExecuteDataSet(batchsql, new { flag = true }, null, null, null);
                    if (ds.Tables.Count == 1)
                    {


                       if (ds.Tables[0].Rows.Count == 0)
                       {
                           MessageBox.Show("未查询到数据");
                           return;

                       }
                       QueryDataTable = ds.Tables[0];
                    }

                }


                if (QueryDataTable != null || QueryDataTable.Rows.Count > 0)
                {
                    gridBatch.DataSource = QueryDataTable;
                }
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

        private void ReportUForm_Load(object sender, EventArgs e)
        {
            gridBatch.AutoGenerateColumns = false;

            var reportfile = Application.StartupPath + @"\report\psreport.grf";
            Report.LoadFromFile(reportfile);
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(report_FetchRecord);

            field1 = Report.FieldByName("Sort");
            field2 = Report.FieldByName("Name");
            field3 = Report.FieldByName("hookId");
            field4 = Report.FieldByName("InWeights");
            field5 = Report.FieldByName("InTime");
            field6 = Report.FieldByName("OutWeights");
            field7 = Report.FieldByName("OutTime");
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
                title.AsStaticBox.Text = "统计时间:" + subTime;
                int tempsort = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Report.DetailGrid.Recordset.Append();
                    field1.Value = tempsort;
                    field2.Value = dt.Rows[i][2].ToString() + "-" + dt.Rows[i][3].ToString();
                    field3.Value = dt.Rows[i][4].ToString();
                    field4.Value = dt.Rows[i][5].ToString();
                    field5.Value = dt.Rows[i][6].ToString();
                    field6.Value = dt.Rows[i][7].ToString();
                    field7.Value = dt.Rows[i][8].ToString();
                    Report.DetailGrid.Recordset.Post();
                    tempsort++;
                }


            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

        }
        #endregion

      #endregion

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            if (QueryDataTable == null || QueryDataTable.Rows.Count == 0)
            {
                MessageBox.Show("未查询到数据");
                return;

            }

            Report.PrintPreview(true);
        }

    }
}
