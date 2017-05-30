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
using Dapper_NET20;
using Microsoft.Win32;
using XmWeightForm.Weights;
using DeviceSDK;

namespace XmWeightForm
{
    public partial class MainForm : Form
    {
        //private BackgroundWorker worker = new BackgroundWorker();
        PTDevice _device;

        string previousTagId = string.Empty;
        string currentTagId = string.Empty;
        bool waitForWeighing = false;
        decimal currentWeight = decimal.Zero;

        public MainForm()
        {
            InitializeComponent();

            //worker.WorkerReportsProgress = true;
            //worker.WorkerSupportsCancellation = true;
            ////正式做事情的地方   
            //worker.DoWork += new DoWorkEventHandler(InitSerialPort);
            ////任务完称时要做的，比如提示等等   
            //worker.ProgressChanged += new ProgressChangedEventHandler(ProgessChanged);
            ////任务进行时，报告进度   
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompleteWork); 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitForm();
            InitData();
        }

        private void InitForm()
        {
            //串口信息
            //WaitCallback initPort = new WaitCallback(InitSerialPort);
            WaitCallback weightCal = new WaitCallback(DealQueueData);
            //ThreadPool.QueueUserWorkItem(initPort, "初始化串口");
            ThreadPool.QueueUserWorkItem(weightCal, "");

        }

