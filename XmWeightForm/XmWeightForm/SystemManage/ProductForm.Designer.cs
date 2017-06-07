namespace XmWeightForm.SystemManage
{
    partial class ProductForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.queryProductName = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.excelFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.productGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isfixedStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nominalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(743, 479);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 2;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(860, 479);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "产品名称：";
            // 
            // queryProductName
            // 
            this.queryProductName.Location = new System.Drawing.Point(548, 51);
            this.queryProductName.Name = "queryProductName";
            this.queryProductName.Size = new System.Drawing.Size(204, 21);
            this.queryProductName.TabIndex = 6;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(801, 51);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(17, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "新增产品";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(339, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "产品信息";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(179, 51);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 11;
            this.btnImport.Text = "导入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // excelFileDialog
            // 
            this.excelFileDialog.FileName = "openFileDialog1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(618, 479);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(88, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(98, 51);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 13;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // productGrid
            // 
            this.productGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.productGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.productName,
            this.productNo,
            this.spec,
            this.barcode,
            this.isfixedStr,
            this.nominalWeight,
            this.ingredients,
            this.storageCondition,
            this.expiration,
            this.comment});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.productGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.productGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.productGrid.Location = new System.Drawing.Point(3, 79);
            this.productGrid.Name = "productGrid";
            this.productGrid.RowTemplate.Height = 23;
            this.productGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productGrid.Size = new System.Drawing.Size(958, 394);
            this.productGrid.TabIndex = 14;
            this.productGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productGrid_CellDoubleClick);
            // 
            // productId
            // 
            this.productId.DataPropertyName = "productId";
            this.productId.HeaderText = "productId";
            this.productId.Name = "productId";
            this.productId.Visible = false;
            // 
            // productName
            // 
            this.productName.DataPropertyName = "productName";
            this.productName.HeaderText = "产品名称";
            this.productName.Name = "productName";
            // 
            // productNo
            // 
            this.productNo.DataPropertyName = "productNo";
            this.productNo.HeaderText = "常用编码";
            this.productNo.Name = "productNo";
            // 
            // spec
            // 
            this.spec.DataPropertyName = "spec";
            this.spec.HeaderText = "规格";
            this.spec.Name = "spec";
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "barcode";
            this.barcode.HeaderText = "条码";
            this.barcode.Name = "barcode";
            this.barcode.Width = 150;
            // 
            // isfixedStr
            // 
            this.isfixedStr.DataPropertyName = "isfixedStr";
            this.isfixedStr.HeaderText = "是否定重";
            this.isfixedStr.Name = "isfixedStr";
            // 
            // nominalWeight
            // 
            this.nominalWeight.DataPropertyName = "nominalWeight";
            this.nominalWeight.HeaderText = "重量";
            this.nominalWeight.Name = "nominalWeight";
            // 
            // ingredients
            // 
            this.ingredients.DataPropertyName = "ingredients";
            this.ingredients.HeaderText = "配料";
            this.ingredients.Name = "ingredients";
            // 
            // storageCondition
            // 
            this.storageCondition.DataPropertyName = "storageCondition";
            this.storageCondition.HeaderText = "储存条件";
            this.storageCondition.Name = "storageCondition";
            // 
            // expiration
            // 
            this.expiration.DataPropertyName = "expiration";
            this.expiration.HeaderText = "保质期";
            this.expiration.Name = "expiration";
            // 
            // comment
            // 
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "备注";
            this.comment.Name = "comment";
            // 
            // productModelBindingSource
            // 
            this.productModelBindingSource.DataSource = typeof(AppService.Model.ProductModel);
            // 
            // lblCount
            // 
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.Location = new System.Drawing.Point(5, 479);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(338, 23);
            this.lblCount.TabIndex = 15;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.productGrid);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.queryProductName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Name = "ProductForm";
            this.Size = new System.Drawing.Size(1025, 580);
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox queryProductName;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.BindingSource productModelBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog excelFileDialog;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDel;
        private DevComponents.DotNetBar.Controls.DataGridViewX productGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn isfixedStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredients;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageCondition;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiration;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private DevComponents.DotNetBar.LabelX lblCount;
    }
}
