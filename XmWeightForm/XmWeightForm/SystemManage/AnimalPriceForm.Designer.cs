namespace XmWeightForm.SystemManage
{
    partial class AnimalPriceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.priceGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.animalTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.traceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.priceGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(366, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "酮体价格";
            // 
            // priceGrid
            // 
            this.priceGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.priceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.priceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.animalTypeId,
            this.animalTypeName,
            this.price,
            this.traceCode});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.priceGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.priceGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.priceGrid.Location = new System.Drawing.Point(23, 83);
            this.priceGrid.Name = "priceGrid";
            this.priceGrid.RowTemplate.Height = 23;
            this.priceGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.priceGrid.Size = new System.Drawing.Size(945, 456);
            this.priceGrid.TabIndex = 3;
            this.priceGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.priceGrid_CellDoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(23, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "新增";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // animalTypeId
            // 
            this.animalTypeId.DataPropertyName = "animalTypeId";
            this.animalTypeId.HeaderText = "animalTypeId";
            this.animalTypeId.Name = "animalTypeId";
            this.animalTypeId.Visible = false;
            // 
            // animalTypeName
            // 
            this.animalTypeName.DataPropertyName = "animalTypeName";
            this.animalTypeName.HeaderText = "动物类型";
            this.animalTypeName.Name = "animalTypeName";
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "单价(kg)";
            this.price.Name = "price";
            // 
            // traceCode
            // 
            this.traceCode.DataPropertyName = "traceCode";
            this.traceCode.HeaderText = "溯源编号";
            this.traceCode.Name = "traceCode";
            // 
            // AnimalPriceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.priceGrid);
            this.Controls.Add(this.label1);
            this.Name = "AnimalPriceForm";
            this.Size = new System.Drawing.Size(1025, 580);
            this.Load += new System.EventHandler(this.AnimalPriceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.DataGridViewX priceGrid;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn traceCode;
    }
}
