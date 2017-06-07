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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.weightSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.btnReport = new System.Windows.Forms.Button();
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtName = new DevComponents.DotNetBar.Controls.TextBoxDropDown();
            this.cboxTrace = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnd = new System.Windows.Forms.Button();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.btnInsertWeight = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSheepNum = new DevComponents.Editors.IntegerInput();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCurrentPerson = new DevComponents.DotNetBar.LabelX();
            this.btnCloseForm = new DevComponents.DotNetBar.ButtonX();
            this.uploadProcess = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.lblUploadInfo = new DevComponents.DotNetBar.LabelX();
            this.mainGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheepNum)).BeginInit();
            this.SuspendLayout();
            // 
            // weightSerialPort
            // 
            this.weightSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.weightSerialPort_DataReceived);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(11, 10);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(110, 31);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "报表统计";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // mainGroup
            // 
            this.mainGroup.Controls.Add(this.button1);
            this.mainGroup.Controls.Add(this.txtName);
            this.mainGroup.Controls.Add(this.cboxTrace);
            this.mainGroup.Controls.Add(this.label3);
            this.mainGroup.Controls.Add(this.btnEnd);
            this.mainGroup.Controls.Add(this.txtTel);
            this.mainGroup.Controls.Add(this.btnStart);
            this.mainGroup.Controls.Add(this.txtIdNumber);
            this.mainGroup.Controls.Add(this.label4);
            this.mainGroup.Controls.Add(this.label5);
            this.mainGroup.Controls.Add(this.label6);
            this.mainGroup.Controls.Add(this.animalSel);
            this.mainGroup.Controls.Add(this.label7);
            this.mainGroup.Location = new System.Drawing.Point(3, 88);
            this.mainGroup.Margin = new System.Windows.Forms.Padding(4);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Padding = new System.Windows.Forms.Padding(4);
            this.mainGroup.Size = new System.Drawing.Size(665, 365);
            this.mainGroup.TabIndex = 3;
            this.mainGroup.TabStop = false;
            this.mainGroup.Text = "信息录入";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtName.BackgroundStyle.Class = "TextBoxBorder";
            this.txtName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.ButtonDropDown.Visible = true;
            this.txtName.Location = new System.Drawing.Point(115, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(252, 23);
            this.txtName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.txtName.TabIndex = 18;
            this.txtName.Text = "";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cboxTrace
            // 
            this.cboxTrace.AutoSize = true;
            this.cboxTrace.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboxTrace.Location = new System.Drawing.Point(115, 56);
            this.cboxTrace.Name = "cboxTrace";
            this.cboxTrace.Size = new System.Drawing.Size(45, 22);
            this.cboxTrace.TabIndex = 17;
            this.cboxTrace.Text = "是";
            this.cboxTrace.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "是否溯源";
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.DarkGray;
            this.btnEnd.Location = new System.Drawing.Point(390, 249);
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
            this.txtTel.Location = new System.Drawing.Point(115, 163);
            this.txtTel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(252, 24);
            this.txtTel.TabIndex = 15;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStart.Location = new System.Drawing.Point(26, 249);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(173, 54);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "开始称重";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtIdNumber
            // 
            this.txtIdNumber.Location = new System.Drawing.Point(115, 123);
            this.txtIdNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdNumber.Name = "txtIdNumber";
            this.txtIdNumber.Size = new System.Drawing.Size(252, 24);
            this.txtIdNumber.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "联系电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 125);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "身份证号码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "送宰人姓名";
            // 
            // animalSel
            // 
            this.animalSel.FormattingEnabled = true;
            this.animalSel.Location = new System.Drawing.Point(115, 24);
            this.animalSel.Margin = new System.Windows.Forms.Padding(4);
            this.animalSel.Name = "animalSel";
            this.animalSel.Size = new System.Drawing.Size(160, 23);
            this.animalSel.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "送宰类型";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(3, 471);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(955, 109);
            this.txtInfo.TabIndex = 10;
            this.txtInfo.Text = "";
            // 
            // txtSheepWeight
            // 
            this.txtSheepWeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSheepWeight.Location = new System.Drawing.Point(27, 160);
            this.txtSheepWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtSheepWeight.Name = "txtSheepWeight";
            this.txtSheepWeight.Size = new System.Drawing.Size(168, 30);
            this.txtSheepWeight.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 125);
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
            this.label2.Location = new System.Drawing.Point(24, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "称重数量：";
            // 
            // btnInsertWeight
            // 
            this.btnInsertWeight.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsertWeight.Location = new System.Drawing.Point(27, 234);
            this.btnInsertWeight.Name = "btnInsertWeight";
            this.btnInsertWeight.Size = new System.Drawing.Size(151, 55);
            this.btnInsertWeight.TabIndex = 16;
            this.btnInsertWeight.Text = "称重入库";
            this.btnInsertWeight.UseVisualStyleBackColor = false;
            this.btnInsertWeight.Click += new System.EventHandler(this.btnInsertWeight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSheepNum);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInsertWeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSheepWeight);
            this.groupBox1.Location = new System.Drawing.Point(675, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 365);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "称重信息";
            // 
            // txtSheepNum
            // 
            // 
            // 
            // 
            this.txtSheepNum.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtSheepNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSheepNum.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtSheepNum.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSheepNum.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left;
            this.txtSheepNum.Location = new System.Drawing.Point(26, 69);
            this.txtSheepNum.MaxValue = 4;
            this.txtSheepNum.MinValue = 1;
            this.txtSheepNum.Name = "txtSheepNum";
            this.txtSheepNum.ShowUpDown = true;
            this.txtSheepNum.Size = new System.Drawing.Size(106, 30);
            this.txtSheepNum.TabIndex = 18;
            this.txtSheepNum.Value = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(202, 163);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "KG";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 15);
            this.label10.TabIndex = 22;
            this.label10.Text = "当前称重：";
            // 
            // lblCurrentPerson
            // 
            // 
            // 
            // 
            this.lblCurrentPerson.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentPerson.Location = new System.Drawing.Point(99, 49);
            this.lblCurrentPerson.Name = "lblCurrentPerson";
            this.lblCurrentPerson.Size = new System.Drawing.Size(271, 23);
            this.lblCurrentPerson.TabIndex = 23;
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCloseForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseForm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCloseForm.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCloseForm.Location = new System.Drawing.Point(881, 4);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCloseForm.Size = new System.Drawing.Size(87, 37);
            this.btnCloseForm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCloseForm.TabIndex = 24;
            this.btnCloseForm.Text = "关闭窗口";
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // uploadProcess
            // 
            // 
            // 
            // 
            this.uploadProcess.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.uploadProcess.Location = new System.Drawing.Point(293, 23);
            this.uploadProcess.Name = "uploadProcess";
            this.uploadProcess.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot;
            this.uploadProcess.Size = new System.Drawing.Size(154, 58);
            this.uploadProcess.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.uploadProcess.TabIndex = 26;
            this.uploadProcess.Visible = false;
            // 
            // lblUploadInfo
            // 
            // 
            // 
            // 
            this.lblUploadInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUploadInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUploadInfo.Location = new System.Drawing.Point(453, 34);
            this.lblUploadInfo.Name = "lblUploadInfo";
            this.lblUploadInfo.Size = new System.Drawing.Size(164, 42);
            this.lblUploadInfo.TabIndex = 25;
            this.lblUploadInfo.Text = "数据上传中,请稍后...";
            this.lblUploadInfo.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 583);
            this.ControlBox = false;
            this.Controls.Add(this.uploadProcess);
            this.Controls.Add(this.lblUploadInfo);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblCurrentPerson);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.mainGroup);
            this.Controls.Add(this.btnReport);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "称重系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainGroup.ResumeLayout(false);
            this.mainGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheepNum)).EndInit();
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
        private System.Windows.Forms.Button btnInsertWeight;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtIdNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox animalSel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevComponents.Editors.IntegerInput txtSheepNum;
        private System.Windows.Forms.CheckBox cboxTrace;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown txtName;
        private System.Windows.Forms.Button button1;
        private DevComponents.DotNetBar.LabelX lblCurrentPerson;
        private DevComponents.DotNetBar.ButtonX btnCloseForm;
        private DevComponents.DotNetBar.Controls.CircularProgress uploadProcess;
        private DevComponents.DotNetBar.LabelX lblUploadInfo;
    }
}

