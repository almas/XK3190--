namespace XmWeightForm.SystemManage
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
            this.endTime = new CCWin.SkinControl.SkinDateTimePicker();
            this.startTime = new CCWin.SkinControl.SkinDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdNum = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupReport = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nodeptt = new System.Windows.Forms.RadioButton();
            this.nodepsq = new System.Windows.Forms.RadioButton();
            this.nodepsh = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // endTime
            // 
            this.endTime.BackColor = System.Drawing.Color.Transparent;
            this.endTime.DropDownHeight = 180;
            this.endTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.endTime.DropDownWidth = 120;
            this.endTime.font = new System.Drawing.Font("微软雅黑", 9F);
            this.endTime.Items = null;
            this.endTime.Location = new System.Drawing.Point(384, 39);
            this.endTime.Margin = new System.Windows.Forms.Padding(4);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(183, 28);
            this.endTime.TabIndex = 34;
            this.endTime.text = "";
            // 
            // startTime
            // 
            this.startTime.BackColor = System.Drawing.Color.Transparent;
            this.startTime.DropDownHeight = 180;
            this.startTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.startTime.DropDownWidth = 120;
            this.startTime.font = new System.Drawing.Font("微软雅黑", 9F);
            this.startTime.Items = null;
            this.startTime.Location = new System.Drawing.Point(99, 40);
            this.startTime.Margin = new System.Windows.Forms.Padding(4);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(183, 27);
            this.startTime.TabIndex = 33;
            this.startTime.text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 47);
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
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(724, 50);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 29);
            this.btnExport.TabIndex = 26;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(600, 50);
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
            this.groupReport.Location = new System.Drawing.Point(14, 104);
            this.groupReport.Margin = new System.Windows.Forms.Padding(4);
            this.groupReport.Name = "groupReport";
            this.groupReport.Padding = new System.Windows.Forms.Padding(4);
            this.groupReport.Size = new System.Drawing.Size(994, 491);
            this.groupReport.TabIndex = 24;
            this.groupReport.TabStop = false;
            this.groupReport.Text = "报表统计";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nodepsh);
            this.groupBox1.Controls.Add(this.nodepsq);
            this.groupBox1.Controls.Add(this.nodeptt);
            this.groupBox1.Location = new System.Drawing.Point(600, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(384, 33);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "节点";
            // 
            // nodeptt
            // 
            this.nodeptt.AutoSize = true;
            this.nodeptt.Location = new System.Drawing.Point(7, 11);
            this.nodeptt.Name = "nodeptt";
            this.nodeptt.Size = new System.Drawing.Size(47, 16);
            this.nodeptt.TabIndex = 0;
            this.nodeptt.TabStop = true;
            this.nodeptt.Text = "酮体";
            this.nodeptt.UseVisualStyleBackColor = true;
            // 
            // nodepsq
            // 
            this.nodepsq.AutoSize = true;
            this.nodepsq.Location = new System.Drawing.Point(114, 11);
            this.nodepsq.Name = "nodepsq";
            this.nodepsq.Size = new System.Drawing.Size(59, 16);
            this.nodepsq.TabIndex = 1;
            this.nodepsq.TabStop = true;
            this.nodepsq.Text = "排酸前";
            this.nodepsq.UseVisualStyleBackColor = true;
            // 
            // nodepsh
            // 
            this.nodepsh.AutoSize = true;
            this.nodepsh.Location = new System.Drawing.Point(239, 11);
            this.nodepsh.Name = "nodepsh";
            this.nodepsh.Size = new System.Drawing.Size(59, 16);
            this.nodepsh.TabIndex = 2;
            this.nodepsh.TabStop = true;
            this.nodepsh.Text = "排酸后";
            this.nodepsh.UseVisualStyleBackColor = true;
            // 
            // ReportUForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.endTime);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtIdNum);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.groupReport);
            this.Name = "ReportUForm";
            this.Size = new System.Drawing.Size(1025, 599);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinDateTimePicker endTime;
        private CCWin.SkinControl.SkinDateTimePicker startTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdNum;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton nodepsh;
        private System.Windows.Forms.RadioButton nodepsq;
        private System.Windows.Forms.RadioButton nodeptt;
    }
}
