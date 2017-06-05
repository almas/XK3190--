namespace XmWeightForm
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.weightSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnReport = new System.Windows.Forms.Button();
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIdNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.animalSel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.RichTextBox();
            this.txtSheepWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSheepNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnInsertWeight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnHook = new System.Windows.Forms.Button();
            this.btnWeight = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCurrentPerson = new System.Windows.Forms.Label();
            this.mainGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // weightSerialPort
            // 
            this.weightSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.weightSerialPort_DataReceived);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(163, 6);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(155, 39);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "报表统计";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // mainGroup
            // 
            this.mainGroup.Controls.Add(this.btnEnd);
            this.mainGroup.Controls.Add(this.txtTel);
            this.mainGroup.Controls.Add(this.btnStart);
            this.mainGroup.Controls.Add(this.txtName);
            this.mainGroup.Controls.Add(this.txtIdNumber);
            this.mainGroup.Controls.Add(this.label4);
            this.mainGroup.Controls.Add(this.label5);
            this.mainGroup.Controls.Add(this.label6);
            this.mainGroup.Controls.Add(this.animalSel);
            this.mainGroup.Controls.Add(this.label7);
            this.mainGroup.Location = new System.Drawing.Point(3, 98);
            this.mainGroup.Margin = new System.Windows.Forms.Padding(4);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Padding = new System.Windows.Forms.Padding(4);
            this.mainGroup.Size = new System.Drawing.Size(796, 490);
            this.mainGroup.TabIndex = 3;
            this.mainGroup.TabStop = false;
            this.mainGroup.Text = "信息录入";
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.DarkGray;
            this.btnEnd.Location = new System.Drawing.Point(391, 383);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(173, 54);
            this.btnEnd.TabIndex = 9;
            this.btnEnd.Text = "称重完成";
            this.btnEnd.UseVisualStyleBackColor = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(110, 253);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(256, 24);
            this.txtTel.TabIndex = 15;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStart.Location = new System.Drawing.Point(27, 383);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 54);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "开始称重";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(445, 51);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(268, 24);
            this.txtName.TabIndex = 14;
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Location = new System.Drawing.Point(110, 169);
            this.txtIdNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(256, 24);
            this.txtIdNumber.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "联系电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 169);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "身份证号码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 51);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "送宰人姓名";
            // 
            // animalSel
            // 
            this.animalSel.FormattingEnabled = true;
            this.animalSel.Location = new System.Drawing.Point(102, 49);
            this.animalSel.Margin = new System.Windows.Forms.Padding(4);
            this.animalSel.Name = "animalSel";
            this.animalSel.Size = new System.Drawing.Size(160, 23);
            this.animalSel.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 51);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "送宰类型";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(16, 596);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(1175, 162);
            this.txtInfo.TabIndex = 10;
            this.txtInfo.Text = "";
            // 
            // txtSheepWeight
            // 
            this.txtSheepWeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSheepWeight.Location = new System.Drawing.Point(25, 222);
            this.txtSheepWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtSheepWeight.Name = "txtSheepWeight";
            this.txtSheepWeight.Size = new System.Drawing.Size(168, 30);
            this.txtSheepWeight.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 187);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "重量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "称重数量：";
            // 
            // txtSheepNum
            // 
            this.txtSheepNum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSheepNum.Location = new System.Drawing.Point(25, 69);
            this.txtSheepNum.Margin = new System.Windows.Forms.Padding(4);
            this.txtSheepNum.Name = "txtSheepNum";
            this.txtSheepNum.Size = new System.Drawing.Size(151, 30);
            this.txtSheepNum.TabIndex = 14;
            this.txtSheepNum.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1011, 346);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "公斤";
            // 
            // btnInsertWeight
            // 
            this.btnInsertWeight.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsertWeight.Location = new System.Drawing.Point(25, 310);
            this.btnInsertWeight.Name = "btnInsertWeight";
            this.btnInsertWeight.Size = new System.Drawing.Size(151, 55);
            this.btnInsertWeight.TabIndex = 16;
            this.btnInsertWeight.Text = "称重入库";
            this.btnInsertWeight.UseVisualStyleBackColor = false;
            this.btnInsertWeight.Click += new System.EventHandler(this.btnInsertWeight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInsertWeight);
            this.groupBox1.Controls.Add(this.txtSheepNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSheepWeight);
            this.groupBox1.Location = new System.Drawing.Point(806, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 527);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "称重信息";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(200, 225);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "KG";
            // 
            // btnHook
            // 
            this.btnHook.Location = new System.Drawing.Point(621, 13);
            this.btnHook.Name = "btnHook";
            this.btnHook.Size = new System.Drawing.Size(115, 35);
            this.btnHook.TabIndex = 18;
            this.btnHook.Text = "连接";
            this.btnHook.UseVisualStyleBackColor = true;
            this.btnHook.Click += new System.EventHandler(this.btnHook_Click);
            // 
            // btnWeight
            // 
            this.btnWeight.Location = new System.Drawing.Point(964, 19);
            this.btnWeight.Name = "btnWeight";
            this.btnWeight.Size = new System.Drawing.Size(116, 36);
            this.btnWeight.TabIndex = 19;
            this.btnWeight.Text = "连接";
            this.btnWeight.UseVisualStyleBackColor = true;
            this.btnWeight.Click += new System.EventHandler(this.btnWeight_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(533, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "钩标感应器";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(906, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "称重仪";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "当前称重：";
            // 
            // lblCurrentPerson
            // 
            this.lblCurrentPerson.AutoSize = true;
            this.lblCurrentPerson.Location = new System.Drawing.Point(105, 61);
            this.lblCurrentPerson.Name = "lblCurrentPerson";
            this.lblCurrentPerson.Size = new System.Drawing.Size(0, 15);
            this.lblCurrentPerson.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 763);
            this.Controls.Add(this.lblCurrentPerson);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnWeight);
            this.Controls.Add(this.btnHook);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.mainGroup);
            this.Controls.Add(this.btnReport);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "称重系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainGroup.ResumeLayout(false);
            this.mainGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort weightSerialPort;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.GroupBox mainGroup;
        private System.Windows.Forms.RichTextBox txtInfo;
        private System.Windows.Forms.TextBox txtSheepWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSheepNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsertWeight;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox animalSel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHook;
        private System.Windows.Forms.Button btnWeight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCurrentPerson;
        private System.Windows.Forms.Label label11;
    }
}

