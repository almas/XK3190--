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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.weightSerialPort = new System.IO.Ports.SerialPort(this.components);
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtOriginalPlace = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
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
            this.label13 = new System.Windows.Forms.Label();
            this.txtmaoWeight = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnQupi = new System.Windows.Forms.Button();
            this.txtQupi = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtSheepNum = new DevComponents.Editors.IntegerInput();
            this.label11 = new System.Windows.Forms.Label();
            this.lblRight = new CCWin.SkinControl.SkinLabel();
            this.datagridWeight = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.SerialNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SheepNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TareWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblWeight = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.lblWeightGridCount = new DevComponents.DotNetBar.LabelX();
            this.bar1 = new DevComponents.DotNetBar.Bar();
            this.btnSystem = new DevComponents.DotNetBar.ButtonItem();
            this.btnProductPriceItem = new DevComponents.DotNetBar.ButtonItem();
            this.btnGrossWeight = new DevComponents.DotNetBar.ButtonItem();
            this.btnsetHookCount = new DevComponents.DotNetBar.ButtonItem();
            this.btnReportItem = new DevComponents.DotNetBar.ButtonItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.lblWeightStable = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.mainGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSheepNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // weightSerialPort
            // 
            this.weightSerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.weightSerialPort_DataReceived);
            // 
            // mainGroup
            // 
            this.mainGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainGroup.Controls.Add(this.txtPrice);
            this.mainGroup.Controls.Add(this.label9);
            this.mainGroup.Controls.Add(this.txtOriginalPlace);
            this.mainGroup.Controls.Add(this.label8);
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
            this.mainGroup.Location = new System.Drawing.Point(3, 106);
            this.mainGroup.Margin = new System.Windows.Forms.Padding(4);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Padding = new System.Windows.Forms.Padding(4);
            this.mainGroup.Size = new System.Drawing.Size(643, 341);
            this.mainGroup.TabIndex = 3;
            this.mainGroup.TabStop = false;
            this.mainGroup.Text = "信息录入";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(408, 23);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(142, 24);
            this.txtPrice.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "货物单价";
            // 
            // txtOriginalPlace
            // 
            this.txtOriginalPlace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtOriginalPlace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.txtOriginalPlace.FormattingEnabled = true;
            this.txtOriginalPlace.Location = new System.Drawing.Point(115, 209);
            this.txtOriginalPlace.Name = "txtOriginalPlace";
            this.txtOriginalPlace.Size = new System.Drawing.Size(286, 23);
            this.txtOriginalPlace.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "羊原产地";
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            // 
            // 
            // 
            this.txtName.BackgroundStyle.Class = "TextBoxBorder";
            this.txtName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtName.ButtonDropDown.Visible = true;
            this.txtName.Location = new System.Drawing.Point(115, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 23);
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
            this.txtTel.Size = new System.Drawing.Size(286, 24);
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
            this.txtIdNumber.Size = new System.Drawing.Size(286, 24);
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
            this.animalSel.Size = new System.Drawing.Size(173, 23);
            this.animalSel.TabIndex = 9;
            this.animalSel.SelectedIndexChanged += new System.EventHandler(this.animalSel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "货物名称";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(10, 247);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(317, 81);
            this.txtInfo.TabIndex = 10;
            this.txtInfo.Text = "";
            // 
            // txtSheepWeight
            // 
            this.txtSheepWeight.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSheepWeight.Location = new System.Drawing.Point(103, 93);
            this.txtSheepWeight.Margin = new System.Windows.Forms.Padding(4);
            this.txtSheepWeight.Name = "txtSheepWeight";
            this.txtSheepWeight.Size = new System.Drawing.Size(139, 30);
            this.txtSheepWeight.TabIndex = 11;
            this.txtSheepWeight.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(33, 98);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "毛重：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "称重数量：";
            // 
            // btnInsertWeight
            // 
            this.btnInsertWeight.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnInsertWeight.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInsertWeight.Location = new System.Drawing.Point(30, 183);
            this.btnInsertWeight.Name = "btnInsertWeight";
            this.btnInsertWeight.Size = new System.Drawing.Size(126, 55);
            this.btnInsertWeight.TabIndex = 16;
            this.btnInsertWeight.Text = "保存数据";
            this.btnInsertWeight.UseVisualStyleBackColor = false;
            this.btnInsertWeight.Click += new System.EventHandler(this.btnInsertWeight_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtmaoWeight);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnQupi);
            this.groupBox1.Controls.Add(this.txtQupi);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.txtSheepNum);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnInsertWeight);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInfo);
            this.groupBox1.Controls.Add(this.txtSheepWeight);
            this.groupBox1.Location = new System.Drawing.Point(653, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 341);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "称重信息";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(258, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "公斤";
            // 
            // txtmaoWeight
            // 
            this.txtmaoWeight.Location = new System.Drawing.Point(103, 22);
            this.txtmaoWeight.Name = "txtmaoWeight";
            this.txtmaoWeight.ReadOnly = true;
            this.txtmaoWeight.Size = new System.Drawing.Size(139, 24);
            this.txtmaoWeight.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 15);
            this.label12.TabIndex = 23;
            this.label12.Text = "皮重:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(258, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "公斤";
            // 
            // btnQupi
            // 
            this.btnQupi.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnQupi.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQupi.Location = new System.Drawing.Point(181, 183);
            this.btnQupi.Name = "btnQupi";
            this.btnQupi.Size = new System.Drawing.Size(126, 55);
            this.btnQupi.TabIndex = 21;
            this.btnQupi.Text = "去皮";
            this.btnQupi.UseVisualStyleBackColor = false;
            this.btnQupi.Click += new System.EventHandler(this.btnQupi_Click);
            // 
            // txtQupi
            // 
            // 
            // 
            // 
            this.txtQupi.Border.Class = "TextBoxBorder";
            this.txtQupi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtQupi.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQupi.Location = new System.Drawing.Point(103, 134);
            this.txtQupi.Name = "txtQupi";
            this.txtQupi.PreventEnterBeep = true;
            this.txtQupi.ReadOnly = true;
            this.txtQupi.Size = new System.Drawing.Size(139, 30);
            this.txtQupi.TabIndex = 20;
            this.txtQupi.Text = "0.0";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX1.Location = new System.Drawing.Point(21, 137);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(68, 23);
            this.labelX1.TabIndex = 19;
            this.labelX1.Text = "去皮重：";
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
            this.txtSheepNum.Location = new System.Drawing.Point(103, 54);
            this.txtSheepNum.MaxValue = 10;
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
            this.label11.Location = new System.Drawing.Point(258, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "公斤";
            // 
            // lblRight
            // 
            this.lblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRight.AutoSize = true;
            this.lblRight.BackColor = System.Drawing.Color.Transparent;
            this.lblRight.BorderColor = System.Drawing.Color.White;
            this.lblRight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRight.Location = new System.Drawing.Point(772, 714);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(152, 17);
            this.lblRight.TabIndex = 27;
            this.lblRight.Text = "江苏真源网络服务有限公司";
            // 
            // datagridWeight
            // 
            this.datagridWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridWeight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridWeight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNum,
            this.IdNum,
            this.ProductName,
            this.Price,
            this.SheepNum,
            this.GrossWeight,
            this.TareWeight,
            this.NetWeight,
            this.TotalPrice,
            this.WeightTime,
            this.Id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridWeight.DefaultCellStyle = dataGridViewCellStyle1;
            this.datagridWeight.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.datagridWeight.Location = new System.Drawing.Point(3, 485);
            this.datagridWeight.Name = "datagridWeight";
            this.datagridWeight.RowTemplate.Height = 23;
            this.datagridWeight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridWeight.Size = new System.Drawing.Size(994, 226);
            this.datagridWeight.TabIndex = 30;
            // 
            // SerialNum
            // 
            this.SerialNum.DataPropertyName = "SerialNum";
            this.SerialNum.HeaderText = "编号";
            this.SerialNum.Name = "SerialNum";
            this.SerialNum.Width = 80;
            // 
            // IdNum
            // 
            this.IdNum.DataPropertyName = "IdNum";
            this.IdNum.HeaderText = "身份证";
            this.IdNum.Name = "IdNum";
            this.IdNum.Width = 200;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "货物名称";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 150;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "单价";
            this.Price.Name = "Price";
            // 
            // SheepNum
            // 
            this.SheepNum.DataPropertyName = "SheepNum";
            this.SheepNum.HeaderText = "数量";
            this.SheepNum.Name = "SheepNum";
            // 
            // GrossWeight
            // 
            this.GrossWeight.DataPropertyName = "GrossWeight";
            this.GrossWeight.HeaderText = "毛重";
            this.GrossWeight.Name = "GrossWeight";
            // 
            // TareWeight
            // 
            this.TareWeight.DataPropertyName = "TareWeight";
            this.TareWeight.HeaderText = "皮重";
            this.TareWeight.Name = "TareWeight";
            // 
            // NetWeight
            // 
            this.NetWeight.DataPropertyName = "NetWeight";
            this.NetWeight.HeaderText = "净重";
            this.NetWeight.Name = "NetWeight";
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "金额";
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.Width = 200;
            // 
            // WeightTime
            // 
            this.WeightTime.DataPropertyName = "WeightTime";
            this.WeightTime.HeaderText = "时间";
            this.WeightTime.Name = "WeightTime";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWeight.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblWeight.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWeight.Font = new System.Drawing.Font("宋体", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWeight.FontBold = true;
            this.lblWeight.ForeColor = System.Drawing.Color.Crimson;
            this.lblWeight.Location = new System.Drawing.Point(318, 28);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(320, 74);
            this.lblWeight.TabIndex = 31;
            this.lblWeight.Text = "0.0";
            this.lblWeight.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(6, 28);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 32;
            this.buttonX1.Text = "测试";
            this.buttonX1.Visible = false;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click_1);
            // 
            // lblWeightGridCount
            // 
            this.lblWeightGridCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.lblWeightGridCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWeightGridCount.FontBold = true;
            this.lblWeightGridCount.ForeColor = System.Drawing.Color.Red;
            this.lblWeightGridCount.Location = new System.Drawing.Point(3, 456);
            this.lblWeightGridCount.Name = "lblWeightGridCount";
            this.lblWeightGridCount.Size = new System.Drawing.Size(643, 23);
            this.lblWeightGridCount.TabIndex = 34;
            this.lblWeightGridCount.Text = "入库提示";
            // 
            // bar1
            // 
            this.bar1.AntiAlias = true;
            this.bar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bar1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bar1.IsMaximized = false;
            this.bar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnSystem,
            this.btnReportItem});
            this.bar1.Location = new System.Drawing.Point(0, 0);
            this.bar1.Name = "bar1";
            this.bar1.Size = new System.Drawing.Size(1002, 27);
            this.bar1.Stretch = true;
            this.bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bar1.TabIndex = 35;
            this.bar1.TabStop = false;
            this.bar1.Text = "bar1";
            // 
            // btnSystem
            // 
            this.btnSystem.Name = "btnSystem";
            this.btnSystem.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnProductPriceItem,
            this.btnGrossWeight,
            this.btnsetHookCount});
            this.btnSystem.Text = "系统管理";
            // 
            // btnProductPriceItem
            // 
            this.btnProductPriceItem.Name = "btnProductPriceItem";
            this.btnProductPriceItem.Text = "货物价格";
            this.btnProductPriceItem.Click += new System.EventHandler(this.btnProductPriceItem_Click);
            // 
            // btnGrossWeight
            // 
            this.btnGrossWeight.Name = "btnGrossWeight";
            this.btnGrossWeight.Text = "毛重";
            this.btnGrossWeight.Click += new System.EventHandler(this.btnGrossWeight_Click);
            // 
            // btnsetHookCount
            // 
            this.btnsetHookCount.Name = "btnsetHookCount";
            this.btnsetHookCount.Text = "默认数量";
            this.btnsetHookCount.Visible = false;
            this.btnsetHookCount.Click += new System.EventHandler(this.btnsetHookCount_Click);
            // 
            // btnReportItem
            // 
            this.btnReportItem.Name = "btnReportItem";
            this.btnReportItem.Text = "报表统计";
            this.btnReportItem.Click += new System.EventHandler(this.btnReportItem_Click);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(29, 57);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(89, 23);
            this.labelX2.TabIndex = 37;
            this.labelX2.Text = "稳定信号：";
            // 
            // lblWeightStable
            // 
            this.lblWeightStable.BackColor = System.Drawing.Color.Crimson;
            // 
            // 
            // 
            this.lblWeightStable.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWeightStable.Location = new System.Drawing.Point(117, 57);
            this.lblWeightStable.Name = "lblWeightStable";
            this.lblWeightStable.Size = new System.Drawing.Size(34, 23);
            this.lblWeightStable.TabIndex = 38;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(662, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "撤销";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 730);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblWeightStable);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.bar1);
            this.Controls.Add(this.lblWeightGridCount);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.datagridWeight);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainGroup);
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
            ((System.ComponentModel.ISupportInitialize)(this.datagridWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort weightSerialPort;
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
        private System.Windows.Forms.Label label11;
        private DevComponents.Editors.IntegerInput txtSheepNum;
        private System.Windows.Forms.CheckBox cboxTrace;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxDropDown txtName;
        private CCWin.SkinControl.SkinLabel lblRight;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox txtOriginalPlace;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.DataGridViewX datagridWeight;
        private DevComponents.DotNetBar.LabelX lblWeight;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX lblWeightGridCount;
        private System.Windows.Forms.Button btnQupi;
        private DevComponents.DotNetBar.Controls.TextBoxX txtQupi;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.Bar bar1;
        private DevComponents.DotNetBar.ButtonItem btnReportItem;
        private DevComponents.DotNetBar.ButtonItem btnSystem;
        private DevComponents.DotNetBar.ButtonItem btnProductPriceItem;
        private DevComponents.DotNetBar.ButtonItem btnGrossWeight;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX lblWeightStable;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtmaoWeight;
        private System.Windows.Forms.Label label12;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn SheepNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn TareWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private DevComponents.DotNetBar.ButtonItem btnsetHookCount;
    }
}

