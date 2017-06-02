namespace XmWeightForm.SystemManage
{
    partial class ReportGridForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.reportGrid = new CCWin.SkinControl.SkinDataGridView();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weights = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).BeginInit();
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
            this.endTime.Location = new System.Drawing.Point(385, 61);
            this.endTime.Margin = new System.Windows.Forms.Padding(4);
            this.endTime.Name = "endTime";
            this.endTime.Size = new System.Drawing.Size(134, 28);
            this.endTime.TabIndex = 33;
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
            this.startTime.Location = new System.Drawing.Point(94, 62);
            this.startTime.Margin = new System.Windows.Forms.Padding(4);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(144, 27);
            this.startTime.TabIndex = 32;
            this.startTime.text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "结束时间";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 30;
            this.label3.Text = "开始时间";
            // 
            // txtIdNum
            // 
            this.txtIdNum.Location = new System.Drawing.Point(385, 14);
            this.txtIdNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdNum.Name = "txtIdNum";
            this.txtIdNum.Size = new System.Drawing.Size(183, 21);
            this.txtIdNum.TabIndex = 29;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(94, 16);
            this.txtname.Margin = new System.Windows.Forms.Padding(4);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(183, 21);
            this.txtname.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "身份证";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 26;
            this.label1.Text = "姓名";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(776, 46);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 29);
            this.btnExport.TabIndex = 25;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(653, 46);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(100, 29);
            this.btnQuery.TabIndex = 24;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // reportGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.reportGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.reportGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.reportGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reportGrid.ColumnFont = null;
            this.reportGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reportGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.reportGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sort,
            this.Name,
            this.IdNum,
            this.ProductName,
            this.ProductNum,
            this.Weights,
            this.Price,
            this.TotalPrice,
            this.WeightTime});
            this.reportGrid.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.reportGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.reportGrid.EnableHeadersVisualStyles = false;
            this.reportGrid.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.reportGrid.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.reportGrid.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.reportGrid.Location = new System.Drawing.Point(20, 119);
            this.reportGrid.Name = "reportGrid";
            this.reportGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.reportGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.reportGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.reportGrid.RowTemplate.Height = 23;
            this.reportGrid.Size = new System.Drawing.Size(965, 421);
            this.reportGrid.TabIndex = 34;
            this.reportGrid.TitleBack = null;
            this.reportGrid.TitleBackColorBegin = System.Drawing.Color.White;
            this.reportGrid.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            // 
            // Sort
            // 
            this.Sort.HeaderText = "Sort";
            this.Sort.Name = "Sort";
            this.Sort.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            this.Name.HeaderText = "姓名";
            this.Name.Name = "Name";
            // 
            // IdNum
            // 
            this.IdNum.DataPropertyName = "IdNum";
            this.IdNum.HeaderText = "身份证";
            this.IdNum.Name = "IdNum";
            this.IdNum.Width = 150;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "品名";
            this.ProductName.Name = "ProductName";
            // 
            // ProductNum
            // 
            this.ProductNum.DataPropertyName = "ProductNum";
            this.ProductNum.HeaderText = "数量";
            this.ProductNum.Name = "ProductNum";
            this.ProductNum.Width = 60;
            // 
            // Weights
            // 
            this.Weights.DataPropertyName = "Weights";
            this.Weights.HeaderText = "重量";
            this.Weights.Name = "Weights";
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "总价";
            this.TotalPrice.Name = "TotalPrice";
            // 
            // WeightTime
            // 
            this.WeightTime.DataPropertyName = "WeightTime";
            this.WeightTime.HeaderText = "称重时间";
            this.WeightTime.Name = "WeightTime";
            this.WeightTime.Width = 300;
            // 
            // ReportGridForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 585);
            this.Controls.Add(this.reportGrid);
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
           // this.Name = "ReportGridForm";
            this.Text = "报表统计";
            ((System.ComponentModel.ISupportInitialize)(this.reportGrid)).EndInit();
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
        private CCWin.SkinControl.SkinDataGridView reportGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weights;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightTime;
    }
}