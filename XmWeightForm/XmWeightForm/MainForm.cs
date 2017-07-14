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
using DevComponents.DotNetBar;
using Microsoft.Win32;
using XmWeightForm.Weights;
using DeviceSDK;
using XmWeightForm.log;
using XmWeightForm.SystemManage;
using System.Data.SQLite;

namespace XmWeightForm
{
    public partial class MainForm : Office2007Form
    {
        //勾标
        private PTDevice _device;
        private string previousTagId = string.Empty;
        private string currentTagId = string.Empty;

        //去头耳号
        private PTDevice _earDevice;
        private Queue<string> _earNumQueue = new Queue<string>();

        //是否选择为溯源羊
        private bool currentTraceStatus = false;
        private AnimalBatchModel AnimalBatchModel = new AnimalBatchModel();
        private List<string> CurrentAnimalIds = new List<string>();

        // 蜂鸣器警示灯
        private System.IO.Ports.SerialPort BeepPort = new System.IO.Ports.SerialPort();

        //货物价格
        private List<AnimalTypes> animalPriceList = new List<AnimalTypes>();

        public MainForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var nowTime = DateTime.Now.Year;
            lblRight.Text = "©" + nowTime + "-无锡市富华科技有限责任公司";
            InitSerialPort();
            InitData();
        }

        /// <summary>
        /// 勾标队列
        /// </summary>
        /// <param name="obj"></param>
        private void DealQueueData(object obj)
        {
            while (true) //循环检测队列
            {
                try
                {
                    int hookCount = _hookQueue.Count(); ;
                    if (hookCount > 0)
                    {
                        string hook = _hookQueue.Dequeue(); //将数据出队
                        AppNetInfo(hook);
                        SaveHookData(hook);
                    }

                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    log4netHelper.Exception(ex);
                }

            }
        }
        private void DealEarQueueData(object obj)
        {

            while (true) //循环检测队列
            {
                try
                {
                    int hookCount = _earNumQueue.Count();
                    if (hookCount > 0)
                    {
                        string tempEar = _earNumQueue.Dequeue();
                        SaveEarNumData(tempEar);
                    }
                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                    log4netHelper.Exception(ex);
                }

            }

        }

