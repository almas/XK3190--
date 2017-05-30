namespace XmWeightForm.SystemManage
{
    partial class SysManageForm
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReport = new System.Windows.Forms.ToolStripLabel();
            this.btnProduct = new System.Windows.Forms.ToolStripLabel();
            this.btnPrice = new System.Windows.Forms.ToolStripLabel();
            this.btnFactory = new System.Windows.Forms.ToolStripLabel();
            this.btnPerson = new System.Windows.Forms.ToolStripLabel();
            this.groupMain = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReport,
            this.btnProduct,
            this.btnPrice,
            this.btnFactory,
            this.btnPerson});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1227, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReport
            // 
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(56, 22);
            this.btnReport.Text = "报表统计";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(56, 22);
            this.btnProduct.Text = "产品管理";
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPrice
            // 
            this.btnPrice.Name = "btnPrice";
            this.btnPrice.Size = new System.Drawing.Size(56, 22);
            this.btnPrice.Text = "酮体价格";
            this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
            // 
            // btnFactory
            // 
            this.btnFactory.Name = "btnFactory";
            this.btnFactory.Size = new System.Drawing.Size(68, 22);
            this.btnFactory.Text = "加工厂信息";
            this.btnFactory.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // btnPerson
            // 
            this.btnPerson.Name = "btnPerson";
            this.btnPerson.Size = new System.Drawing.Size(56, 22);
            this.btnPerson.Text = "人员管理";
            this.btnPerson.Click += new System.EventHandler(this.btnPerson_Click);
            // 
            // groupMain
            // 
            this.groupMain.Location = new System.Drawing.Point(12, 73);
            this.groupMain.Name = "groupMain";
            this.groupMain.Size = new System.Drawing.Size(1203, 650);
            this.groupMain.TabIndex = 3;
            this.groupMain.TabStop = false;
            this.groupMain.Text = "系统信息";
            // 
            // SysManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 735);
            this.Controls.Add(this.groupMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SysManageForm";
            this.Text = "系统管理";
            this.Load += new System.EventHandler(this.SysManageForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel btnReport;
        private System.Windows.Forms.ToolStripLabel btnProduct;
        private System.Windows.Forms.ToolStripLabel btnPrice;
        private System.Windows.Forms.ToolStripLabel btnFactory;
        private System.Windows.Forms.ToolStripLabel btnPerson;
        private System.Windows.Forms.GroupBox groupMain;
    }
}