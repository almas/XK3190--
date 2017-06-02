namespace XmWeightForm
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.endTime.Location = new System.Drawing.Point(415, 75);
            this.endTime.Margin = new System.Windows.Forms.Padding(4);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(134, 28);
            this.endTime.TabIndex = 23;
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
            this.startTime.Location = new System.Drawing.Point(124, 76);
            this.startTime.Margin = new System.Windows.Forms.Padding(4);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(144, 27);
            this.startTime.TabIndex = 22;
            this.startTime.text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "开始时间";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Location = new System.Drawing.Point(415, 28);
            this.txtIdNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(183, 21);
            this.txtIdNum.TabIndex = 19;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(124, 30);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(183, 21);
            this.txtname.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "身份证";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "姓名";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(806, 60);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 29);
            this.btnExport.TabIndex = 15;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(683, 60);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 29);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupReport
            // 
            this.groupReport.Location = new System.Drawing.Point(7, 111);
            this.groupReport.Margin = new System.Windows.Forms.Padding(4);
            this.groupReport.Name = "groupReport";
            this.groupReport.Padding = new System.Windows.Forms.Padding(4);
            this.groupReport.Size = new System.Drawing.Size(1017, 513);
            this.groupReport.TabIndex = 13;
            this.groupReport.TabStop = false;
            this.groupReport.Text = "报表统计";
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 652);
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
            this.Name = "ReportForm";
            this.Text = "ReportForm";
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
    }
}