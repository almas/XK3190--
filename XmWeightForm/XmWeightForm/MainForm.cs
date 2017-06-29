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
using XmWeightForm.log;
using XmWeightForm.SystemManage;

namespace XmWeightForm
{
    public partial class MainForm : Office2007Form
    {
        //private BackgroundWorker worker = new BackgroundWorker();
        PTDevice _device;

        string previousTagId = string.Empty;
        string currentTagId = string.Empty;
        //bool waitForWeighing = false;
        decimal currentWeight = decimal.Zero;
        private bool currentTraceStatus = false;
        public System.IO.Ports.SerialPort BeepPort = new System.IO.Ports.SerialPort();

        public AnimalBatchModel AnimalBatchModel = new AnimalBatchModel();
        public List<string> CurrentAnimalIds = new List<string>();
        //AutoSizeFormClass asc = new AutoSizeFormClass();
        public MainForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var nowTime = DateTime.Now.Year;
            lblRight.Text = "©" + nowTime + "-无锡市富华科技有限责任公司";
            //asc.controllInitializeSize(this);
            // this.AcceptButton = btnStart;
            btnInsertWeight.Visible = false;
            InitSerialPort();
            InitData();


        }


        public List<string> TempHookList = new List<string>();

        private void DealQueueData(object obj)
        {
            try
            {
                while (true) //循环检测队列
                {
                    int hookCount = _hookQueue.Count();
                    int wdataCount=_dataQueue.Count();
                    if (wdataCount >= 1 && hookCount >= 1) //队列中有数据
                    {
                        //清楚上一个称重信息
                        ClearNetInfo();
                        decimal weightdata = _dataQueue.Dequeue();
                        _dataQueue.Clear();
                        var hookList = new List<string>();

                        if (hookCount >= 4)
                        {
                            int tempInt = 0;
                            int tempHookCount = hookCount;
                            do
                            {
                                string hook = _hookQueue.Dequeue(); //将数据出队
                                tempHookCount = hookCount-1;
                                if (hookList.Exists(s => s == hook))
                                {
                                    continue;
                                }
                                hookList.Add(hook);
                                tempInt++;
                            } while (tempInt < 4 && tempHookCount > 0);

                            UpdateWeightText(weightdata.ToString());
                            InsertWeightData(hookList, weightdata, 4);

                        }
                        else
                        {
                            // Application.DoEvents();
                            //txtSheepNum.Text = hookCount.ToString();

                            for (int i = 0; i < hookCount; i++)
                            {
                                string hook = _hookQueue.Dequeue(); //将数据出队
                                if (TempHookList.Exists(s => s == hook))
                                {
                                    continue;
                                }
                                TempHookList.Add(hook);
                            }

                            //更新显示数据
                            UpdateWeightText(weightdata.ToString());
                            int tempHookCount = TempHookList.Count;
                            UpdateSheepCountText(tempHookCount.ToString());
                            UpdateLblWarnSheepCountText("请确认数量" + tempHookCount);

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
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

        }

        /// <summary>
        /// 称重端口接口数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weightSerialPort_DataReceived1(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            try
            {
                //如果当前称重状态为称重完成 不再接收重量数据
                if (WeghtState==1)
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

        private void weightSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                    //如果当前称重状态为称重完成 不再接收重量数据
                if (WeghtState == 1)
                    return;

                if (weightSerialPort.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
                {
                    string strtemp = "";
                    byte firstByte = Convert.ToByte(weightSerialPort.ReadByte());
                    if (firstByte == 0x02)
                    {
                        int bytesRead = weightSerialPort.ReadBufferSize;
                        byte[] bytesData = new byte[bytesRead];
                        byte byteData;

                        for (int i = 0; i < bytesRead - 1; i++)
                        {
                            byteData = Convert.ToByte(weightSerialPort.ReadByte());
                            if (byteData == 0x03)//结束
                            {
                                break;
                            }
                            bytesData[i] = byteData;
                        }
                        strtemp = Encoding.Default.GetString(bytesData);
                    }

                    string weightStr = GetWeightOfPort(strtemp);
                    WeightDataScale(weightStr);
                }


            }
            catch (Exception ex)
            {

            }


            //AppNetInfo(aa);
        }

        /// <summary>
        /// 返回串口读取的重量
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private string GetWeightOfPort(string weight)
        {
            // AppNetInfo(weight+"\r");
            if (string.IsNullOrEmpty(weight) || weight.IndexOf("+") < 0 || weight.Length < 6)
            {
                return "0.000";
            }
            weight = weight.Replace("+", "");
            weight = int.Parse(weight.Substring(0, 5)).ToString() + "." + weight.Substring(5,1);
           // AppNetInfo(weight);
            return weight;
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

        /// <summary>
        ///清除数据
        /// </summary>
        private void ClearNetInfo()
        {
            if (txtInfo.InvokeRequired)
            {
                Action<bool> actionDelegate = (x) =>
                {

                    txtInfo.Clear();
                };

                txtInfo.Invoke(actionDelegate,true);
            }
            else
            {
                txtInfo.Clear();
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
        private void UpdateLblWarnSheepCountText(string sheepCount)
        {
            if (lblWarnCount.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    lblWarnCount.Text = sheepCount;
                };

                lblWarnCount.Invoke(actionDelegate, sheepCount);
            }
            else
            {
                lblWarnCount.Text = sheepCount;
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
        /// 初始化串口
        /// </summary>
        //private void InitSerialPort()
        //{

        //}
        private void InitSerialPort()
        {
            var weightCom = ConfigurationManager.AppSettings["weightCom"];
            var hookCom = ConfigurationManager.AppSettings["hookCom"];
            var beepCom = ConfigurationManager.AppSettings["beepCom"];

            try
            {
                //称重
                weightSerialPort.PortName = weightCom;
                weightSerialPort.BaudRate = 600;
                weightSerialPort.Open();

                //读钩标
                _device = new PTDevice(hookCom, string.Empty);
                if (_device.Open())
                {
                    _device.TTFMonitor.Start(this);
                    _device.TTFMonitor.RecordNotify += ShowTagId;
                }
                else
                {
                    AppNetInfo("钩标感应器已连接失败");
                }
            }
            catch (Exception ex)
            {

                AppNetInfo(ex.Message);
            }

            //蜂鸣器
            BeepPort.PortName = beepCom;
            BeepPort.BaudRate = 9600;
            BeepPort.DataBits = 8;
            BeepPort.StopBits = StopBits.One;
            BeepPort.Parity = Parity.None;
            try
            {
                BeepPort.Open();
            }
            catch (Exception ex)
            {
                AppNetInfo(ex.Message);
            }

        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        private void CloseSerialPort()
        {
            //关闭
            try
            {
                //称重
                if (weightSerialPort.IsOpen)
                {
                    //打开时点击，则关闭串口
                    weightSerialPort.Close();
                }
                //钩标
                if (_device != null)
                {
                    this.Cursor = Cursors.WaitCursor;
                    _device.Close();
                    _device.Dispose();
                    _device = null;
                    this.Cursor = Cursors.Default;

                }

                //蜂鸣器
                if (BeepPort.IsOpen)
                {
                    BeepPort.Close();
                }

                //AppNetInfo("com已关闭");
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
            reportForm.ShowDialog();
            ////reportForm.Show();
            //mainGroup.Controls.Clear();
            //mainGroup.Controls.Add(reportForm);
            //mainGroup.Text = "报表统计";
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
                UpdateLblWarnSheepCountText("");
                txtSheepNum.Text = "4";

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


                    if (currentTraceStatus)
                    {
                         GetAnimalIds(count);
                        int animalCount =CurrentAnimalIds.Count;
                        int hookCount = hooks.Count;
                        for (int i = 0; i < hookCount; i++)
                        {

                            DataRow dr = hookDt.NewRow();
                            dr["hookId"] = hooks[i];
                            dr["attachTime"] = DateTime.Now;
                            try
                            {
                                if (i < animalCount)
                                {
                                    dr["animalId"] = CurrentAnimalIds[i];
                                }
                                else
                                {
                                    dr["animalId"] = "";
                                }
                            }
                            catch
                            {
                                dr["animalId"] = "";
                            }


                            hookDt.Rows.Add(dr);
                        }

                    }
                    else
                    {
                        int hookCount = hooks.Count;
                        for (int i = 0; i < hookCount; i++)
                        {

                            DataRow dr = hookDt.NewRow();
                            dr["hookId"] = hooks[i];
                            dr["attachTime"] = DateTime.Now;
                            dr["animalId"] = "";
                            hookDt.Rows.Add(dr);
                        }
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
                        if (CurrentAnimalIds.Any())
                        {
                            UpdateAnimalIdsStatus();
                        }
                        string msg = "入库成功：数量" + count + ";毛重：" + weights + "kg";
                        AppNetInfo(msg);
                        UpdateWeightText("0.00");
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
                AppNetInfo("入库失败"+ex.Message);
            }
        }

        /// <summary>
        /// 获取当前需要溯源的羊批次耳标
        /// </summary>
        /// <returns></returns>
        private void GetCurrentTraceAnimal()
        {
            try
            {
                if (currentTraceStatus)
                {
                    var yearStr = DateTime.Now.ToString("yyyyMMdd");
                    int yearNum = int.Parse(yearStr);
                    using (var db = DapperDao.GetInstance())
                    {
                        string sql =
                            "select top 1 animalId,yearNum,sort from HeadsOff where yearNum=@yearNum and animalId like '%-0' and flag=0 order by sort";
                        AnimalBatchModel = db.Query<AnimalBatchModel>(sql, new { yearNum = yearNum }).FirstOrDefault();
                    }
                }

                if (AnimalBatchModel == null)
                {
                    AnimalBatchModel = new AnimalBatchModel();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }


            //return AnimalBatchModel;
        }

        /// <summary>
        /// 获取去头批次耳标列表
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private void GetAnimalIds(int count)
        {
            CurrentAnimalIds = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(AnimalBatchModel.animalId))
                {
                    StringBuilder sb=new StringBuilder();
                    sb.AppendFormat(
                        "select top {0} animalId from Headsoff where flag=0 and  yearNum=@yearNum and sort=@sort and animalId <>@currentAnimalId and animalId not like '%-1'",
                        count);
                    using (var db = DapperDao.GetInstance())
                    {
                        var sql = sb.ToString();
                        CurrentAnimalIds =
                            db.Query<string>(sql,
                                new
                                {
                                    yearNum = AnimalBatchModel.yearNum,
                                    sort = AnimalBatchModel.sort,
                                    currentAnimalId = AnimalBatchModel.animalId
                                }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
              log4netHelper.Exception(ex);
            }


            //return list;
        }
        /// <summary>
        /// 更新id状态
        /// </summary>
        private void UpdateAnimalIdsStatus()
        {
            try
            {
                    if (CurrentAnimalIds.Any())
                    {
                        var anids = CurrentAnimalIds.ToArray();
                        using (var db = DapperDao.GetInstance())
                        {
                            var upRows = db.Execute("update Headsoff set flag=1 where animalId in @ids", new { ids = anids });
                        }

                        CurrentAnimalIds = new List<string>();
                    }

            }
            catch(Exception ex)
            {
                log4netHelper.Exception(ex);
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
        public string GlobalUploadUrl = string.Empty;
        public List<InputUserModel> inputUserList = new List<InputUserModel>();
        public List<string> SheepOriginalList = new List<string>();
        private void InitData()
        {
            var list = new List<AnimalTypes>();

            var data = new BatchInput();
            //  var inputUserList=new List<InputUserModel>();
            try
            {
                using (var db = GetOpenConnection())
                {
                    // var query = "select top 1 * from Batches where flag=0";
                    // data = db.Query<BatchInput>(query, null).FirstOrDefault();
                    // list = db.Query<AnimalTypes>("select * from AnimalTypes", null).ToList();

                    string multisql = @"select top 1 * from Batches where flag=0;
                                      select * from AnimalTypes;
                                      select distinct PIN,hostName from Batches;
                                      select distinct originalPlace from Batches where originalPlace is not null;
                                       select top 1 serverUrl from Params where factoryId='047901';";
                    var gridreader = db.QueryMultiple(multisql, null, CommandType.Text);
                    data = gridreader.Read<BatchInput>().FirstOrDefault();
                    list = gridreader.Read<AnimalTypes>().ToList();
                    inputUserList = gridreader.Read<InputUserModel>().ToList();
                    SheepOriginalList = gridreader.Read<string>().ToList();
                    GlobalUploadUrl = gridreader.Read<string>().FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                log4netHelper.Exception(ex);
            }
            animalSel.DisplayMember = "animalTypeName";
            animalSel.ValueMember = "animalTypeId";
            animalSel.DataSource = list;

            //送宰人自动选择
            if (inputUserList.Any())
            {
                var tempUser = inputUserList.Select(s => s.hostName).ToArray();
                var autoList = new AutoCompleteStringCollection();
                autoList.AddRange(tempUser);
                txtName.AutoCompleteCustomSource = autoList;
            }
            if (SheepOriginalList.Count == 0 || !SheepOriginalList.Contains("锡林"))
            {
                SheepOriginalList.Insert(0, "锡林郭勒盟");
            }

            txtOriginalPlace.DataSource = SheepOriginalList;

            if (data != null&&!string.IsNullOrEmpty(data.batchId))
            {
                txtName.Text = data.hostName;
                txtIdNumber.Text = data.PIN;
                txtTel.Text = data.tel;
                cboxTrace.Checked = data.istrace;
                animalSel.SelectedValue = data.animalTypeId;
                lblCurrentPerson.Text = data.hostName;
                BatchId = data.batchId;

                currentTraceStatus = data.istrace;
                if (currentTraceStatus)
                {
                    GetCurrentTraceAnimal();
                }
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
            var istrace = cboxTrace.Checked;
            string originPlace = txtOriginalPlace.Text;
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

            if (!string.IsNullOrEmpty(userTel))
            {
                var mobileValidate = ValidaterHelper.IsMobileNum(userTel);
                if (!mobileValidate)
                {
                    MessageBox.Show("手机号码有误");
                    return;
                }

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
                        @"insert into Batches(batchId,yearNum,sort,hostName,PIN,tel,animalTypeId,animalTypeName,flag,upload,weighingBeginTime,istrace,originalPlace)
                               values(@batchId,@yearNum,@sort,@hostName,@IdNum,@tel,@animalType,@animalTypeName,@flag,@upload,@beginTime,@istrace,@originalPlace)";
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
                        beginTime = DateTime.Now,
                        istrace = istrace,
                        originalPlace=originPlace
                    });
                    BatchId = batckId + "-" + sortNum;
                }
                currentTraceStatus = istrace;
                if (currentTraceStatus)
                {
                    GetCurrentTraceAnimal();
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
            DialogResult dr = MessageBox.Show("确认该批次称重完成?", "称重提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.Cancel) //如果点击“确定”按钮
            {
               return;
            }
            try
            {
                if (!string.IsNullOrEmpty(BatchId))
                {
                    var sql = "update Batches set flag=1,weighingFinishedTime=@endtime where batchId=@batchId;";

                    if (currentTraceStatus && !string.IsNullOrEmpty(AnimalBatchModel.animalId))
                    {
                        sql += "update Headsoff set flag=1 where animalId='" + AnimalBatchModel.animalId+"'";
                    }

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
                        cboxTrace.Checked = false;
                        //清楚所有变量数据
                        InitHookAndWeightData();
                        SwitchButtonStatus(1);
                    }
                }


            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex.Message);
                MessageBox.Show("系统错误,请联系管理员");
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
                //waitForWeighing = false;
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
        private int _sameCount = 7;
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
                if (string.IsNullOrEmpty(weight))
                {
                    return;
                }
                //if (string.IsNullOrEmpty(weight) || weight.Length < 8)
                //{
                //    return;
                //}

                //替换字符串中的数据
                //string tempStr = weight.ToLower().Replace("\r\n", "");
                //string tempStr = weight;
                // var weightArray = tempStr.Split('g');
                //AppNetInfo(weightArray[0]);
                decimal newWeight = 0.000M;
                // int arrLenght = weightArray.Length;
                //string tempweight = weight.Replace("ww", "").Replace("kg", "0");
                decimal.TryParse(weight, out newWeight);


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
                       // AppNetInfo(newWeight.ToString());
                    }

                }
            }
            catch(Exception ex)
            {
                log4netHelper.Exception(ex);
                //outWeight = 0.000M;
            }

        }

        #endregion

        #region 钩标

        public Queue<string> _hookQueue = new Queue<string>();
        private void ShowTagId(MonitorBase oSrc, Tag oTag)
        {
            if (WeghtState==1) return;  //如何当前状态为称重结束 或者还未开始称重，不再接收钩标数据
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
        #endregion

        /// <summary>
        ///初始化钩标队列和称重队列相关数据
        /// </summary>
        private void InitHookAndWeightData()
        {
            //waitForWeighing = true;
            previousTagId = string.Empty;
            currentTagId = string.Empty;
            currentTraceStatus = false;
            if (_hookQueue.Count > 0)
            {
                _hookQueue.Clear();

            }
            if (_dataQueue.Count > 0)
            {
                _dataQueue.Clear();
            }

            AnimalBatchModel = new AnimalBatchModel();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //Thread.Sleep(500);
            var name = txtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                if (inputUserList.Any())
                {
                    var tempData = inputUserList.Where(s => s.hostName == name).Select(s => s.PIN).FirstOrDefault();
                    if (tempData != null)
                    {
                        txtIdNumber.Text = tempData.Trim();
                    }
                }

            }
            else
            {
                txtIdNumber.Text = string.Empty;
            }

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (var db = DapperDao.GetInstance())
        //    {
        //      var list=new List<string>();

        //      list.Add("900002660010015");
        //      list.Add("900002660010016");
        //      list.Add("900002660010017");
        //        if (list.Any())
        //        {
        //            var anids = list.ToArray();
        //            var upRows = db.Execute("update Headsoff set flag=1 where animalId in @ids", new { ids = anids });

        //        }
        //    }
        //}


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {



        }
        private System.Threading.Thread updateThread = null;
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            if (WeghtState == 0)
            {
                MessageBox.Show("请先完成称重再关闭程序");
                return;
            }
            else
            {

                DialogResult dr = MessageBox.Show("确定要退出吗?", "退出系统", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK) //如果点击“确定”按钮
                {
                    CloseSerialPort();
                    //CloseAndUploadData();
                    this.Close();
                }

            }

        }

        private void CloseAndUploadData()
        {
            updateThread = new System.Threading.Thread(new System.Threading.ThreadStart(ShowProcessWin));
            updateThread.Start();
            //this.Close();
            lblUploadInfo.Visible = true;
            uploadProcess.IsRunning = true;
            this.uploadProcess.Enabled = true;
            this.uploadProcess.Visible = true;
            btnStart.Visible = false;
            btnEnd.Visible = false;
            txtName.Enabled = false;
        }
        private void ShowProcessWin()
        {
            try
            {

                //string url = string.Empty;

                //using (var db=DapperDao.GetInstance())
                //{
                //    url =
                //        db.Query<string>("select top 1 serverUrl from Params where factoryId=@facid",
                //            new {facid = "047901"}).FirstOrDefault();
                //}

                //var updata = new UploadWeightData(GlobalUploadUrl);
                //updata.UploadHeadsoff();
                //updata.UploadBatchs();
                //updata.UploadWeighings();
                //updata.UploadPreDeAcid();
                //updata.UploadPostDeAcid();
                //updata.UploadCuttings();
                Application.Exit();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

        }

        private void CloseProcessWin()
        {
            try
            {
                lblUploadInfo.Visible = false;
                uploadProcess.IsRunning = false;
                this.uploadProcess.Enabled = false;
                this.uploadProcess.Visible = false;
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
                //MessageBox.Show(ex.Message);
            }
        }
        bool fullscreen = false;
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            fullscreen = !fullscreen;//循环。点一次全屏，再点还原。
            //SetFullScreen(fullscreen, ref rect);
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;//全屏
            }
            else
            {
                this.WindowState = FormWindowState.Normal;//还原
            }
        }
    }
}
