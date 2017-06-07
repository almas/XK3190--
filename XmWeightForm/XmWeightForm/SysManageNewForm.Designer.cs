namespace XmWeightForm
{
    partial class SysManageNewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysManageNewForm));
            this.sysTabControl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabReport = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabProduct = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabUser = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabFactory = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.tabPrice = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.sysTabControl)).BeginInit();
            this.sysTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysTabControl
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.sysTabControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.sysTabControl.ControlBox.MenuBox.Name = "";
            this.sysTabControl.ControlBox.Name = "";
            this.sysTabControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.sysTabControl.ControlBox.MenuBox,
            this.sysTabControl.ControlBox.CloseBox});
            this.sysTabControl.Controls.Add(this.superTabControlPanel1);
            this.sysTabControl.Controls.Add(this.superTabControlPanel2);
            this.sysTabControl.Controls.Add(this.superTabControlPanel5);
            this.sysTabControl.Controls.Add(this.superTabControlPanel4);
            this.sysTabControl.Controls.Add(this.superTabControlPanel3);
            this.sysTabControl.Location = new System.Drawing.Point(-1, -2);
            this.sysTabControl.Name = "sysTabControl";
            this.sysTabControl.ReorderTabsEnabled = true;
            this.sysTabControl.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.sysTabControl.SelectedTabIndex = 4;
            this.sysTabControl.Size = new System.Drawing.Size(1035, 618);
            this.sysTabControl.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sysTabControl.TabIndex = 0;
            this.sysTabControl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabReport,
            this.tabProduct,
            this.tabPrice,
            this.tabFactory,
            this.tabUser});
            this.sysTabControl.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1035, 590);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabReport;
            // 
            // tabReport
            // 
            this.tabReport.AttachedControl = this.superTabControlPanel1;
            this.tabReport.GlobalItem = false;
            this.tabReport.Name = "tabReport";
            this.tabReport.Text = "报表";
            this.tabReport.Click += new System.EventHandler(this.tabReport_Click);
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1035, 590);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabProduct;
            // 
            // tabProduct
            // 
            this.tabProduct.AttachedControl = this.superTabControlPanel2;
            this.tabProduct.GlobalItem = false;
            this.tabProduct.Name = "tabProduct";
            this.tabProduct.Text = "产品";
            this.tabProduct.Click += new System.EventHandler(this.tabProduct_Click);
            // 
            // superTabControlPanel5
            // 
            this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel5.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel5.Name = "superTabControlPanel5";
            this.superTabControlPanel5.Size = new System.Drawing.Size(1002, 512);
            this.superTabControlPanel5.TabIndex = 0;
            this.superTabControlPanel5.TabItem = this.tabUser;
            // 
            // tabUser
            // 
            this.tabUser.AttachedControl = this.superTabControlPanel5;
            this.tabUser.GlobalItem = false;
            this.tabUser.Name = "tabUser";
            this.tabUser.Text = "人员";
            this.tabUser.Click += new System.EventHandler(this.tabUser_Click);
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1002, 512);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.tabFactory;
            // 
            // tabFactory
            // 
            this.tabFactory.AttachedControl = this.superTabControlPanel4;
            this.tabFactory.GlobalItem = false;
            this.tabFactory.Name = "tabFactory";
            this.tabFactory.Text = "加工厂信息";
            this.tabFactory.Click += new System.EventHandler(this.tabFactory_Click);
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 28);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1002, 512);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.tabPrice;
            // 
            // tabPrice
            // 
            this.tabPrice.AttachedControl = this.superTabControlPanel3;
            this.tabPrice.GlobalItem = false;
            this.tabPrice.Name = "tabPrice";
            this.tabPrice.Text = "酮体价格";
            this.tabPrice.Click += new System.EventHandler(this.tabPrice_Click);
            // 
            // SysManageNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 613);
            this.Controls.Add(this.sysTabControl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SysManageNewForm";
            this.Text = "系统管理";
            this.Load += new System.EventHandler(this.SysManageNewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sysTabControl)).EndInit();
            this.sysTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperTabControl sysTabControl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tabReport;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem tabFactory;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem tabPrice;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem tabProduct;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
        private DevComponents.DotNetBar.SuperTabItem tabUser;

    }
}