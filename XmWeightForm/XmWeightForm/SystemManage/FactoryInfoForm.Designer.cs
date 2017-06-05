namespace XmWeightForm.SystemManage
{
    partial class FactoryInfoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFactoryNum = new System.Windows.Forms.TextBox();
            this.txtFactoryName = new System.Windows.Forms.TextBox();
            this.txtHook = new System.Windows.Forms.TextBox();
            this.txtmeatRate = new System.Windows.Forms.TextBox();
            this.txtextraRate = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTraceUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "加工厂编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "加工厂名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "皮重";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "出肉率";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "耗损率";
            // 
            // txtFactoryNum
            // 
            this.txtFactoryNum.Location = new System.Drawing.Point(170, 19);
            this.txtFactoryNum.Name = "txtFactoryNum";
            this.txtFactoryNum.Size = new System.Drawing.Size(245, 21);
            this.txtFactoryNum.TabIndex = 5;
            // 
            // txtFactoryName
            // 
            this.txtFactoryName.Location = new System.Drawing.Point(170, 58);
            this.txtFactoryName.Name = "txtFactoryName";
            this.txtFactoryName.Size = new System.Drawing.Size(245, 21);
            this.txtFactoryName.TabIndex = 6;
            // 
            // txtHook
            // 
            this.txtHook.Location = new System.Drawing.Point(170, 108);
            this.txtHook.Name = "txtHook";
            this.txtHook.Size = new System.Drawing.Size(245, 21);
            this.txtHook.TabIndex = 7;
            // 
            // txtmeatRate
            // 
            this.txtmeatRate.Location = new System.Drawing.Point(170, 150);
            this.txtmeatRate.Name = "txtmeatRate";
            this.txtmeatRate.Size = new System.Drawing.Size(245, 21);
            this.txtmeatRate.TabIndex = 8;
            // 
            // txtextraRate
            // 
            this.txtextraRate.Location = new System.Drawing.Point(170, 196);
            this.txtextraRate.Name = "txtextraRate";
            this.txtextraRate.Size = new System.Drawing.Size(245, 21);
            this.txtextraRate.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(78, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "溯源网址";
            // 
            // txtTraceUrl
            // 
            this.txtTraceUrl.Location = new System.Drawing.Point(170, 245);
            this.txtTraceUrl.Name = "txtTraceUrl";
            this.txtTraceUrl.Size = new System.Drawing.Size(245, 21);
            this.txtTraceUrl.TabIndex = 13;
            // 
            // FactoryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 360);
            this.Controls.Add(this.txtTraceUrl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtextraRate);
            this.Controls.Add(this.txtmeatRate);
            this.Controls.Add(this.txtHook);
            this.Controls.Add(this.txtFactoryName);
            this.Controls.Add(this.txtFactoryNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "FactoryInfoForm";
            this.Text = "加工厂信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFactoryNum;
        private System.Windows.Forms.TextBox txtFactoryName;
        private System.Windows.Forms.TextBox txtHook;
        private System.Windows.Forms.TextBox txtmeatRate;
        private System.Windows.Forms.TextBox txtextraRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTraceUrl;
    }
}