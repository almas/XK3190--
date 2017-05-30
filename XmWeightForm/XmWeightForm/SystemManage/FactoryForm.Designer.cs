namespace XmWeightForm.SystemManage
{
    partial class FactoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.factoryGrid = new CCWin.SkinControl.SkinDataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.factoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hookWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traceURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.factoryGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // factoryGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.factoryGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.factoryGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.factoryGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.factoryGrid.ColumnFont = null;
            this.factoryGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.factoryGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.factoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.factoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.factoryId,
            this.factoryName,
            this.hookWeight,
            this.meatRate,
            this.extraRate,
            this.traceURL});
            this.factoryGrid.ColumnSelectForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.factoryGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.factoryGrid.EnableHeadersVisualStyles = false;
            this.factoryGrid.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.factoryGrid.HeadFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.factoryGrid.HeadSelectForeColor = System.Drawing.SystemColors.HighlightText;
            this.factoryGrid.Location = new System.Drawing.Point(38, 121);
            this.factoryGrid.Name = "factoryGrid";
            this.factoryGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.factoryGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.factoryGrid.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.factoryGrid.RowTemplate.Height = 23;
            this.factoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.factoryGrid.Size = new System.Drawing.Size(839, 317);
            this.factoryGrid.TabIndex = 0;
            this.factoryGrid.TitleBack = null;
            this.factoryGrid.TitleBackColorBegin = System.Drawing.Color.White;
            this.factoryGrid.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(196)))), ((int)(((byte)(242)))));
            this.factoryGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.skinDataGridView1_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(339, 44);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(84, 19);
            this.skinLabel1.TabIndex = 2;
            this.skinLabel1.Text = "加工厂信息";
            // 
            // factoryId
            // 
            this.factoryId.DataPropertyName = "factoryId";
            this.factoryId.HeaderText = "加工厂代码";
            this.factoryId.Name = "factoryId";
            this.factoryId.Width = 150;
            // 
            // factoryName
            // 
            this.factoryName.DataPropertyName = "factoryName";
            this.factoryName.HeaderText = "加工厂名称";
            this.factoryName.Name = "factoryName";
            // 
            // hookWeight
            // 
            this.hookWeight.DataPropertyName = "hookWeight";
            this.hookWeight.HeaderText = "皮重";
            this.hookWeight.Name = "hookWeight";
            // 
            // meatRate
            // 
            this.meatRate.DataPropertyName = "meatRate";
            this.meatRate.HeaderText = "出肉率";
            this.meatRate.Name = "meatRate";
            // 
            // extraRate
            // 
            this.extraRate.DataPropertyName = "extraRate";
            this.extraRate.HeaderText = "耗损率";
            this.extraRate.Name = "extraRate";
            // 
            // traceURL
            // 
            this.traceURL.DataPropertyName = "traceURL";
            this.traceURL.HeaderText = "溯源网址";
            this.traceURL.Name = "traceURL";
            // 
            // FactoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.factoryGrid);
            this.Name = "FactoryForm";
            this.Size = new System.Drawing.Size(921, 531);
            this.Load += new System.EventHandler(this.FactoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.factoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinDataGridView factoryGrid;
        private System.Windows.Forms.Button btnAdd;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hookWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn meatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn traceURL;
    }
}
