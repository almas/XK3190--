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
                }

            }
            if (!string.IsNullOrEmpty(endTime))
            {
                if (ValidaterHelper.IsStringDate(endTime))
                {
                    var tempetime = DateTime.Parse(endTime).ToString("yyyyMMdd");
                    int tempetimeInt = int.Parse(tempetime);
                    whereSql += " and b.yearNum <=" + tempetimeInt;
                }

            }
           ShowTTReport(whereSql);
            //GetTtReportNew(whereSql);
        }

        private int _CurrentPageIndex = 0;
        private int _CurrentRowsIndex = 0;
        private int _MaxRowsCount = 20;
        private void GetTtReportNew(string wheresql)
        {
            QueryDataTable = GetTTData(wheresql);
            if (QueryDataTable.Rows.Count == 0 ||QueryDataTable==null)
            {
                MessageBox.Show("未查询到数据");
                return;

            }

            PrintPreviewDialog p = new PrintPreviewDialog();
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += new PrintPageEventHandler(this.DrawWeightReport);
            printDoc.BeginPrint += BeginPrint;
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Custum", 600, 420);
            //this.printDocument1.PrintPage += new PrintPageEventHandler(this.MyPrintDocument_PrintPage2);
            //将写好的格式给打印预览控件以便预览
            p.Document = printDoc;

            p.ShowIcon = false;
            //p.PrintPreviewControl.Zoom = 1.0;
            p.TopLevel = false;
            this.groupReport.Controls.Clear();
            this.groupReport.Controls.Add(p);
            p.Show();
        }

        /// <summary>
        /// 酮体
        /// </summary>
        /// <param name="wheresql"></param>
        private void ShowTTReport(string wheresql)
        {
            var tempDt = GetTTData(wheresql);
            if (tempDt == null || tempDt.Rows.Count == 0)
            {
                MessageBox.Show("未查询到数据");
                return;

            }

             QueryDataTable= new DataTable("report");
            // QueryDataTable.Columns.Add("Sort");
             QueryDataTable.Columns.Add("IdNum");
             QueryDataTable.Columns.Add("productName");
             QueryDataTable.Columns.Add("Weights");
             QueryDataTable.Columns.Add("hookWeights");
             QueryDataTable.Columns.Add("JWeight");
             QueryDataTable.Columns.Add("ProductNum");
             QueryDataTable.Columns.Add("ProductPrice");
             QueryDataTable.Columns.Add("totalPrice");

             int rowCount = tempDt.Rows.Count;
             var rows = tempDt.Rows;
           // int sort = 0;
            for (int i = 0; i < rowCount; i++)
            {
               //  sort += 1;
                string idNum = rows[i]["Name"].ToString() + "-" + rows[i]["IdNum"].ToString();
                string productName = rows[i]["productName"].ToString();
                string Weights = rows[i]["Weights"].ToString();
                string hookWeights = rows[i]["hookWeights"].ToString();
                string JWeight = rows[i]["JWeight"].ToString();
                string ProductNum = rows[i]["ProductNum"].ToString();
                string ProductPrice = rows[i]["ProductPrice"].ToString();
                string totalPrice = "";
                try
                {
                    decimal decimalJweight = decimal.Parse(JWeight);
                    decimal decimalPrice = decimal.Parse(ProductPrice);

                    totalPrice = (decimalJweight * decimalPrice).ToString();
                }
                catch
                {

                }

                DataRow dr = QueryDataTable.NewRow();
               // dr["Sort"] = sort;
                dr["IdNum"] = idNum;
                dr["productName"] = productName;
                dr["Weights"] = Weights;
                dr["hookWeights"] = hookWeights;
                dr["JWeight"] = JWeight;
                dr["ProductNum"] = ProductNum;
                dr["ProductPrice"] = ProductPrice;
                dr["totalPrice"] = totalPrice;
                QueryDataTable.Rows.Add(dr);
            }

            //DataTable reportDt = QueryDataTable.Copy();//复制表结构和数据
            //reportDt.Columns.Remove("Sort");

            string[] bottomStr = { "打印日期：" + DateTime.Now.ToShortDateString() };
            //, "单价", "金额", "称重起止时间"
            string[] header = {"身份证", "品名", "毛重", "皮重", "净重", "数量","单价","金额" };
            DataReprot report = new DataReprot("酮体核算统计报表", QueryDataTable, header, bottomStr);
            PrintPreviewDialog p = report.PrintReport();
            this.groupReport.Controls.Clear();
            this.groupReport.Controls.Add(p);
            p.Show();
           // groupReport.Width += 1;
            this.Refresh();
            //tempDt = null;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="wheresql"></param>
        /// <returns></returns>
        private DataTable GetTTData(string wheresql)
        {
            if (string.IsNullOrEmpty(wheresql))
            {
                var dtnow = DateTime.Now.ToString("yyyyMMdd");
                int dtint = int.Parse(dtnow);
                wheresql = " and b.yearNum=" + dtint;
            }

            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    string batchsql = @"select b.hostName Name,b.PIN IdNum,b.animalTypeName ProductName,
                                        w.grossWeights Weights,w.hookWeights,(w.grossWeights-w.hookWeights)as JWeight,w.hooksCount ProductNum,w.ProductPrice from Batches b
                                        join  WeighingsRaw w on b.batchId=w.batchId
                                        where b.flag=@flag and 1=1";
                    batchsql += wheresql;
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

        private void DrawWeightReport(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.HasMorePages = true;
                //绘制表头
                /*如果需要改变自己 可以在new Font(new FontFamily("黑体"),11）中的“黑体”改成自己要的字体就行了，黑体 后面的数字代表字体的大小
             System.Drawing.Brushes.Blue , 170, 10 中的 System.Drawing.Brushes.Blue 为颜色，后面的为输出的位置 */
            e.Graphics.DrawString("酮体核算统计", new Font(new FontFamily("黑体"), 11), System.Drawing.Brushes.Black, 170, 10);
            e.Graphics.DrawString("供货商:河南科技学院", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Blue, 10, 12);
            //信息的名称
            e.Graphics.DrawLine(Pens.Black, 8, 30, 480, 30);
            e.Graphics.DrawString("序号", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 9, 35);
            e.Graphics.DrawString("身份证", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black,40, 35);
            e.Graphics.DrawString("品名", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 120, 35);
            e.Graphics.DrawString("毛重", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 170, 35);
            e.Graphics.DrawString("皮重", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 220, 35);
            e.Graphics.DrawString("净重", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 270, 35);
            e.Graphics.DrawString("数量", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 320, 35);
            e.Graphics.DrawString("单价", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 350, 35);
            e.Graphics.DrawString("总价", new Font(new FontFamily("黑体"), 8), System.Drawing.Brushes.Black, 400, 35);
            e.Graphics.DrawLine(Pens.Black, 8, 50, 480, 50);
                var dt = QueryDataTable;
                if (dt.Rows.Count > 0)
                {
                    int rowCount = dt.Rows.Count;
                    var rows = dt.Rows;

                    int rowHeight = 35;
                    int lineHeight = 50;
                    int sort = 0;
                    for (int i = 0; i < rowCount; i++)
                    {
                        sort += 1;
                        string sortNum = sort.ToString();
                        string idNum=rows[i]["Name"].ToString()+"-"+rows[i]["IdNum"].ToString();
                        string productName = rows[i]["productName"].ToString();
                        string Weights = rows[i]["Weights"].ToString();
                        string hookWeights = rows[i]["hookWeights"].ToString();
                        string JWeight = rows[i]["JWeight"].ToString();
                        string ProductNum = rows[i]["ProductNum"].ToString();
                        string ProductPrice = rows[i]["ProductPrice"].ToString();
                        string totalPrice = "";
                        try
                        {
                            decimal decimalJweight = decimal.Parse(JWeight);
                            decimal decimalPrice = decimal.Parse(ProductPrice);

                            totalPrice = (decimalJweight * decimalPrice).ToString();
                        }
                        catch
                        {

                        }
                        rowHeight += 20;
                        lineHeight += 20;
                        e.Graphics.DrawString(sortNum, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 9, rowHeight);
                        e.Graphics.DrawString(idNum, new Font(new FontFamily("黑体"), 5), System.Drawing.Brushes.Black, 30, rowHeight);
                        e.Graphics.DrawString(productName, new Font(new FontFamily("黑体"), 5), System.Drawing.Brushes.Black, 120, rowHeight);
                        e.Graphics.DrawString(Weights, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 170, rowHeight);
                        e.Graphics.DrawString(hookWeights, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 220, rowHeight);
                        e.Graphics.DrawString(JWeight, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 270, rowHeight);
                        e.Graphics.DrawString(ProductNum, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 330, rowHeight);
                        e.Graphics.DrawString(ProductPrice, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 350, rowHeight);
                        e.Graphics.DrawString(totalPrice, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, 400, rowHeight);
                        e.Graphics.DrawLine(Pens.Black, 6, lineHeight, 480, lineHeight);
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }

         private void BeginPrint(object sender, PrintEventArgs e)
        {
            _CurrentPageIndex = 0;
            _CurrentRowsIndex = 0;
            e.Cancel = false;
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
    }
}
