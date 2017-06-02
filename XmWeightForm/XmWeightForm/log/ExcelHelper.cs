using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.Util;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using System.IO;
using NPOI.SS.Util;

namespace XmWeightForm
{
    public class ExcelHelper
    {
        public ExcelHelper(string sheetName)
        {
            mRowIndex = 0;  //0 行留作 标题用,这里从1 开始
            mColIndex = 0;
            mMaxColIndex = 0;
            //工作文件
            mHSSFWorkbook = new HSSFWorkbook();

            //工作薄
            mHSSFSheet = (HSSFSheet)mHSSFWorkbook.CreateSheet(sheetName);
            mSheetName = sheetName;
            //样式
            mCellStyleTitle = CellStyleTemplates.CellStyleTitle1(mHSSFWorkbook, HSSFFontTemplates.FontTitle1(mHSSFWorkbook));
            mCellStyleColTitle = CellStyleTemplates.CellStyleColTitle1(mHSSFWorkbook, HSSFFontTemplates.FontColTitle1(mHSSFWorkbook));
            mCellStyleContent = CellStyleTemplates.CellStyleContent1(mHSSFWorkbook, HSSFFontTemplates.FontContent1(mHSSFWorkbook));
            //标题
            HSSFRow row = (HSSFRow)mHSSFSheet.CreateRow(0);
            HSSFCell cell = (HSSFCell)row.CreateCell(0);
            cell.CellStyle = mCellStyleTitle;
        }
        public HSSFRow CreateRows()
        {
            return (HSSFRow)mHSSFSheet.CreateRow(++mRowIndex);
        }
        public HSSFRow CreateRows(int r)
        {
            ++mRowIndex;
            if (r <= 0)
                r = mRowIndex;
            return (HSSFRow)mHSSFSheet.CreateRow(r);
        }
        public void CreateHeaders(int r, int c, string[] colsHeader, short rowHeight)
        {
            HSSFRow row = CreateRows(r);
            if (c <= 0) c = 0;
            row.HeightInPoints = (rowHeight > 0) ? rowHeight : mDefaultHeight;
            mColIndex = c + colsHeader.Length;
            if (mMaxColIndex < mColIndex)
                mMaxColIndex = mColIndex;
            HSSFCell cell;
            for (int i = 0; i <= (mColIndex - c - 1); i++)
            {
                cell = (HSSFCell)row.CreateCell(c + i);
                cell.SetCellValue(colsHeader[i]);
                cell.CellStyle = mCellStyleColTitle;
            }
        }
        public void CreateRowByData(int r, int c, string[] rowData, short rowHeight)
        {
            HSSFRow row = CreateRows(r);
            if (c <= 0) c = 0;
            row.HeightInPoints = (rowHeight > 0) ? rowHeight : mDefaultHeight;
            HSSFCell cell;
            for (int i = 0; i <= mColIndex - 1; i++)
            {
                cell = (HSSFCell)row.CreateCell(c + i);
                cell.SetCellValue(rowData[i]);
                cell.CellStyle = mCellStyleContent;
            }
        }
        public void CreateTableByData(int r, int c, DataTable data, short rowHeight)
        {
            HSSFRow row;
            HSSFCell cell;
            short height = (rowHeight > 0) ? rowHeight : mDefaultHeight;
            foreach (DataRow eachRow in data.Rows)
            {
                row = CreateRows(r);
                row.HeightInPoints = height;
                for (int i = 0; i <= mColIndex - 1; i++)
                {
                    cell = (HSSFCell)row.CreateCell(c + i);
                    cell.SetCellValue(eachRow[i].ToString());
                    cell.CellStyle = mCellStyleContent;
                }
            }
        }
        public void CreateTableByData(int r, int c, DataTable data, string[] selectColNames, short rowHeight)
        {
            HSSFRow row;
            HSSFCell cell;
            short height = (rowHeight > 0) ? rowHeight : mDefaultHeight;
            int length = selectColNames.Length;
            foreach (DataRow eachRow in data.Rows)
            {
                row = CreateRows(r);
                row.HeightInPoints = height;
                for (int i = 0; i <= length - 1; i++)
                {
                    cell = (HSSFCell)row.CreateCell(c + i);
                    cell.SetCellValue(eachRow[selectColNames[i]].ToString());
                    cell.CellStyle = mCellStyleContent;
                }
            }
        }
        public MemoryStream ExportExcel()
        {
            //write to  client
            MemoryStream stream = new MemoryStream();
            mHSSFWorkbook.Write(stream);
            stream.Flush();
            stream.Position = 0;
            return stream;
        }
        private const short mDefaultHeight = 30;
        //记录已经建立行的最大的行号
        //0 行留作 标题用
        private int mRowIndex;
        public int RowIndex
        {
            get { return mRowIndex; }
        }
        private int mColIndex;
        public int ColIndex
        {
            get { return mColIndex; }
        }
        private int mMaxColIndex;
        public int MaxColIndex
        {
            get { return mMaxColIndex; }
        }
        //工作簿
        private HSSFWorkbook mHSSFWorkbook;
        public HSSFWorkbook HSSFWorkbook
        {
            get { return mHSSFWorkbook; }
        }
        private HSSFSheet mHSSFSheet;
        public HSSFSheet MHSSFSheet
        {
            get { return mHSSFSheet; }
        }
        //样式
        private HSSFCellStyle mCellStyleTitle;
        public HSSFCellStyle CellStyleTitle
        {
            get { return mCellStyleTitle; }
            set { mCellStyleTitle = value; }
        }
        private HSSFCellStyle mCellStyleColTitle;
        public HSSFCellStyle CellStyleColTitle
        {
            get { return mCellStyleColTitle; }
            set { mCellStyleColTitle = value; }
        }
        private HSSFCellStyle mCellStyleContent;
        public HSSFCellStyle CellStyleContent
        {
            get { return mCellStyleContent; }
            set { mCellStyleContent = value; }
        }
        //工作薄属性
        private string mSheetName;
        public void SetColumnWidth(short width)
        {
            for (int i = 0; i <= mMaxColIndex - 1; i++)
            {
                mHSSFSheet.SetColumnWidth(i, width * 256);
            }
        }
        public void SetTitle(short rowHeight)
        {
            HSSFRow row = (HSSFRow)mHSSFSheet.GetRow(0);
            row.HeightInPoints = (rowHeight > 0) ? rowHeight : mDefaultHeight;
            row.GetCell(0).SetCellValue(mSheetName);
            for (int i = 1; i <= mMaxColIndex - 1; i++)
            {
                row.CreateCell(i).CellStyle = mCellStyleTitle;
            }
            AddMergedRegion(0, 0, 0, mMaxColIndex - 1);
        }
        public void AddMergedRegion(int firstRow, int lastRow, int firstCol, int lastCol)
        {
            mHSSFSheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, firstCol, lastCol));
        }



    }

    #region 字体样式模板
    /************************************************************************/
    /*                 字体样式模板默认样式                                 */
    /************************************************************************/
    public class FontDefaultTemplate
    {
        public FontDefaultTemplate(HSSFWorkbook hSSFWorkbook)
        {
            mHSSFFont = (HSSFFont)hSSFWorkbook.CreateFont();
            mHSSFFont.FontName = "微软雅黑"; //字体类型
            mHSSFFont.FontHeightInPoints = 18;   //字号
            mHSSFFont.Boldweight = (short)FontBoldWeight.Normal;   //字形  普通
            mHSSFFont.Color = HSSFColor.Black.Index; //字体颜色
            mHSSFFont.Underline = FontUnderlineType.None;   //下划线    无
            mHSSFFont.IsItalic = false;  //斜体    无
            mHSSFFont.IsStrikeout = false;   //删除线    无  
        }
        public HSSFFont FontDefaultStyle
        {
            get { return mHSSFFont; }
        }
        private HSSFFont mHSSFFont;
    }
    /************************************************************************/
    /*                字体样式模板                                       */
    /************************************************************************/
    public static class HSSFFontTemplates
    {
        /// <summary>
        /// 大标题1
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <returns>HSSFFont</returns>
        public static HSSFFont FontTitle1(HSSFWorkbook hSSFWorkbook)
        {
            FontDefaultTemplate fontDefaultTemplate = new FontDefaultTemplate(hSSFWorkbook);
            HSSFFont font = fontDefaultTemplate.FontDefaultStyle;
            return font;
        }
        /// <summary>
        /// 大标题2
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <returns>HSSFFont</returns>
        public static HSSFFont FontTitle2(HSSFWorkbook hSSFWorkbook)
        {
            FontDefaultTemplate fontDefaultTemplate = new FontDefaultTemplate(hSSFWorkbook);
            HSSFFont font = fontDefaultTemplate.FontDefaultStyle;
            font.FontHeightInPoints = 11;   //字号 
            font.Color = HSSFColor.Blue.Index; //字体颜色
            return font;
        }
        /// <summary>
        /// 列标题1
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <returns>HSSFFont</returns>
        public static HSSFFont FontColTitle1(HSSFWorkbook hSSFWorkbook)
        {
            FontDefaultTemplate fontDefaultTemplate = new FontDefaultTemplate(hSSFWorkbook);
            HSSFFont font = fontDefaultTemplate.FontDefaultStyle;
            font.FontHeightInPoints = 11;   //字号
            font.Boldweight = (short)FontBoldWeight.Bold;   //字形    加粗         
            return font;
        }
        /// <summary>
        /// 内容1
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <returns>HSSFFont</returns>
        public static HSSFFont FontContent1(HSSFWorkbook hSSFWorkbook)
        {
            FontDefaultTemplate fontDefaultTemplate = new FontDefaultTemplate(hSSFWorkbook);
            HSSFFont font = fontDefaultTemplate.FontDefaultStyle;
            font.FontHeightInPoints = 11;   //字号
            font.Boldweight = (short)FontBoldWeight.Bold;   //字形    加粗
            font.Color = HSSFColor.Black.Index; //字体颜色        
            return font;
        }
    }
    #endregion

    #region 单元格样式模板
    /************************************************************************/
    /*             单元格样式默认模板                                            */
    /************************************************************************/
    public class CellStyleDefaultTemplate
    {
        public CellStyleDefaultTemplate(HSSFWorkbook hSSFWorkbook, HSSFFont hSSFFont)
        {
            if (null == mHSSFCellStyle)
            {
                mHSSFCellStyle = (HSSFCellStyle)hSSFWorkbook.CreateCellStyle();
            }
            if (null != hSSFFont)
            {
                mHSSFCellStyle.SetFont(hSSFFont);    //对应的字体样式
            }

            mHSSFCellStyle.Alignment = HorizontalAlignment.Center;// HSSFCellStyle.ALIGN_CENTER;   //左右对齐  居中
            mHSSFCellStyle.VerticalAlignment = VerticalAlignment.Center;// HSSFCellStyle.VERTICAL_CENTER;    //上下对齐  居中
            mHSSFCellStyle.BorderTop = BorderStyle.Thin;// HSSFCellStyle.BORDER_THIN;    //上边框
            mHSSFCellStyle.BorderBottom = BorderStyle.Thin;// HSSFCellStyle.BORDER_THIN;    //下边框
            mHSSFCellStyle.BorderLeft = BorderStyle.Thin;//HSSFCellStyle.BORDER_THIN;     //左边框
            mHSSFCellStyle.BorderRight = BorderStyle.Thin;//HSSFCellStyle.BORDER_THIN;     //右边框
            mHSSFCellStyle.TopBorderColor = HSSFColor.Black.Index;    //上边框颜色
            mHSSFCellStyle.BottomBorderColor = HSSFColor.Black.Index;    //下边框颜色
            mHSSFCellStyle.LeftBorderColor = HSSFColor.Black.Index;    //左边框颜色
            mHSSFCellStyle.RightBorderColor = HSSFColor.Black.Index;    //右边框颜色
            mHSSFCellStyle.WrapText = false; //自动换行  不自动换行  
            mHSSFCellStyle.FillBackgroundColor = HSSFColor.White.Index;  //前景色    白色
            mHSSFCellStyle.FillForegroundColor = HSSFColor.White.Index;    //背景色    白色
            mHSSFCellStyle.FillPattern = FillPattern.SolidForeground;// HSSFCellStyle.SOLID_FOREGROUND; //填充方式  全部填充 
        }
        public HSSFCellStyle CellStyleDefault
        {
            get { return mHSSFCellStyle; }
        }
        private HSSFCellStyle mHSSFCellStyle;
    }

    /************************************************************************/
    /*                    单元格样式新模板                                   */
    /************************************************************************/
    public static class CellStyleTemplates
    {
        /// <summary>
        /// 单元格样式 标题1
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <param name="hSSFFont">HSSFFont</param>
        /// <returns>HSSFCellStyle</returns>
        public static HSSFCellStyle CellStyleTitle1(HSSFWorkbook hSSFWorkbook, HSSFFont hSSFFont)
        {
            CellStyleDefaultTemplate defaultTemplate = new CellStyleDefaultTemplate(hSSFWorkbook, hSSFFont);
            HSSFCellStyle style = defaultTemplate.CellStyleDefault;
            style.FillForegroundColor = HSSFColor.Grey25Percent.Index;    //背景色 
            return style;
        }
        /// <summary>
        /// 单元格样式 列标题
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <param name="hSSFFont">HSSFFont</param>
        /// <returns>HSSFCellStyle</returns>
        public static HSSFCellStyle CellStyleColTitle1(HSSFWorkbook hSSFWorkbook, HSSFFont hSSFFont)
        {
            CellStyleDefaultTemplate defaultTemplate = new CellStyleDefaultTemplate(hSSFWorkbook, hSSFFont);
            HSSFCellStyle style = defaultTemplate.CellStyleDefault;
            style.FillForegroundColor = HSSFColor.LightCornflowerBlue.Index;    //背景色
            return style;
        }
        /// <summary>
        /// 单元格样式 
        /// </summary>
        /// <param name="hSSFWorkbook">HSSFWorkbook</param>
        /// <param name="hSSFFont">HSSFFont</param>
        /// <returns>HSSFCellStyle</returns>
        public static HSSFCellStyle CellStyleContent1(HSSFWorkbook hSSFWorkbook, HSSFFont hSSFFont)
        {
            CellStyleDefaultTemplate defaultTemplate = new CellStyleDefaultTemplate(hSSFWorkbook, hSSFFont);
            HSSFCellStyle style = defaultTemplate.CellStyleDefault;
            return style;
        }
    }
    #endregion

    /// <summary>
    /// study progress report 学习进度报表
    /// </summary>
    public static class WorkBookTemplates
    {
        /// <summary>
        /// course gather report
        /// </summary>
        /// <param name="data"></param>
        public static MemoryStream WorkBookTemplateGatherInfo(DataTable data)
        {
            //create helper
            ExcelHelper workBookHelper = new ExcelHelper("学习进度汇总报表");

            //create header
            string[] headers = { "学习岗位", "总登录次数", "总学习时间", "首次登录时间", "最近一次登录时间", "有效期(天)", "学习截至日期", "岗位课程总数", "已学习课程数", "学习率", "考试通过课程数", "通过率" };
            workBookHelper.CreateHeaders(0, 0, headers, 25);
            //create data
            workBookHelper.CreateTableByData(0, 0, data, 30);
            //define pattern
            workBookHelper.SetColumnWidth(30);
            workBookHelper.SetTitle(30);
            //return result by stream
            return workBookHelper.ExportExcel();
        }
        /// <summary>
        /// course detail  report  学习课程明细报表
        /// </summary>
        /// <param name="data">data sourse</param>
        public static MemoryStream WorkBookTemplateDetailInfo(DataTable data)
        {
            //create helper
            ExcelHelper workBookHelper = new ExcelHelper("课程明细报表");
            //create header
            //string[] headers = { "序号", "课程名称", "学习情况", "所得考分", "课程类型", "考试次数", "通过时间" };
            string[] headers = { "序号", "名称"};
            workBookHelper.CreateHeaders(0, 0, headers, 30);
            string[] colNames = { "CaseID", "CaseName" };
            //create data
            workBookHelper.CreateTableByData(0, 0, data, colNames, 30);
            //define pattern
            workBookHelper.SetColumnWidth(30);
            workBookHelper.SetTitle(40);
            //return result by stream
            return workBookHelper.ExportExcel();
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="fileName">标题</param>
        /// <param name="headers">列标题数组</param>
        /// <returns></returns>
        public static MemoryStream WorkBookTemplateGatherInfo(DataTable data, string fileName, string[] headers)
        {
            //create helper
            ExcelHelper workBookHelper = new ExcelHelper(fileName);

            //create header
            workBookHelper.CreateHeaders(0, 0, headers, 25);
            //create data
            workBookHelper.CreateTableByData(0, 0, data, 30);
            //define pattern
            workBookHelper.SetColumnWidth(30);
            workBookHelper.SetTitle(30);
            //return result by stream
            return workBookHelper.ExportExcel();
        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="data">数据集</param>
        /// <param name="fileName">标题</param>
        /// <param name="headers">列标题数组</param>
        /// <param name="colNames">绑定的字段数组</param>
        /// <returns></returns>
        public static MemoryStream WorkBookTemplateDetailInfo(DataTable data, string fileName, string[] headers, string[] colNames)
        {
            //create helper
            ExcelHelper workBookHelper = new ExcelHelper(fileName);
            //create header
            workBookHelper.CreateHeaders(0, 0, headers, 30);
            //create data
            workBookHelper.CreateTableByData(0, 0, data, colNames, 30);
            //define pattern
            workBookHelper.SetColumnWidth(30);
            workBookHelper.SetTitle(40);
            //return result by stream
            return workBookHelper.ExportExcel();
        }
    }
}
