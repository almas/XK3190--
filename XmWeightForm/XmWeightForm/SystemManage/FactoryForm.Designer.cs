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
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.factoryGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.factoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hookWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traceURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serverUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.factoryGrid)).BeginInit();
            this.SuspendLayout();
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
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(33, 92);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // factoryGrid
            // 
            this.factoryGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.factoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.factoryGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.factoryId,
            this.factoryName,
            this.hookWeight,
            this.meatRate,
            this.traceURL,
            this.serverUrl});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.factoryGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.factoryGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.factoryGrid.Location = new System.Drawing.Point(3, 136);
            this.factoryGrid.Name = "factoryGrid";
            this.factoryGrid.RowTemplate.Height = 23;
            this.factoryGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.factoryGrid.Size = new System.Drawing.Size(1019, 355);
            this.factoryGrid.TabIndex = 4;
            this.factoryGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.factoryGrid_CellDoubleClick);
            // 
            // factoryId
            // 
            this.factoryId.DataPropertyName = "factoryId";
            this.factoryId.HeaderText = "加工厂代码";
            this.factoryId.Name = "factoryId";
            // 
            // factoryName
            // 
            this.factoryName.DataPropertyName = "factoryName";
            this.factoryName.HeaderText = "加工厂名称";
            this.factoryName.Name = "factoryName";
            this.factoryName.Width = 300;
            // 
            // hookWeight
            // 
            this.hookWeight.DataPropertyName = "hookWeight";
            this.hookWeight.HeaderText = "毛重";
            this.hookWeight.Name = "hookWeight";
            // 
            // meatRate
            // 
            this.meatRate.DataPropertyName = "meatRate";
            this.meatRate.HeaderText = "出肉率";
            this.meatRate.Name = "meatRate";
            // 
            // traceURL
            // 
            this.traceURL.DataPropertyName = "traceURL";
            this.traceURL.HeaderText = "溯源网址";
            this.traceURL.Name = "traceURL";
            this.traceURL.Width = 300;
            // 
            // serverUrl
            // 
            this.serverUrl.DataPropertyName = "serverUrl";
            this.serverUrl.HeaderText = "服务器地址";
            this.serverUrl.Name = "serverUrl";
            // 
            // btnRefresh
            // 
            this.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRefresh.Location = new System.Drawing.Point(859, 107);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // FactoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.factoryGrid);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.skinLabel1);
            this.Name = "FactoryForm";
            this.Size = new System.Drawing.Size(1025, 580);
            this.Load += new System.EventHandler(this.FactoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.factoryGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.DataGridViewX factoryGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hookWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn meatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn traceURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn serverUrl;
        private DevComponents.DotNetBar.ButtonX btnRefresh;
    }
}
