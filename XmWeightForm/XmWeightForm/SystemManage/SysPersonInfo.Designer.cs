namespace XmWeightForm.SystemManage
{
    partial class SysPersonInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.brnQuery = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPre = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.personGrid = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.lblCount = new DevComponents.DotNetBar.LabelX();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAdminStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobStation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.personGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(371, 20);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(69, 19);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "员工信息";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 64);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(106, 64);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(488, 64);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 21);
            this.txtName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "员工名：";
            // 
            // brnQuery
            // 
            this.brnQuery.Location = new System.Drawing.Point(661, 61);
            this.brnQuery.Name = "brnQuery";
            this.brnQuery.Size = new System.Drawing.Size(75, 23);
            this.brnQuery.TabIndex = 6;
            this.brnQuery.Text = "查询";
            this.brnQuery.UseVisualStyleBackColor = true;
            this.brnQuery.Click += new System.EventHandler(this.brnQuery_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(695, 424);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(785, 425);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(75, 23);
            this.btnPre.TabIndex = 8;
            this.btnPre.Text = "上一页";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(877, 424);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // personGrid
            // 
            this.personGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.personGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.userName,
            this.operName,
            this.password,
            this.isAdminStr,
            this.JobNumber,
            this.JobStation});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.personGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.personGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.personGrid.Location = new System.Drawing.Point(19, 93);
            this.personGrid.Name = "personGrid";
            this.personGrid.RowTemplate.Height = 23;
            this.personGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.personGrid.Size = new System.Drawing.Size(936, 328);
            this.personGrid.TabIndex = 11;
            this.personGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.personGrid_CellDoubleClick);
            // 
            // lblCount
            // 
            // 
            // 
            // 
            this.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCount.Location = new System.Drawing.Point(19, 423);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(210, 23);
            this.lblCount.TabIndex = 12;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // userName
            // 
            this.userName.DataPropertyName = "userName";
            this.userName.HeaderText = "用户名";
            this.userName.Name = "userName";
            // 
            // operName
            // 
            this.operName.DataPropertyName = "operName";
            this.operName.HeaderText = "姓名";
            this.operName.Name = "operName";
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            // 
            // isAdminStr
            // 
            this.isAdminStr.DataPropertyName = "isAdminStr";
            this.isAdminStr.HeaderText = "是否管理员";
            this.isAdminStr.Name = "isAdminStr";
            // 
            // JobNumber
            // 
            this.JobNumber.DataPropertyName = "JobNumber";
            this.JobNumber.HeaderText = "工号";
            this.JobNumber.Name = "JobNumber";
            // 
            // JobStation
            // 
            this.JobStation.DataPropertyName = "JobStation";
            this.JobStation.HeaderText = "工位";
            this.JobStation.Name = "JobStation";
            // 
            // SysPersonInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.personGrid);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.brnQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.skinLabel1);
            this.Name = "SysPersonInfo";
            this.Size = new System.Drawing.Size(1000, 580);
            this.Load += new System.EventHandler(this.SysPersonInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button brnQuery;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.Button btnNext;
        private DevComponents.DotNetBar.Controls.DataGridViewX personGrid;
        private DevComponents.DotNetBar.LabelX lblCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn userName;
        private System.Windows.Forms.DataGridViewTextBoxColumn operName;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn isAdminStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobStation;
    }
}
