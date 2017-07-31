namespace ReportClient
{
    partial class ReportUForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportUForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupReport = new System.Windows.Forms.GroupBox();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.axGRDisplayViewer1 = new Axgregn6Lib.AxGRDisplayViewer();
            this.gridBatch = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.batchId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InWeights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutWeights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.startTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.endTime = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.groupReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axGRDisplayViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTime)).BeginInit();
            this.SuspendLayout();
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "结束时间";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 31;
            this.label3.Text = "开始时间";
            //
            // txtIdNum
            //
            this.txtIdNum.Location = new System.Drawing.Point(384, 10);
            this.txtIdNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(183, 21);
            this.txtIdNum.TabIndex = 30;
            //
            // txtname
            //
            this.txtname.Location = new System.Drawing.Point(99, 12);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(183, 21);
            this.txtname.TabIndex = 29;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "身份证";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "姓名";
            //
            // btnQuery
            //
            this.btnQuery.Location = new System.Drawing.Point(612, 33);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 29);
            this.btnQuery.TabIndex = 25;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            //
            // groupReport
            //
            this.groupReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupReport.Controls.Add(this.lblCount);
            this.groupReport.Controls.Add(this.axGRDisplayViewer1);
            this.groupReport.Controls.Add(this.gridBatch);
            this.groupReport.Location = new System.Drawing.Point(14, 104);
            this.groupReport.Margin = new System.Windows.Forms.Padding(4);
            this.groupReport.Name = "groupReport";
            this.groupReport.Padding = new System.Windows.Forms.Padding(4);
            this.groupReport.Size = new System.Drawing.Size(996, 491);
            this.groupReport.TabIndex = 24;
            this.groupReport.TabStop = false;
            this.groupReport.Text = "报表统计";
            //
            // lblCount
            //
            //
            //
            //
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.Location = new System.Drawing.Point(607, 414);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(380, 23);
            this.lblCount.TabIndex = 4;
            //
            // axGRDisplayViewer1
            //
            this.axGRDisplayViewer1.Enabled = true;
            this.axGRDisplayViewer1.Location = new System.Drawing.Point(256, 414);
            this.axGRDisplayViewer1.Name = "axGRDisplayViewer1";
            this.axGRDisplayViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axGRDisplayViewer1.OcxState")));
            this.axGRDisplayViewer1.Size = new System.Drawing.Size(192, 70);
            this.axGRDisplayViewer1.TabIndex = 3;
            //
            // gridBatch
            //
            this.gridBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBatch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBatch.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.batchId,
            this.hostName,
            this.PIN,
            this.hookId,
            this.InWeights,
            this.InTime,
            this.OutWeights,
            this.OutTime});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridBatch.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridBatch.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.gridBatch.Location = new System.Drawing.Point(11, 21);
            this.gridBatch.Name = "gridBatch";
            this.gridBatch.RowTemplate.Height = 23;
            this.gridBatch.Size = new System.Drawing.Size(976, 387);
            this.gridBatch.TabIndex = 2;
            //
            // batchId
            //
            this.batchId.DataPropertyName = "batchId";
            this.batchId.HeaderText = "批次号";
            this.batchId.Name = "batchId";
            //
            // hostName
            //
            this.hostName.DataPropertyName = "hostName";
            this.hostName.HeaderText = "姓名";
            this.hostName.Name = "hostName";
            this.hostName.Width = 150;
            //
            // PIN
            //
            this.PIN.DataPropertyName = "PIN";
            this.PIN.HeaderText = "身份证";
            this.PIN.Name = "PIN";
            this.PIN.Width = 200;
            //
            // hookId
            //
            this.hookId.DataPropertyName = "hookId";
            this.hookId.HeaderText = "勾号";
            this.hookId.Name = "hookId";
            //
            // InWeights
            //
            this.InWeights.DataPropertyName = "InWeights";
            this.InWeights.HeaderText = "进库毛重";
            this.InWeights.Name = "InWeights";
            //
            // InTime
            //
            this.InTime.DataPropertyName = "InTime";
            this.InTime.HeaderText = "进库时间";
            this.InTime.Name = "InTime";
            this.InTime.Width = 150;
            //
            // OutWeights
            //
            this.OutWeights.DataPropertyName = "OutWeights";
            this.OutWeights.HeaderText = "出库毛重";
            this.OutWeights.Name = "OutWeights";
            //
            // OutTime
            //
            this.OutTime.DataPropertyName = "OutTime";
            this.OutTime.HeaderText = "出库时间";
            this.OutTime.Name = "OutTime";
            //
            // btnPrintReport
            //
            this.btnPrintReport.Location = new System.Drawing.Point(744, 33);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(84, 29);
            this.btnPrintReport.TabIndex = 35;
            this.btnPrintReport.Text = "打印";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            //
            // startTime
            //
            //
            //
            //
            this.startTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.startTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.startTime.ButtonDropDown.Visible = true;
            this.startTime.IsPopupCalendarOpen = false;
            this.startTime.Location = new System.Drawing.Point(99, 51);
            //
            //
            //
            //
            //
            //
            this.startTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.startTime.MonthCalendar.ClearButtonVisible = true;
            //
            //
            //
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.startTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            //
            //
            //
            this.startTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.startTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.startTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.startTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.startTime.MonthCalendar.TodayButtonVisible = true;
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(183, 21);
            this.startTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.startTime.TabIndex = 36;
            //
            // endTime
            //
            //
            //
            //
            this.endTime.BackgroundStyle.Class = "DateTimeInputBackground";
            this.endTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endTime.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.endTime.ButtonDropDown.Visible = true;
            this.endTime.IsPopupCalendarOpen = false;
            this.endTime.Location = new System.Drawing.Point(384, 50);
            //
            //
            //
            //
            //
            //
            this.endTime.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endTime.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.endTime.MonthCalendar.ClearButtonVisible = true;
            //
            //
            //
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.endTime.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endTime.MonthCalendar.DisplayMonth = new System.DateTime(2017, 7, 1, 0, 0, 0, 0);
            //
            //
            //
            this.endTime.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.endTime.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.endTime.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.endTime.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.endTime.MonthCalendar.TodayButtonVisible = true;
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(183, 21);
            this.endTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.endTime.TabIndex = 37;
            //
            // ReportUForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdNum);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupReport);
            this.Name = "ReportUForm";
            this.Size = new System.Drawing.Size(1025, 599);
            this.Load += new System.EventHandler(this.ReportUForm_Load);
            this.groupReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axGRDisplayViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private CCWin.SkinControl.SkinDateTimePicker endTime;
        //private CCWin.SkinControl.SkinDateTimePicker startTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdNum;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupReport;
        private DevComponents.DotNetBar.Controls.DataGridViewX gridBatch;
        private Axgregn6Lib.AxGRDisplayViewer axGRDisplayViewer1;
        private DevComponents.DotNetBar.LabelX lblCount;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchId;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn hookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn InWeights;
        private System.Windows.Forms.DataGridViewTextBoxColumn InTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutWeights;
        private System.Windows.Forms.DataGridViewTextBoxColumn OutTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput startTime;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput endTime;
    }
}