        private void DealQueueData(object obj)
        {
            while (true) //循环检测队列
            {

                if (_dataQueue.Count >= 1) //队列中有数据
                {

                    string data = _dataQueue.Dequeue().ToString(); //将数据出队

                    // decimal weight = CalculateWeight(data);
                    UpdateWeightText(data);
                    AppNetInfo(data);
                }

                if (_hookQueue.Count >= 1)
                {
                    string tempHook = _hookQueue.Dequeue().ToString();
                    AppNetInfo(tempHook);
                }
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
        /// 钩标端口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hookSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }


        /// <summary>
        /// 初始化串口信息
        /// </summary>
        public void InitSerialPort(object state)
        {
            var weightCom = ConfigurationManager.AppSettings["weightCom"];
            var hookCom = ConfigurationManager.AppSettings["hookCom"];

            try
            {
                weightSerialPort.PortName = weightCom;
                weightSerialPort.Open();

                AppNetInfo(weightCom + "已打开");
            }
            catch (Exception ex)
            {
                AppNetInfo(weightCom + "已打开");
                AppNetInfo(ex.Message);
            }

            //try
            //{
            //    hookSerialPort.PortName = hookCom;
            //    hookSerialPort.Open();
            //    AppNetInfo(hookCom + "已打开");
            //}
            //catch (Exception ex)
            //{
            //    AppNetInfo(ex.Message);
            //}
        }

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

                if (hookSerialPort.IsOpen)
                {
                    //打开时点击，则关闭串口  
                    hookSerialPort.Close();
                    txtInfo.AppendText("com已关闭");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 信息录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            //inputForm.Show();
            //mainGroup.Controls.Clear();
            //mainGroup.Controls.Add(inputForm);
            //mainGroup.Text = "信息录入";
        }

        /// <summary>
        /// 报表统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
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



        #region 称重老代码
        /// <summary>
        /// 返回串口读取的重量
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private decimal GetWeightOfPort(string weight)
        {
            //if (string.IsNullOrEmpty(weight) || weight.IndexOf("+") < 0 || weight.Length < 8)
            //{
            //    return "0.000";
            //}
            //weight = weight.Replace("+", "");
            //weight = int.Parse(weight.Substring(0, 3)).ToString() + "." + weight.Substring(3, 3);

            if (string.IsNullOrEmpty(weight) || weight.Length < 8)
            {
                return 0.000M;
            }

            var msg = AppUtils.StringReverse(weight);

            var weightArray = msg.Split('=');

            var eletScale = new ElectronicScale();
            decimal newWeight = 0.000M;
            for (int i = 0; i < weightArray.Length; i++)
            {
                decimal tempWeight = decimal.Parse(weightArray[i]);
                eletScale.WeightDataScale(tempWeight, ref newWeight);
            }

            return newWeight;
        }


        /// <summary>
        /// 计算重量
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        private decimal CalculateWeight(string weight)
        {
            if (string.IsNullOrEmpty(weight) || weight.Length < 8)
            {
                return 0.000M;
            }

            //替换字符串中的数据
            //string tempStr = weight.ToLower().Replace("\r\n", "");
            string tempStr = weight;
            var tempArray = tempStr.Split('g');
            var weightArray = tempArray.Where(s => s != "").ToArray();
            //if (weightArray.Length == 1)
            //{
            //    return 
            //}
            var eletScale = new ElectronicScale();
            decimal newWeight = 0.000M;
            int arrLenght = weightArray.Length;
            for (int i = 0; i < arrLenght; i++)
            {
                if (newWeight > 0)
                {
                    break;
                }
                string weightItem = weightArray[i];
                if (weightItem.Contains("-") || string.IsNullOrEmpty(weightItem) || weightItem.Length < 11)
                {
                    continue;
                }

                string tempweight = weightItem.Replace("ww", "0").Replace("k", "0");
                decimal tempWeight = decimal.Parse(tempweight);

                if (arrLenght == 1)
                {
                    newWeight = decimal.Parse(tempweight);
                    break;
                }

                eletScale.WeightDataScale(tempWeight, ref newWeight);
            }

            // string newWeight=tempStr



            return newWeight;
        }


        /// <summary>
        /// 确认称重入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertWeight_Click(object sender, EventArgs e)
        {
            var text = txtSheepWeight.Text;

            var hookDt = new DataTable("Hooks");
            hookDt.Columns.Add("hookId",typeof(string));
            hookDt.Columns.Add("attachTime", typeof(DateTime));
            hookDt.Columns.Add("animalId", typeof(string));

            DataRow dr = hookDt.NewRow();
            dr["hookId"] = "999000000000058";
            dr["attachTime"] = DateTime.Now;
            dr["animalId"] = "";
            hookDt.Rows.Add(dr);

            //DynamicParameters dp = new DynamicParameters();
            //dp.Add("batchId", "20170530-01",DbType.AnsiString,ParameterDirection.Input,15);
            //dp.Add("grossWeights", 192.03, DbType.Decimal, ParameterDirection.Input, 6);
            //dp.Add("Hooks", hookDt, db.Structured, ParameterDirection.Input,null);


            //p.Add("@Password", "123456");
            //p.Add("@LoginActionType", null, DbType.Int32, ParameterDirection.ReturnValue);

            SqlParameter[] parameters =
            {
                new SqlParameter("@batchId", SqlDbType.Char),
                new SqlParameter("@grossWeights", SqlDbType.Decimal),
               new SqlParameter("@hooksToSave", SqlDbType.Structured)
            
            };

            parameters[0].Value = "20170520-02";
            parameters[1].Value = 192.16;
            parameters[2].Value = hookDt;

            int affectRow=ExecuteProcedure(connString, "SaveWeighingInfo", parameters);
            if (affectRow > 0)
            {
                AppNetInfo("入库成功");
            }
            else
            {
                AppNetInfo("入库失败");
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
        #endregion



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


            var list = new List<string>();
            list.Add("羔羊");
            list.Add("绵羊");
            list.Add("牛");
            animalSel.DataSource = list;

            var data = new BatchInput();
            try
            {
                using (var db = GetOpenConnection())
                {
                    var query = "select top 1 * from BatchInput where flag=0";
                    data = db.Query<BatchInput>(query, null).FirstOrDefault();
                }
            }
            catch
            {

            }

            if (data != null)
            {
                txtName.Text = data.hostName;
                txtIdNumber.Text = data.IdNum;
                txtTel.Text = data.tel;

                animalSel.SelectedText = data.animalType;
                BatchId = data.batchId;

                //称重状态 1-结束，0-称重中
                SwitchButtonStatus(2);
            }
            else
            {
                btnEnd.Enabled = false;
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var batckId = DateTime.Now.ToString("yyyyMMdd");
            int timeInd = int.Parse(batckId);

            var uname = txtName.Text.Trim();
            var idNum = txtIdNumber.Text.Trim();
            var userTel = txtTel.Text.Trim();

            //if (string.IsNullOrEmpty(uname))
            //{
            //    MessageBox.Show("请输入送宰人信息");
            //    return;

            //}

            //if (!ValidaterHelper.IsIDCard(idNum))
            //{
            //    MessageBox.Show("身份证号码有误");
            //    return;

            //}

            //if (!ValidaterHelper.IsMobileNum(userTel))
            //{
            //    MessageBox.Show("手机号码有误");
            //    return;

            //}


            using (var db = GetOpenConnection())
            {
                var ds = db.ExecuteDataSet("select top 1 * from BatchInput where flag=0", null, null, null, null);
                int count = ds.Tables.Count;
            }

            SwitchButtonStatus(0);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(BatchId))
            {
                var sql = "update BatchInput set flag=1 where batchId='" + BatchId + "'";

                int returnVal = 0;
                using (var db = GetOpenConnection())
                {
                    returnVal = db.Execute(sql, null);
                }

                if (returnVal > 0)
                {
                    txtName.Text = string.Empty;
                    txtIdNumber.Text = string.Empty;
                    txtTel.Text = string.Empty;
                    BatchId = string.Empty;
                    SwitchButtonStatus(1);
                }
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

        private void txtSheepWeight_TextChanged(object sender, EventArgs e)
        {
            log4netHelper.Debug(DateTime.Now.ToString() + ":" + txtSheepWeight.Text);
        }



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
        private Queue _dataQueue = new Queue();

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
        public Queue WeightQueue
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
                string tempStr = weight;
                var weightArray = tempStr.Split('g');
                AppNetInfo(weightArray[0]);
                decimal newWeight = 0.000M;
                // int arrLenght = weightArray.Length;
                string tempweight = weightArray[0].Replace("ww", "0").Replace("k", "0");
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
                    btnHook.Text = "打开";
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
                    btnWeight.Text = "打开";
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

        public Queue _hookQueue = new Queue();
        private void ShowTagId(MonitorBase oSrc, Tag oTag)
        {
            // if (waitForWeighing) return;  //忽略第二次
            if (oTag is ISO11784)
            {
                if (oTag.Id != previousTagId)
                {
                    _hookQueue.Enqueue(oTag.Id);
                    Console.Beep();
                    previousTagId = oTag.Id;

                    currentTagId = oTag.Id;
                    waitForWeighing = true;  //等待称重


                }
            }
            else
            {
                AppNetInfo("不可识别的ID: " + oTag.Id);
            }
        }
    }
}
