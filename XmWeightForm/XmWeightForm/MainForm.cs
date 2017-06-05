using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppService;
using AppService.Comm;
using AppService.Model;
using CCWin;
using Dapper_NET20;
using DevComponents.DotNetBar;
using Microsoft.Win32;
using XmWeightForm.Weights;
using DeviceSDK;
using XmWeightForm.SystemManage;

namespace XmWeightForm
{
    public partial class MainForm : Office2007Form
    {
        //private BackgroundWorker worker = new BackgroundWorker();
        PTDevice _device;

        string previousTagId = string.Empty;
        string currentTagId = string.Empty;
        bool waitForWeighing = false;
        decimal currentWeight = decimal.Zero;
        public System.IO.Ports.SerialPort BeepPort = new System.IO.Ports.SerialPort();
        public MainForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // this.AcceptButton = btnStart;
            btnInsertWeight.Visible = false;
            InitForm();
            InitData();


        }

        private void InitForm()
        {

            var beepCom = ConfigurationManager.AppSettings["beepCom"];
            BeepPort.PortName = beepCom;
            BeepPort.BaudRate = 9600;
            BeepPort.DataBits = 8;
            BeepPort.StopBits = StopBits.One;
            BeepPort.Parity = Parity.None;
            //sp1.Open();
            try
            {
                BeepPort.Open();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
                AppNetInfo(ex.Message);
            }


        }
        public List<string> TempHookList = new List<string>();

        private void DealQueueData(object obj)
        {
            while (true) //循环检测队列
            {

                if (_dataQueue.Count >= 1 && _hookQueue.Count >= 1) //队列中有数据
                {
                    decimal weightdata = _dataQueue.Dequeue();
                    _dataQueue.Clear();
                    var hookList = new List<string>();
                    int hookCount = _hookQueue.Count;
                    if (hookCount >= 4)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            string hook = _hookQueue.Dequeue(); //将数据出队
                            hookList.Add(hook);
                        }
                        UpdateWeightText(weightdata.ToString());
                        InsertWeightData(hookList, weightdata, 4);

                    }
                    else
                    {
                        // Application.DoEvents();
                        //txtSheepNum.Text = hookCount.ToString();
                        UpdateWeightText(weightdata.ToString());
                        UpdateSheepCountText(hookCount.ToString());
                        for (int i = 0; i < hookCount; i++)
                        {
                            string hook = _hookQueue.Dequeue(); //将数据出队
                            TempHookList.Add(hook);
                        }
                        showWeigthButton(true);
                        BeepWarnHelper.OpenRedLed(BeepPort);
                        Thread.Sleep(50);
                        BeepWarnHelper.OpenWarnBeep(BeepPort);
                    }


                    // decimal weight = CalculateWeight(data);
                  
                    //AppNetInfo(data);
                }