        private void weightSerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
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
                    UpdateWeightText(weightStr);
                    UpdateLblWeightText(weightStr);
                }


            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
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
                return "0.0";
            }
            weight = weight.Replace("+", "");
            weight = int.Parse(weight.Substring(0, 5)).ToString() + "." + weight.Substring(5, 1);
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

                txtInfo.Invoke(actionDelegate, true);
            }
            else
            {
                txtInfo.Clear();
            }
        }

        /// <summary>
        /// 更新重量
        /// </summary>
        /// <param name="totalWeight"></param>
        private void UpdateLblWeightText(string totalWeight)
        {
            if (lblWeight.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    lblWeight.Text = totalWeight;
                };

                lblWeight.Invoke(actionDelegate, totalWeight);
            }
            else
            {
                lblWeight.Text = totalWeight;
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

        private void InitSerialPort()
        {
            var weightCom = ConfigurationManager.AppSettings["weightCom"];
            var hookCom = ConfigurationManager.AppSettings["hookCom"];
            var beepCom = ConfigurationManager.AppSettings["beepCom"];
            var earCom = ConfigurationManager.AppSettings["earCom"];
            try
            {
                //称重
                weightSerialPort.PortName = weightCom;
                weightSerialPort.BaudRate = 600;
                //weightSerialPort.BaudRate = 1200;
                weightSerialPort.Open();

            }
            catch (Exception ex)
            {

                AppNetInfo(ex.Message);
            }

            try
            {
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

            //耳号
            try
            {
                _earDevice = new PTDevice(earCom, string.Empty);
                if (_earDevice.Open())
                {
                    _earDevice.TTFMonitor.Start(this);
                    _earDevice.TTFMonitor.RecordNotify += ShowEarTagId;
                }
                else
                {
                    AppNetInfo("耳号感应器已连接失败");
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
            InitDataDealQueue();
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        private void CloseSerialPort()
        {
            //关闭
            this.Cursor = Cursors.WaitCursor;
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
                    _device.Close();
                    _device.Dispose();
                    _device = null;

                } //钩标
                if (_earDevice != null)
                {
                    _earDevice.Close();
                    _earDevice.Dispose();
                    _earDevice = null;

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
                log4netHelper.Exception(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 初始化数据处理线程
        /// </summary>
        private void InitDataDealQueue()
        {
            //串口信息
            WaitCallback weightCal = new WaitCallback(DealQueueData);
            WaitCallback dealEarData = new WaitCallback(DealEarQueueData);
            ThreadPool.QueueUserWorkItem(weightCal, "");
            ThreadPool.QueueUserWorkItem(dealEarData, "");
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

            if (!ValidaterHelper.IsNumberOrFloat(sheepWeigth))
            {
                MessageBox.Show("重量数据格式不正确");
                return;
            }
            decimal weightDecimal = 0;
            try
            {
                weightDecimal = decimal.Parse(sheepWeigth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重量数据格式不正确");
                return;
            }

            if (weightDecimal == 0)
            {
                MessageBox.Show("请先称重");
                return;
            }
            try
            {

                DateTime nowtime = DateTime.Now;
                DateTime beginTime = new DateTime(nowtime.Year, nowtime.Month, nowtime.Day, 0, 0, 0);
                int sTime = UnixTimSpanHelper.ConvertDateTimeToTimeSpan(beginTime);

                int isheepCount = int.Parse(sheepCount);

                string sql = "select hookId from hook where timeSpan>@sTime order by timeSpan limit @count";
                SQLiteParameter[] parameters = new SQLiteParameter[]{
                                                 new SQLiteParameter("@sTime",DbType.Int32),
                                                 new SQLiteParameter("@count",DbType.Int32)
                                         };
                parameters[0].Value = sTime;
                parameters[1].Value = isheepCount;
                var hooks = SQLiteHelper.ExcuteHookList(sql, parameters);
                if (hooks.Any())
                {
                    if (hooks.Count < isheepCount)
                    {
                        int diffCount = isheepCount - hooks.Count;
                        var nowTime = DateTime.Now;
                        for (int i = 0; i < diffCount; i++)
                        {
                            var tempTime = nowTime.AddSeconds(i);
                            hooks.Add(tempTime.ToString("yyMMddHHmmssff"));
                        }
                    }

                }
                else
                {
                    var nowTime = DateTime.Now;
                    for (int i = 0; i < isheepCount; i++)
                    {
                        var tempTime = nowTime.AddSeconds(i);
                        hooks.Add(tempTime.ToString("yyMMddHHmmssff"));
                    }
                }
                InsertWeightData(hooks, weightDecimal, hooks.Count);

            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }



        }

        private void InsertWeightData(List<string> hooks, decimal weights, int count)
        {
            try
            {
                if (hooks.Any())
                {
                    var animaltypeName = animalSel.Text;
                    var price = txtPrice.Text;
                    decimal dprice=decimal.Parse(price);

                    var hookDt = new DataTable("Hooks");
                    hookDt.Columns.Add("hookId", typeof(string));
                    hookDt.Columns.Add("attachTime", typeof(DateTime));
                    hookDt.Columns.Add("animalId", typeof(string));

                    if (currentTraceStatus)
                    {
                        GetAnimalIds(count);
                        int animalCount = CurrentAnimalIds.Count;
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
                       new SqlParameter("@hooksToSave", SqlDbType.Structured),
                       new SqlParameter("@productName", SqlDbType.VarChar),
                       new SqlParameter("@ProductPrice", SqlDbType.Decimal)
                      };

                    parameters[0].Value = BatchId;
                    parameters[1].Value = weights;
                    parameters[2].Value = hookDt;
                    parameters[3].Value = animaltypeName;
                    parameters[4].Value = dprice;

                    int affectRow = ExecuteProcedure(DapperDao.ConnectionString, "SaveWeighingInfo", parameters);

                    if (affectRow > 0)
                    {
                        if (CurrentAnimalIds.Any())
                        {
                            UpdateAnimalIdsStatus();
                        }

                        //string msg = "入库成功：数量" + count + ";毛重：" + weights + "kg";
                        //AppNetInfo(msg);
                        //UpdateWeightText("0.00");
                        UpdateSheepCountText("4");

                        UpdateWeightGrid(dprice, weights, count, hooks);
                        //BeepWarnHelper.OpenGreenLed(BeepPort);
                        //Thread.Sleep(50);
                        //BeepWarnHelper.OpenWarnBeep(BeepPort);
                        //Thread.Sleep(500);
                        //BeepWarnHelper.CloseGreedLed(BeepPort);
                        //Thread.Sleep(50);
                        //BeepWarnHelper.CloseWarnBeep(BeepPort);
                    }
                    else
                    {
                        AppNetInfo("入库失败");
                    }
                }

            }
            catch (Exception ex)
            {
                AppNetInfo("入库失败");
                log4netHelper.Exception(ex);
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
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat(
                        "select top {0} animalId from Headsoff where flag=0 and  yearNum=@yearNum and sort=@sort and animalId <>@currentAnimalId",
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
            catch (Exception ex)
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

        /// <summary>
        /// 保存勾标 20分钟内重复的不插入数据库
        /// </summary>
        /// <param name="hook"></param>
        private void SaveHookData(string hook)
        {
            try
            {
                DateTime nowtime = DateTime.Now;
                int intTime = UnixTimSpanHelper.ConvertDateTimeToTimeSpan(nowtime);
                int timeRange = intTime - 20 * 60;
                var querysql = "select count(0) from hook where hookId=@hook and timeSpan>=@timeRange";
                SQLiteParameter[] parameters = new SQLiteParameter[]{
                                                 new SQLiteParameter("@hook",DbType.String),
                                                 new SQLiteParameter("@timeRange",DbType.Int32)
                                         };
                parameters[0].Value = hook;
                parameters[1].Value = timeRange;
                var isexist = SQLiteHelper.ExecuteScalar(querysql, parameters);

                try
                {
                    int refResult = Convert.ToInt32(isexist);
                    if (refResult == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("insert into hook values('{0}',{1})", hook, intTime);
                        //log4netHelper.Info(sb.ToString());
                        var result = SQLiteHelper.ExecuteNonQuery(sb.ToString(), null);
                    }
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }

        private void SaveEarNumData(string earNum)
        {
            try
            {
                var batckId = DateTime.Now.ToString("yyyyMMdd");
                int yearNum = int.Parse(batckId);
                string yearStr = DateTime.Now.ToString("yyyyMMddHHmmss");
                SqlParameter[] parameters =
                     {
                       new SqlParameter("@earNum", SqlDbType.NVarChar),
                       new SqlParameter("@yearNum", SqlDbType.Int),
                       new SqlParameter("@yearStr", SqlDbType.NVarChar)
                      };

                parameters[0].Value = earNum;
                parameters[1].Value = yearNum;
                parameters[2].Value = yearStr;
                var result = ExecuteProcedure(DapperDao.ConnectionString, "AddEarTag", parameters);
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }


        private int _WeightGridCount = 0;
        private decimal _WeightGridGrossWeight = 0;
        private decimal _WeightGridTareWeight = 0;
        private decimal _WeightGridNetWeight = 0;
        private decimal _WeightGridTotalPrice = 0;
        /// <summary>
        /// 更新界面表格
        /// </summary>
        private void UpdateWeightGrid(decimal price,decimal GrossWeight,int hookCount,List<string> hooks)
        {

            try
            {
                string SerialNum = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string ProductName = animalSel.Text;
                //string price = txtPrice.Text;
                string name = txtName.Text.Trim();
                string idcardNum = txtIdNumber.Text.Trim();
                string idNum = name+ "-" + idcardNum;
                decimal TareWeight = hookCount * _hookWeight;
                decimal NetWeight = GrossWeight - TareWeight;
                decimal totalPrice = price * NetWeight;
                this.datagridWeight.Rows.Insert(0, 1);
                this.datagridWeight.Rows[0].Cells[0].Value = SerialNum;
                this.datagridWeight.Rows[0].Cells[1].Value = idNum;
                this.datagridWeight.Rows[0].Cells[2].Value = ProductName;
                this.datagridWeight.Rows[0].Cells[3].Value = price;
                this.datagridWeight.Rows[0].Cells[4].Value = GrossWeight;
                this.datagridWeight.Rows[0].Cells[5].Value = TareWeight;
                this.datagridWeight.Rows[0].Cells[6].Value = NetWeight;
                this.datagridWeight.Rows[0].Cells[7].Value = totalPrice;

                if (hooks.Any())
                {
                    string sql = "delete from hook where hookId in(";


                    for (int i = 0; i < hookCount; i++)
                    {
                        if (i + 1 == hookCount)
                        {
                            sql += "'" + hooks[i] + "'";
                        }
                        else
                        {
                            sql += "'" + hooks[i] + "',";
                        }

                    }

                    sql += ")";

                    SQLiteHelper.ExecuteNonQuery(sql, null);

                    using (var db = DapperDao.GetInstance())
                    {
                        string insertSql = "insert into WeightReport values(@SerialNum,@Name,@idNum,@ProductName,@price,@GrossWeight,@TareWeight,@NetWeight,@totalPrice,@time,@count)";

                        db.Execute(insertSql, new
                        {
                            SerialNum = SerialNum,
                            Name=name,
                            idNum = idcardNum,
                            ProductName = ProductName,
                            price = price,
                            GrossWeight = GrossWeight,
                            TareWeight = TareWeight,
                            NetWeight = NetWeight,
                            totalPrice = totalPrice,
                            time=DateTime.Now,
                            count = hookCount
                        });
                    }
                }


                _WeightGridGrossWeight +=GrossWeight;
                _WeightGridTareWeight +=TareWeight;
                _WeightGridNetWeight +=NetWeight;
                _WeightGridTotalPrice +=totalPrice;
                _WeightGridCount++;
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("次数：{0},总毛重：{1},总皮重：{2},总净重：{3},总价格：{4}",
                    _WeightGridCount, _WeightGridGrossWeight, _WeightGridTareWeight, _WeightGridNetWeight, _WeightGridTotalPrice);

                lblWeightGridCount.Text = sb.ToString();
                txtQupi.Text = "0.0";
                VoiceHelper.PlayVoice();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }


        }
        #region 信息录入
        /// <summary>
        /// 称重状态 1-结束，0-称重中
        /// </summary>
        public int WeghtState = 1;

        public string BatchId;
        public decimal _hookWeight = 0;
        public List<InputUserModel> inputUserList = new List<InputUserModel>();
        public List<string> SheepOriginalList = new List<string>();
        private void InitData()
        {
            var data = new BatchInput();
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    string multisql = @"select top 1 * from Batches where flag=0;
                                      select * from AnimalTypes;
                                      select distinct PIN,hostName from Batches;
                                      select top 1 hookWeight from Params;";
                    var gridreader = db.QueryMultiple(multisql, null, CommandType.Text);
                    data = gridreader.Read<BatchInput>().FirstOrDefault();
                    animalPriceList = gridreader.Read<AnimalTypes>().ToList();
                    inputUserList = gridreader.Read<InputUserModel>().ToList();
                    _hookWeight = gridreader.Read<decimal>().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
            //更新货物价格
            UpdatePriceList();
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

            if (data != null && !string.IsNullOrEmpty(data.batchId))
            {
                txtName.Text = data.hostName;
                txtIdNumber.Text = data.PIN;
                txtTel.Text = data.tel;
                cboxTrace.Checked = data.istrace;
                animalSel.SelectedValue = data.animalTypeId;
                BatchId = data.batchId;

                currentTraceStatus = data.istrace;
                if (currentTraceStatus)
                {
                    GetCurrentTraceAnimal();
                }
                //称重状态 1-结束，0-称重中
                SwitchButtonStatus(0);
                //InitDataDealQueue();
            }
            else
            {
                btnEnd.Enabled = false;
            }

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
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
                using (var db = DapperDao.GetInstance())
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
                        originalPlace = originPlace
                    });
                    BatchId = batckId + "-" + sortNum;
                }
                currentTraceStatus = istrace;

                if (currentTraceStatus)
                {
                    GetCurrentTraceAnimal();
                }
                SwitchButtonStatus(0);

                //InitDataDealQueue();
            }
            catch (Exception ex)
            {
                AppNetInfo("系统错误，请联系管理员");
                log4netHelper.Exception(ex.Message);

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
                        sql += "update Headsoff set flag=1 where animalId='" + AnimalBatchModel.animalId + "'";
                    }

                    int returnVal = 0;
                    using (var db = DapperDao.GetInstance())
                    {
                        returnVal = db.Execute(sql, new { endtime = DateTime.Now, batchId = BatchId });
                    }

                    if (returnVal > 0)
                    {
                        txtName.Text = string.Empty;
                        txtIdNumber.Text = string.Empty;
                        txtTel.Text = string.Empty;
                        BatchId = string.Empty;
                        cboxTrace.Checked = false;
                        //清楚所有变量数据
                        InitHookAndWeightData();
                        SwitchButtonStatus(1);
                        ClearNetInfo();
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
        #region 钩标

        private string previousEarTagId = string.Empty;
        private void ShowEarTagId(MonitorBase oSrc, Tag oTag)
        {

            if (oTag is ISO11784)
            {
                if (oTag.Id != previousEarTagId)
                {
                    previousEarTagId = oTag.Id;
                    _earNumQueue.Enqueue(oTag.Id);
                }
            }
            else
            {
                log4netHelper.Exception("不可识别的id:" + oTag.Id);
            }
        }
        public Queue<string> _hookQueue = new Queue<string>();
        private void ShowTagId(MonitorBase oSrc, Tag oTag)
        {
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
                log4netHelper.Info("不可识别的ID: " + oTag.Id);
            }
        }
        #endregion

        /// <summary>
        ///初始化钩标队列和称重队列相关数据
        /// </summary>
        private void InitHookAndWeightData()
        {

            // previousTagId = string.Empty;
            // currentTagId = string.Empty;

            //if (_hookQueue.Count > 0)
            //{
            //    _hookQueue.Clear();

            //}

            currentTraceStatus = false;
            AnimalBatchModel = new AnimalBatchModel();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
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

        private void UpdatePorductList()
        {
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    animalPriceList = db.Query<AnimalTypes>("select * from AnimalTypes", null).ToList();
                }

                UpdatePriceList();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

        }

        private void UpdatePriceList()
        {
            if (animalPriceList.Any())
            {
                animalSel.DisplayMember = "animalTypeName";
                animalSel.ValueMember = "animalTypeId";
                animalSel.DataSource = animalPriceList;

                var price = animalPriceList.OrderBy(s => s.animalTypeId).Select(s => s.price).FirstOrDefault();
                if (price != null)
                {
                    txtPrice.Text = price.ToString();
                }
            }
        }
        private void animalSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int animalType = (int)animalSel.SelectedValue;
            //var animaltypeName = animalSel.Text;
            var price = animalPriceList.Where(s => s.animalTypeId == animalType).Select(s => s.price).FirstOrDefault();
            if (price != null)
            {
                txtPrice.Text = price.ToString();
            }
        }


        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            var list = new List<string>();
            UpdateWeightGrid(20M, 61.2M, 4, list);
        }

        private void btnQupi_Click(object sender, EventArgs e)
        {

            var sheepWeigth = txtSheepWeight.Text.Trim();
            var sheepCount = txtSheepNum.Text.Trim();
            if (!ValidaterHelper.IsInt(sheepCount))
            {
                MessageBox.Show("请输入一个整数");
                return;
            }

            if (!ValidaterHelper.IsNumberOrFloat(sheepWeigth))
            {
                MessageBox.Show("重量数据格式不正确");
                return;
            }
            decimal weightDecimal = 0;
            try
            {
                weightDecimal = decimal.Parse(sheepWeigth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重量数据格式不正确");
                return;
            }

            if (weightDecimal == 0)
            {
                MessageBox.Show("请先称重");
                return;
            }
            int hookCount = int.Parse(sheepCount);
            decimal TareWeight = hookCount * _hookWeight;
            decimal NetWeight = weightDecimal - TareWeight;
            txtQupi.Text = NetWeight.ToString();
        }

        private void btnReportItem_Click(object sender, EventArgs e)
        {
            var reportForm = new ReportForm();
            reportForm.ShowDialog();
        }

        private void btnProductPriceItem_Click(object sender, EventArgs e)
        {
            var product = new ProductInfoNew();

            product.ShowDialog();

            if (product.DialogResult == DialogResult.OK)
            {
                UpdatePorductList();
            }
        }

        private void btnGrossWeight_Click(object sender, EventArgs e)
        {
            var weightForm=new GrossWeightForm();
           weightForm.ShowDialog();
           if (weightForm.DialogResult == DialogResult.OK)
           {
               _hookWeight = weightForm.HookWeight;
           }
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
                if (dr == DialogResult.OK) //如果点击“确定”按钮
                {
                    CloseSerialPort();

                    //this.Close();
                }
                else
                {
                    e.Cancel = true;
                }

            }
        }


    }
}
