
using System;
using System.Collections.Generic;
using System.Text;
//
using System.Drawing;
using System.Drawing.Printing;
using System.Data;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace XmWeightForm
{
    ///<summary>
    /// 数据报表统计
    /// ryan-2010/9/19
    ///</summary>
    public class DataReprot
    {
        #region//property
        //image size
        int _Width = 600;
        int _Height = 420;
        //pager
        private int _TopMargin = 50;
        private int _LeftMargin = 60;
        private int _RightMargin = 50;
        private int _BottomMargin = 60;
        private Font _TitleFont = new Font("宋体", 18, FontStyle.Bold);
        private Font _ColumnsHeaderFont = new Font("宋体", 10, FontStyle.Bold);
        private Font _ContentFont = new Font("宋体", 9, FontStyle.Regular);
        SolidBrush brush = new SolidBrush(System.Drawing.Color.Black);
        Pen pen = new Pen(new SolidBrush(System.Drawing.Color.Black));
        int _RowHeight = 30;
        int _CurrentPageIndex;
        int _PageCount;
        int _RowsCount;
        int _CurrentRowsIndex;
        int _MaxRowsCount = 35;
        Point _CurrentPoint;
        DataTable _DT;
        string _Title;
        string _ImgTitle;
        string[] _ColumnsHeader;
        string[] _BottomStr;
        #endregion

        #region//DataReprot()
        public DataReprot(string title,  DataTable dataTable, string[] columnsHeader, string[] bottomStr)
        {
            _Title = title;
            _DT = Sort(dataTable);
            //_ImgTitle = imgTitle;
            _ColumnsHeader = columnsHeader;
            _RowsCount = dataTable.Rows.Count;
            _BottomStr = bottomStr;
            _CurrentPageIndex = 0;
            _CurrentRowsIndex = 0;
            //pagecount
            if ((dataTable.Rows.Count + 20) % _MaxRowsCount == 0)
                _PageCount = (dataTable.Rows.Count + 20) / _MaxRowsCount;
            else
                _PageCount = ((dataTable.Rows.Count + 20) / _MaxRowsCount) + 1;
        }
        #endregion

        #region//保存为excl

        #endregion

        #region//对dt排序
        public DataTable Sort(DataTable dataTable)
        {
            string orderName = dataTable.Columns[1].ColumnName;
            DataView dv = dataTable.DefaultView;
            dv.Sort = orderName + " DESC";
            dataTable = dv.ToTable();
            return dataTable;
        }
        #endregion

        #region//打印报表
        public PrintPreviewDialog PrintReport()
        {

            //
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += PrintPage;
            printDoc.BeginPrint += BeginPrint;
            //PaperSize ps = new PaperSize("CustomPaperSize", 900, 800);
            //printDoc.DefaultPageSettings.PaperSize = ps;

            PrintPreviewDialog pPreviewDialog = new PrintPreviewDialog();
            pPreviewDialog.Document = printDoc;
            pPreviewDialog.ShowIcon = false;
            pPreviewDialog.PrintPreviewControl.Zoom = 1.0;
            pPreviewDialog.TopLevel = false;
           
            SetPrintPreviewDialog(pPreviewDialog);
            return pPreviewDialog;
        }
        #endregion


        #region//绘制图像的基本数据计算方法
        ///<summary>
        /// 数据格式化
        ///</summary>
        private DataTable DataFormat(DataTable dataTable)
        {
            if (dataTable == null)
                return dataTable;
            //把大于等于10的行合并，
            if (dataTable.Rows.Count <= 10)
                return dataTable;
            //new Table
            DataTable dataTableNew = dataTable.Copy();
            dataTableNew.Rows.Clear();
            for (int i = 0; i < 8; i++)
            {
                DataRow dataRow = dataTableNew.NewRow();
                dataRow[0] = dataTable.Rows[i][0];
                dataRow[1] = dataTable.Rows[i][1];
                dataTableNew.Rows.Add(dataRow);
            }
            DataRow dr = dataTableNew.NewRow();
            dr[0] = "其它";
            double allValue = 0;
            for (int i = 9; i < dataTable.Rows.Count; i++)
            {
                allValue += Convert.ToDouble(dataTable.Rows[i][1]);
            }
            dr[1] = allValue;
            dataTableNew.Rows.Add(dr);
            return dataTableNew;
        }
        ///<summary>
        /// 计算数值总和
        ///</summary>
        private static double Sum(DataTable dataTable)
        {
            double t = 0;
            foreach (DataRow dr in dataTable.Rows)
            {
                t += Convert.ToDouble(dr[1]);
            }
            return t;
        }
        ///<summary>
        /// 计算各项比例
        ///</summary>
        //private static double[] GetItemRate(DataTable dataTable)
        //{
        //    double sum = Sum(dataTable);
        //    double[] ItemRate = newdouble[dataTable.Rows.Count];
        //    for (int i = 0; i < dataTable.Rows.Count; i++)
        //    {
        //        ItemRate[i] = Convert.ToDouble(dataTable.Rows[i][1]) / sum;
        //    }
        //    return ItemRate;
        //}
        ///<summary>
        /// 根据比例，计算各项角度值
        ///</summary>
        //private static int[] GetItemAngle(double[] ItemRate)
        //{
        //    int[] ItemAngel = newint[ItemRate.Length];
        //    for (int i = 0; i < ItemRate.Length; i++)
        //    {
        //        double t = 360 * ItemRate[i];
        //        ItemAngel[i] = Convert.ToInt32(t);
        //    }
        //    return ItemAngel;
        //}
        #endregion

        #region// 随即扇形区域颜色，绘制区域框，
        ///<summary>
        /// 生成随机颜色
        ///</summary>
        ///<returns></returns>
        private static Color GetRandomColor(int seed)
        {
            Random random = new Random(seed);
            int r = 0;
            int g = 0;
            int b = 0;
            r = random.Next(0, 230);
            g = random.Next(0, 230);
            b = random.Next(0, 235);
            Color randomcolor = Color.FromArgb(r, g, b);
            return randomcolor;
        }
        ///<summary>
        /// 绘制区域框、阴影
        ///</summary>
        private static Bitmap DrawRectangle(Bitmap image, Rectangle rect)
        {
            Bitmap Image = image;
            Graphics g = Graphics.FromImage(Image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                Rectangle rn = new Rectangle(rect.X + 3, rect.Y + 3, rect.Width, rect.Height);
                SolidBrush brush1 = new SolidBrush(Color.FromArgb(233, 234, 249));
                SolidBrush brush2 = new SolidBrush(Color.FromArgb(221, 213, 215));
                //
                g.FillRectangle(brush2, rn);
                g.FillRectangle(brush1, rect);
                return Image;
            }
            finally
            {
                g.Dispose();
            }
        }
        #endregion

        #region//绘制图例框、图列信息，绘制扇形
        ///<summary>
        /// 绘制图例信息
        ///</summary>
        private static Bitmap DrawDes(Bitmap image, Rectangle rect, Color c, string DesStr, Font f, int i)
        {
            Bitmap Image = image;
            Graphics g = Graphics.FromImage(Image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            try
            {
                SolidBrush brush = new SolidBrush(c);
                Rectangle R = new Rectangle(rect.X, rect.Y + 25 * i, rect.Width, rect.Height);
                Point p = new Point(rect.X + 12, rect.Y + 25 * i);
                //❀颜色矩形框
                g.FillRectangle(brush, R);
                //文字说明
                g.DrawString(DesStr, f, new SolidBrush(Color.Black), p);
                return Image;
            }
            finally
            {
                g.Dispose();
            }
        }
        //绘制扇形
        private static Bitmap DrawPie(Bitmap image, Rectangle rect, Color c, int Angle1, int Angle2)
        {
            Bitmap Image = image;
            Graphics g = Graphics.FromImage(Image);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                SolidBrush brush = new SolidBrush(c);
                Rectangle R = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
                g.FillPie(brush, R, Angle1, Angle2);
                return Image;
            }
            finally
            {
                g.Dispose();
            }
        }
        #endregion

        #region//绘制基本图形
        ///<summary>
        /// 生成图片，统一设置图片大小、背景色,图片布局，及标题
        ///</summary>
        ///<returns>图片</returns>
        private Bitmap GenerateImage(string Title)
        {
            Bitmap image = new Bitmap(_Width, _Height);
            Graphics g = Graphics.FromImage(image);
            //标题
            Point PTitle = new Point(30, 20);
            Font f1 = new Font("黑体", 12, FontStyle.Bold);
            //线
            int len = (int)g.MeasureString(Title, f1).Width;
            Point PLine1 = new Point(20, 40);
            Point PLine2 = new Point(20 + len + 20, 40);
            Pen pen = new Pen(new SolidBrush(Color.FromArgb(8, 34, 231)), 1.5f);
            //主区域,主区域图形
            Rectangle RMain1 = new Rectangle(20, 55, 410, 345);
            Rectangle RMain2 = new Rectangle(25, 60, 400, 335);
            //图例区域
            Rectangle RDes1 = new Rectangle(440, 55, 150, 345);
            //图例说明
            string Des = "图例说明：";
            Font f2 = new Font("黑体", 10, FontStyle.Bold);
            Point PDes = new Point(442, 65);
            //图例信息，后面的x坐标上累加20
            Rectangle RDes2 = new Rectangle(445, 90, 10, 10);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            try
            {
                //设置背景色、绘制边框
                g.Clear(Color.White);
                g.DrawRectangle(pen, 1, 1, _Width - 2, _Height - 2);
                //绘制标题、线
                g.DrawString(Title, f1, new SolidBrush(Color.Black), PTitle);
                g.DrawLine(pen, PLine1, PLine2);

                //主区域 
                image = DrawRectangle(image, RMain1);
                //图例区域
                image = DrawRectangle(image, RDes1);
                //“图例说明”
                g.DrawString(Des, f2, new SolidBrush(Color.Black), PDes);
                //return 
                return image;
            }
            finally
            {
                g.Dispose();
            }

        }
        #endregion



        #region//绘制图形、报表

        #region//print Event
        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            
            _CurrentPageIndex++;
            _CurrentPoint = new Point(_LeftMargin, _RightMargin);
            int serialNumWidth = 40;
            int colWidth = (e.PageBounds.Width - _LeftMargin - _RightMargin - serialNumWidth) / _DT.Columns.Count;
            //int colWidth = 297;
            //第一页绘制标题，图形
            if (_CurrentPageIndex == 1)
            {
                DrawTitle(e);
                //DrawImage(e);
                DrawTableHeader(e, serialNumWidth, colWidth);
                DrawBottom(e);
                DrawTableAndSerialNumAndData(e, serialNumWidth, colWidth);
                if (_PageCount > 1)
                    e.HasMorePages = true;

            }
            else if (_CurrentPageIndex == _PageCount)
            {
                DrawTableHeader(e, serialNumWidth, colWidth);
                DrawTableAndSerialNumAndData(e, serialNumWidth, colWidth);
                DrawBottom(e);
                e.HasMorePages = false;
                e.Cancel = true;
            }
            else
            {
                DrawTableHeader(e, serialNumWidth, colWidth);
                DrawTableAndSerialNumAndData(e, serialNumWidth, colWidth);
                DrawBottom(e);
                e.HasMorePages = true;

            }
        }
        private void BeginPrint(object sender, PrintEventArgs e)
        {
            _CurrentPageIndex = 0;
            _CurrentRowsIndex = 0;
            e.Cancel = false;
        }
        #endregion

        #region//绘制标题
        private void DrawTitle(PrintPageEventArgs e)
        {
            //标题 居中
            _CurrentPoint.X = (e.PageBounds.Width) / 2 - (int)(e.Graphics.MeasureString(_Title, _TitleFont).Width) / 2;
            e.Graphics.DrawString(_Title, _TitleFont, new SolidBrush(Color.Black), _CurrentPoint);
            _CurrentPoint.Y += (int)(e.Graphics.MeasureString(_Title, _TitleFont).Height);
            //标题下的线
            int len = (int)(e.Graphics.MeasureString(_Title, _TitleFont).Width) + 100;
            int start = (e.PageBounds.Width) / 2 - len / 2;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(start, _CurrentPoint.Y), new Point(start + len, _CurrentPoint.Y));
            _CurrentPoint.Y += 3;
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(start, _CurrentPoint.Y), new Point(start + len, _CurrentPoint.Y));
            _CurrentPoint.Y += 50;
            _CurrentPoint.X = _LeftMargin;
        }

        #endregion

        #region//绘制统计图
        private void DrawImage(PrintPageEventArgs e)
        {
            //标题 居中
            _CurrentPoint.X = (e.PageBounds.Width) / 2 - _Width / 2;
            // e.Graphics.DrawImage(GetPieImage(_ImgTitle, _DT), _CurrentPoint);
            _CurrentPoint.X = _LeftMargin;
            _CurrentPoint.Y += _Height + 50;
        }

        #endregion

        #region//绘制页尾
        private void DrawBottom(PrintPageEventArgs e)
        {
            int pageNumWidth = 70;
            int count = _BottomStr.Length;
            int width = (e.PageBounds.Width - _LeftMargin - _RightMargin - pageNumWidth) / (count + 1);
            int y = e.PageBounds.Height - _BottomMargin + 5;
            int x = _LeftMargin;
            //line
            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), x, y, e.PageBounds.Width - _RightMargin, y);
            y += 5;
            for (int i = 0; i < count; i++)
            {
                if (i > 0)
                    x += width;
                e.Graphics.DrawString(_BottomStr[i], _ContentFont, new SolidBrush(Color.Black), x, y);
            }
            x = e.PageBounds.Width - _RightMargin - pageNumWidth;
            e.Graphics.DrawString(string.Format("第{0}页/共{1}页", _CurrentPageIndex, _PageCount), _ContentFont, new SolidBrush(Color.Black), x, y);
        }

        #endregion

        #region//绘制表格和序号、数据

        private void DrawTableAndSerialNumAndData(PrintPageEventArgs e, int serialNumWidth, int colWidth)
        {
            int useAbleHeight = e.PageBounds.Height - _CurrentPoint.Y - _BottomMargin;
            int useAbleRowsCount = useAbleHeight / _RowHeight;
            int rowsCount = 0;
            if (_RowsCount - _CurrentRowsIndex > useAbleRowsCount)
                rowsCount = useAbleRowsCount;
            else
                rowsCount = _RowsCount - _CurrentRowsIndex;
            Point pp = new Point(_CurrentPoint.X, _CurrentPoint.Y);
            for (int i = 0; i <= rowsCount; i++)
            {
                e.Graphics.DrawLine(pen, _LeftMargin, _CurrentPoint.Y + i * _RowHeight, e.PageBounds.Width - _RightMargin, _CurrentPoint.Y + i * _RowHeight);
                //绘制数据
                if (i >= rowsCount)
                    break;
                DrawCellString((i + 1 + _CurrentRowsIndex).ToString(), pp, serialNumWidth, _ContentFont, e);
                pp.X += serialNumWidth;
                for (int j = 0; j < _DT.Columns.Count; j++)
                {
                    DrawCellString(_DT.Rows[i + _CurrentRowsIndex][j].ToString(), pp, colWidth, _ContentFont, e);
                    pp.X += colWidth;
                }
                pp.Y += _RowHeight;
                pp.X = _CurrentPoint.X;

            }
            //绘制竖线
            Point p = new Point(_CurrentPoint.X, _CurrentPoint.Y);
            e.Graphics.DrawLine(pen, p, new Point(p.X, p.Y + _RowHeight * rowsCount));
            p.X += serialNumWidth;
            e.Graphics.DrawLine(pen, p, new Point(p.X, p.Y + _RowHeight * rowsCount));
            for (int i = 1; i < _DT.Columns.Count; i++)
            {
                p.X += colWidth;
                e.Graphics.DrawLine(pen, p, new Point(p.X, p.Y + _RowHeight * rowsCount));
            }
            p.X = e.PageBounds.Width - _RightMargin;
            e.Graphics.DrawLine(pen, p, new Point(p.X, p.Y + _RowHeight * rowsCount));
            _CurrentRowsIndex += rowsCount;
        }

        #endregion

        #region//填充数据到单元格
        private void DrawCellString(string str, Point p, int colWidth, Font f, PrintPageEventArgs e)
        {
            int strWidth = (int)e.Graphics.MeasureString(str, f).Width;
            int strHeight = (int)e.Graphics.MeasureString(str, f).Height;
            p.X += (colWidth - strWidth) / 2;
            p.Y += 5;
            p.Y += (_RowHeight - strHeight) / 2;
            e.Graphics.DrawString(str, f, brush, p);
        }
        #endregion

        #region//绘制标题
        private void DrawTableHeader(PrintPageEventArgs e, int serialNumWidth, int colWidth)
        {
            //画框
            Point pp = new Point(_CurrentPoint.X, _CurrentPoint.Y);
            e.Graphics.DrawLine(pen, pp, new Point(e.PageBounds.Width - _RightMargin, pp.Y));
            pp.Y += _RowHeight;
            e.Graphics.DrawLine(pen, pp, new Point(e.PageBounds.Width - _RightMargin, pp.Y));
            pp = new Point(_CurrentPoint.X, _CurrentPoint.Y);
            e.Graphics.DrawLine(pen, pp, new Point(pp.X, pp.Y + _RowHeight));
            pp.X += serialNumWidth;
            e.Graphics.DrawLine(pen, pp, new Point(pp.X, pp.Y + _RowHeight));
            for (int i = 1; i < _DT.Columns.Count; i++)
            {
                pp.X += colWidth;
                e.Graphics.DrawLine(pen, pp, new Point(pp.X, pp.Y + _RowHeight));
            }
            pp.X = e.PageBounds.Width - _RightMargin;
            e.Graphics.DrawLine(pen, pp, new Point(pp.X, pp.Y + _RowHeight));
            //
            Point p = new Point(_CurrentPoint.X + 5, _CurrentPoint.Y);
            DrawCellString("序号", p, serialNumWidth, _ColumnsHeaderFont, e);
            p.X += serialNumWidth;
            for (int i = 0; i < _DT.Columns.Count; i++)
            {
                if (i != 0)
                    p.X += colWidth;
                DrawCellString(_ColumnsHeader[i], p, colWidth, _ColumnsHeaderFont, e);
            }
            _CurrentPoint.X = _LeftMargin;
            _CurrentPoint.Y += _RowHeight;
        }
        #endregion

        #region// 自定义设置打印预览对话框
        public void SetPrintPreviewDialog(PrintPreviewDialog pPreviewDialog)
        {
            System.Reflection.PropertyInfo[] pis = pPreviewDialog.GetType().GetProperties();
            for (int i = 0; i < pis.Length; i++)
            {
                switch (pis[i].Name)
                {
                    case "Dock":
                        pis[i].SetValue(pPreviewDialog, DockStyle.Fill, null);
                        break;
                    case "FormBorderStyle":
                        pis[i].SetValue(pPreviewDialog, FormBorderStyle.None, null);
                        break;
                    case "WindowState":
                        pis[i].SetValue(pPreviewDialog, FormWindowState.Normal, null);
                        break;
                    default: break;
                }
            }
            #region//屏蔽默认的打印按钮，添加自定义的打印和保存按钮
            foreach (Control c in pPreviewDialog.Controls)
            {
                if (c is ToolStrip)
                {
                    ToolStrip ts = (ToolStrip)c;
                    ts.Items[0].Visible = false;
                    //print
                    ToolStripButton toolStripBtn_Print = new ToolStripButton();
                    toolStripBtn_Print.Text = "打印";
                    toolStripBtn_Print.ToolTipText = "打印当前报表数据";
                    //toolStripBtn_Print.Image = Properties.Resources.printer;
                    toolStripBtn_Print.Click += delegate(object sender, EventArgs e){
                         PrintDialog pd = new PrintDialog();
                         pd.Document = pPreviewDialog.Document;
                         pd.UseEXDialog = true;
                         if (pd.ShowDialog() == DialogResult.OK)
                          pPreviewDialog.Document.Print();
                     };
                    //ToolStripButton toolStripBtn_SaveAsExcel = new ToolStripButton();
                    //toolStripBtn_SaveAsExcel.Text = "保存Excel";
                    //toolStripBtn_SaveAsExcel.ToolTipText = "导出报表到Excel";
                    ////toolStripBtn_SaveAsExcel.Image = Properties.Resources.save;
                    //toolStripBtn_SaveAsExcel.Click += delegate(object sender, EventArgs e)
                    //    {
                    //         SaveFileDialog f = new SaveFileDialog();
                    //         if (f.ShowDialog() == DialogResult.OK)
                    //         {
                    //               // SaveAsExcl(f.FileName);
                    //        }
                    //     };
                    ToolStripSeparator tss = new ToolStripSeparator();
                    ts.Items.Insert(0, toolStripBtn_Print);
                    //ts.Items.Insert(1, toolStripBtn_SaveAsExcel);
                    ts.Items.Insert(1, tss);
                }
            }
            #endregion
        }


        #endregion

        #endregion
    }

}