                //if (_hookQueue.Count >= 1)
                //{
                //    string tempHook = _hookQueue.Dequeue().ToString();
                //    //AppNetInfo(tempHook);
                //}
                Thread.Sleep(50);
            }
        }

        /// <summary>
        /// 称重端口接口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weightSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                //如果当前称重状态为称重完成 不再接收重量数据
                if(waitForWeighing)
                    return;

                if (weightSerialPort.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了  
                {
                    string strTemp = "";
                    double iSecond = 0.5;

                    DateTime dtOld = System.DateTime.Now;
                    DateTime dtNow = System.DateTime.Now;
                    TimeSpan dtInter;
                    dtInter = dtNow - dtOld;

                    int i = weightSerialPort.BytesToRead;
                    if (i > 0)
                    {
                        try
                        {
                            strTemp = weightSerialPort.ReadExisting();
                        }
                        catch
                        { }
                        if (strTemp.ToLower().IndexOf("\r") < 0)
                        {
                            i = 0;
                        }
                        else
                        {
                            //this.Invoke(interfaceUpdataHandle, strTemp);
                        }
                    }
                    while (dtInter.TotalSeconds < iSecond && i <= 0)
                    {
                        dtNow = System.DateTime.Now;
                        dtInter = dtNow - dtOld;
                        i = weightSerialPort.BytesToRead;
                        if (i > 0)
                        {
                            try
                            {
                                strTemp += weightSerialPort.ReadExisting();
                            }
                            catch
                            { }
                            if (strTemp.ToLower().IndexOf("\r") < 0)
                            {
                                i = 0;
                            }
                            else
                            {
                                //this.Invoke(interfaceUpdataHandle, strTemp);
                            }
                        }
                    }
                    string tempStr = strTemp.ToLower().Replace("\r", string.Empty).Replace("\n", string.Empty);
                    WeightDataScale(tempStr);
                    // AppNetInfo(strTemp);
                    //log4netHelper.Debug(tempStr);
                }
                else
                {
                    MessageBox.Show("请打开某个串口", "错误提示");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "出错提示");
                //txtSend.Text = "";
            }
        }


        #region 更新数据
        private void AppNetInfo(string msg)
        {

            if (txtInfo.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    txtInfo.AppendText(msg + "\n");
                };

                txtInfo.Invoke(actionDelegate, msg);
            }
            else
            {
                txtInfo.AppendText(msg + "\n");
            }


        }

        private void showWeigthButton(bool flag)
        {
            if (btnInsertWeight.InvokeRequired)
            {
                Action<bool> actionDelegate = (x) =>
                {

                    btnInsertWeight.Visible = flag;
                };

                btnInsertWeight.Invoke(actionDelegate, flag);
            }
            else
            {
                btnInsertWeight.Visible = flag;
            }
        }
        private void UpdateSheepCountText(string sheepCount)
        {
            if (txtSheepNum.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    txtSheepNum.Text = sheepCount;
                };

                txtSheepNum.Invoke(actionDelegate, sheepCount);
            }
            else
            {
                txtSheepNum.Text = sheepCount;
            }
        }
        public void UpdateWeightText(string weight)
        {

            if (txtSheepWeight.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    txtSheepWeight.Text = weight;
                };

                txtSheepWeight.Invoke(actionDelegate, weight);
            }
            else
            {
                txtSheepWeight.Text = weight;
            }
        }

        #endregion

        /// <summary>
        /// 关闭串口
        /// </summary>
        private void CloseSerialPort()
        {
            try
            {
                if (weightSerialPort.IsOpen)
                {
                    //打开时点击，则关闭串口  
                    weightSerialPort.Close();
                    txtInfo.AppendText("com已关闭");
                }

                if (_device != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _device.Close();
                    _device.Dispose();
                    _device = null;
                    this.Cursor = Cursors.Default;

                }
            }
            catch (Exception ex)
            {
                log4netHelper.Debug(ex.Message);
            }
        }

        /// <summary>
        /// 报表统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
           // var reportForm=new ReportGridForm();
            reportForm.Show();
            ////reportForm.Show();
            //mainGroup.Controls.Clear();
            //mainGroup.Controls.Add(reportForm);
            //mainGroup.Text = "报表统计";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WeghtState == 0)
            {
                MessageBox.Show("请先完成称重再关闭程序");
                e.Cancel = true;
            }
            else
            {
                DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    //this.Close();
                    CloseSerialPort();
                }
                else//如果点击“取消”按钮
                {
                    e.Cancel = true;
                }
            }


        }

        /// <summary>
        /// 初始化数据处理线程
        /// </summary>
        private void InitDataDealQueue()
        {
            //串口信息
            WaitCallback weightCal = new WaitCallback(DealQueueData);
            ThreadPool.QueueUserWorkItem(weightCal, "");
        }
        /// <summary>
        /// 确认称重入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertWeight_Click(object sender, EventArgs e)
        {
            var sheepWeigth = txtSheepWeight.Text.Trim();
            var sheepCount = txtSheepNum.Text.Trim();
            if (!ValidaterHelper.IsInt(sheepCount))
            {
                MessageBox.Show("请输入一个整数");
                return;
            }

            decimal weightDecimal = 0;
            try
            {
                weightDecimal = decimal.Parse(sheepWeigth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("价格数据格式不正确");
                return;
            }
            BeepWarnHelper.CloseWarnBeep(BeepPort);
            Thread.Sleep(50);
            BeepWarnHelper.CloseRedLed(BeepPort);
            
            int hookCount = TempHookList.Count;
            int sheepIntCount = int.Parse(sheepCount);
            if (TempHookList.Any())
            {
                if (sheepIntCount > hookCount)
                {
                    int diffCount = sheepIntCount - hookCount;

                    for (int i = 0; i < diffCount; i++)
                    {
                        TempHookList.Add(DateTime.Now.ToString("yyMMddHHmmssfff"));
                    }
                }

                InsertWeightData(TempHookList, weightDecimal, TempHookList.Count);
                TempHookList.Clear();
                btnInsertWeight.Visible = false;
               
                
            }


        }

        private void InsertWeightData(List<string> hooks, decimal weights, int count)
        {
            try
            {
                if (hooks.Any() && weights > MinWeight)
                {
                    var hookDt = new DataTable("Hooks");
                    hookDt.Columns.Add("hookId", typeof(string));
                    hookDt.Columns.Add("attachTime", typeof(DateTime));
                    hookDt.Columns.Add("animalId", typeof(string));

                    foreach (var item in hooks)
                    {
                        DataRow dr = hookDt.NewRow();
                        dr["hookId"] = item;
                        dr["attachTime"] = DateTime.Now;
                        dr["animalId"] = "";
                        hookDt.Rows.Add(dr);
                    }

                    SqlParameter[] parameters =
                     {
                       new SqlParameter("@batchId", SqlDbType.Char),
                       new SqlParameter("@grossWeights", SqlDbType.Decimal),
                       new SqlParameter("@hooksToSave", SqlDbType.Structured)
                      };

                    parameters[0].Value = BatchId;
                    parameters[1].Value = weights;
                    parameters[2].Value = hookDt;

                    int affectRow = ExecuteProcedure(connString, "SaveWeighingInfo", parameters);
                    if (affectRow > 0)
                    {
                        string msg = "入库成功：数量" + count + ";毛重：" + weights + "kg";
                        AppNetInfo(msg);

                        BeepWarnHelper.OpenGreenLed(BeepPort);
                        Thread.Sleep(50);
                        BeepWarnHelper.OpenWarnBeep(BeepPort);
                        Thread.Sleep(500);
                        BeepWarnHelper.CloseGreedLed(BeepPort);
                        Thread.Sleep(50);
                        BeepWarnHelper.CloseWarnBeep(BeepPort);
                    }
                    else
                    {
                        AppNetInfo("入库失败");
                    }
                }

            }
            catch (Exception ex)
            {
                AppNetInfo(ex.Message);
            }
        }
        private int ExecuteProcedure(string conStr, string procName, SqlParameter[] myPar)
        {

            int affectRow = 0;
            SqlCommand sqlCmd = null;
            SqlConnection sqlCon = new SqlConnection(conStr);
            try
            {


                sqlCmd = new SqlCommand(procName, sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure; //设置调用的类型为存储过程 
                if (myPar != null)
                {
                    foreach (SqlParameter spar in myPar)
                    {
                        sqlCmd.Parameters.Add(spar);
                    }

                }
                sqlCon.Open();
                affectRow = sqlCmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
                if (sqlCmd != null)
                {
                    sqlCmd.Dispose();
                }
            }

            return affectRow;

        }




        #region 信息录入
        private static string connString = ConfigurationManager.ConnectionStrings["xlhotDbConn"].ConnectionString;
        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(connString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 称重状态 1-结束，0-称重中
        /// </summary>
        public int WeghtState = 1;

        public string BatchId;

        private void InitData()
        {
            var list = new List<AnimalTypes>();

            var data = new BatchInput();
            try
            {
                using (var db = GetOpenConnection())
                {
                    var query = "select top 1 * from Batches where flag=0";
                    data = db.Query<BatchInput>(query, null).FirstOrDefault();
                    list = db.Query<AnimalTypes>("select * from AnimalTypes", null).ToList();
                }
            }
            catch
            {

            }
            animalSel.DisplayMember = "animalTypeName";
            animalSel.ValueMember = "animalTypeId";
            animalSel.DataSource = list;

            if (data != null)
            {
                txtName.Text = data.hostName;
                txtIdNumber.Text = data.PIN;
                txtTel.Text = data.tel;

                animalSel.SelectedValue = data.animalTypeId;
                BatchId = data.batchId;
                lblCurrentPerson.Text = data.hostName;
                //称重状态 1-结束，0-称重中
                SwitchButtonStatus(0);
                InitDataDealQueue();
            }
            else
            {
                btnEnd.Enabled = false;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("按了回车键");
            //return;
            //BeepWarnHelper.OpenGreenLed(port);
            //Thread.Sleep(500);
            //BeepWarnHelper.CloseGreedLed(port);
            //Thread.Sleep(500);
            //BeepWarnHelper.OpenRedLed(port);
            //Thread.Sleep(500);
            //BeepWarnHelper.CloseRedLed(port);
            //return;
            

            var batckId = DateTime.Now.ToString("yyyyMMdd");
            int yearNum = int.Parse(batckId);

            var uname = txtName.Text.Trim();
            var idNum = txtIdNumber.Text.Trim();
            var userTel = txtTel.Text.Trim();
            int animalType = (int)animalSel.SelectedValue;
            var animaltypeName = animalSel.Text;
            if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("请输入送宰人信息");
                return;

            }

            if (!ValidaterHelper.IsIDCard(idNum))
            {
                MessageBox.Show("身份证号码有误");
                return;

            }

            if (!ValidaterHelper.IsMobileNum(userTel))
            {
                MessageBox.Show("手机号码有误");
                return;

            }

            try
            {
                using (var db = GetOpenConnection())
                {
                    var querysql = @"select top 1 sort from Batches where yearNum=@yearNum order by sort desc";

                    var sort = db.Query<int>(querysql, new { yearNum = yearNum }).FirstOrDefault();
                    sort++;
                    string sortNum = sort.ToString().PadLeft(2, '0');
                    string sql =
                        @"insert into Batches(batchId,yearNum,sort,hostName,PIN,tel,animalTypeId,animalTypeName,flag,upload,weighingBeginTime)
                               values(@batchId,@yearNum,@sort,@hostName,@IdNum,@tel,@animalType,@animalTypeName,@flag,@upload,@beginTime)";
                    db.Execute(sql, new
                    {
                        batchId = batckId + "-" + sortNum,
                        yearNum = yearNum,
                        sort = sort,
                        hostName = uname,
                        idNum = idNum,
                        tel = userTel,
                        animalType = animalType,
                        animalTypeName = animaltypeName,
                        flag = 0,
                        upload = false,
                        beginTime = DateTime.Now
                    });
                    BatchId = batckId + "-" + sortNum;
                }
                lblCurrentPerson.Text = uname;
                SwitchButtonStatus(0);

                InitDataDealQueue();
            }
            catch (Exception ex)
            {
                log4netHelper.Debug(ex.Message);
                AppNetInfo("系统错误，请联系管理员");
            }

        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(BatchId))
                {
                    var sql = "update Batches set flag=1,weighingFinishedTime=@endtime where batchId=@batchId";

                    int returnVal = 0;
                    using (var db = GetOpenConnection())
                    {
                        returnVal = db.Execute(sql, new { endtime = DateTime.Now, batchId = BatchId });
                    }

                    if (returnVal > 0)
                    {
                        txtName.Text = string.Empty;
                        txtIdNumber.Text = string.Empty;
                        txtTel.Text = string.Empty;
                        BatchId = string.Empty;
                        lblCurrentPerson.Text = string.Empty;

                        //清楚所有变量数据
                        InitHookAndWeightData();
                        SwitchButtonStatus(1);
                    }
                }


            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex.Message);
            }

        }


        /// <summary>
        /// 0-称重中，1-结束
        /// </summary>
        /// <param name="state"></param>
        private void SwitchButtonStatus(int state)
        {
            if (state == 0)
            {
                waitForWeighing = false;
                WeghtState = state;
                this.btnStart.Enabled = false;
                this.btnStart.BackColor = Color.DarkGray;
                this.btnEnd.Enabled = true;
                this.btnEnd.BackColor = Color.MediumSeaGreen;
            }
            else
            {
                WeghtState = state;
                this.btnEnd.Enabled = false;
                this.btnEnd.BackColor = Color.DarkGray;
                this.btnStart.Enabled = true;
                this.btnStart.BackColor = Color.MediumSeaGreen;
            }
        }


        #endregion


        //private void txtSheepWeight_TextChanged(object sender, EventArgs e)
        //{
        //    log4netHelper.Debug(DateTime.Now.ToString() + ":" + txtSheepWeight.Text);
        //}



        #region 称重计算

        #endregion
        #region 数据处理

        #region 称重计算参数
        /// <summary>
        /// 连续相同重量次数
        /// </summary>
        private int _sameCount = 5;
        /// <summary>
        /// 误差范围
        /// </summary>
        private decimal _errorLimit = 0.1M;
        /// <summary>
        /// 计数
        /// </summary>
        private int _readCount = 0;
        /// <summary>
        /// 上一次读数
        /// </summary>
        private decimal _lastWeight = Decimal.Zero;
        /// <summary>
        /// 最小重量起
        /// </summary>
        private decimal _minWeight = 2.5M;

        /// <summary>
        /// 重量队列，先进先出
        /// </summary>
        private Queue<decimal> _dataQueue = new Queue<decimal>();

        /// <summary>
        /// 是否有新的重物
        /// </summary>
        private bool _isChanged = true;
        /// <summary>
        /// 最小起秤重量
        /// </summary>
        public decimal MinWeight
        {
            get
            { return _minWeight; }
            set
            { _minWeight = value; }
        }
        /// <summary>
        /// 频率（连续相同重量次数,5--10）
        /// </summary>
        public int SameCount
        {
            get
            { return _sameCount; }
            set
            {
                _sameCount = value;
            }
        }
        /// <summary>
        /// 误差范围（设置为重物的最小重量）
        /// </summary>
        public decimal ErrorLimit
        {
            get
            {
                return _errorLimit;
            }
            set
            {
                _errorLimit = value;
            }
        }
        /// <summary>
        /// 接收到的重量队列
        /// </summary>
        public Queue<decimal> WeightQueue
        {
            get { return _dataQueue; }
        }
        #endregion
        private void WeightDataScale(string weight)
        {
            try
            {
                if (string.IsNullOrEmpty(weight) || weight.Length < 8)
                {
                    return;
                }

                //替换字符串中的数据
                //string tempStr = weight.ToLower().Replace("\r\n", "");
                //string tempStr = weight;
                // var weightArray = tempStr.Split('g');
                //AppNetInfo(weightArray[0]);
                decimal newWeight = 0.000M;
                // int arrLenght = weightArray.Length;
                string tempweight = weight.Replace("ww", "").Replace("kg", "0");
                decimal.TryParse(tempweight, out newWeight);


                //传进来的重量
                // decimal weight = tempweight;
                if (newWeight <= _minWeight)
                {
                    _readCount = 0;
                    _isChanged = true;
                    return;
                }

                if (Math.Abs(newWeight - _lastWeight) <= _errorLimit)
                {
                    _readCount++;
                }

                _lastWeight = newWeight;
                if (_readCount >= _sameCount && _isChanged)
                {
                    if (newWeight >= _minWeight)
                    {
                        _dataQueue.Enqueue(newWeight);
                        _readCount = 0;
                        _lastWeight = newWeight;
                        //_lastWeight = Decimal.Zero;
                        _isChanged = false;
                        AppNetInfo(newWeight.ToString());
                    }

                }
            }
            catch
            {
                //outWeight = 0.000M;
            }

        }

        #endregion

        private void btnHook_Click(object sender, EventArgs e)
        {
            var hookCom = ConfigurationManager.AppSettings["hookCom"];
            try
            {
                if (_device != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _device.Close();
                    _device.Dispose();
                    _device = null;
                    this.Cursor = Cursors.Default;
                    btnHook.Text = "连接";
                }
                else
                {
                    _device = new PTDevice(hookCom, string.Empty);
                    if (_device.Open())
                    {
                        _device.TTFMonitor.Start(this);
                        _device.TTFMonitor.RecordNotify += ShowTagId;
                        btnHook.Text = "断开";
                    }
                    else
                    {
                        AppNetInfo("钩标感应器已连接失败");
                    }
                }
            }
            catch (Exception ex)
            {
                AppNetInfo(ex.Message);
            }
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            var weightCom = ConfigurationManager.AppSettings["weightCom"];

            try
            {
                if (weightSerialPort.IsOpen)
                {
                    //weightSerialPort.PortName = weightCom;
                    weightSerialPort.Close();
                    btnWeight.Text = "连接";
                }
                else
                {
                    weightSerialPort.PortName = weightCom;
                    weightSerialPort.Open();
                    btnWeight.Text = "断开";
                }


            }
            catch (Exception ex)
            {

                AppNetInfo(ex.Message);
            }


        }

        public Queue<string> _hookQueue = new Queue<string>();
        private void ShowTagId(MonitorBase oSrc, Tag oTag)
        {
            if (waitForWeighing) return;  //如何当前状态为称重结束，不再接收钩标数据
            if (oTag is ISO11784)
            {
                if (oTag.Id != previousTagId)
                {
                    _hookQueue.Enqueue(oTag.Id);
                    //Console.Beep();
                    previousTagId = oTag.Id;

                    currentTagId = oTag.Id;
                    //   waitForWeighing = true;  //等待称重

                    AppNetInfo(currentTagId);
                }
            }
            else
            {
                AppNetInfo("不可识别的ID: " + oTag.Id);
            }
        }


        /// <summary>
        ///初始化钩标队列和称重队列相关数据
        /// </summary>
        private void InitHookAndWeightData()
        {
            waitForWeighing = true;
            previousTagId = string.Empty;
            currentTagId = string.Empty;
            if (_hookQueue.Count > 0)
            {
                _hookQueue.Clear();
                
            }
            if (_dataQueue.Count > 0)
            {
                _dataQueue.Clear();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            BeepWarnHelper.OpenRedLed(BeepPort);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BeepWarnHelper.CloseRedLed(BeepPort);
            Thread.Sleep(50);
            BeepWarnHelper.OpenGreenLed(BeepPort);
            Thread.Sleep(50);
            BeepWarnHelper.OpenWarnBeep(BeepPort);
            Thread.Sleep(500);
            BeepWarnHelper.CloseGreedLed(BeepPort);
            Thread.Sleep(50);
            BeepWarnHelper.CloseWarnBeep(BeepPort);
        }
    }
}
