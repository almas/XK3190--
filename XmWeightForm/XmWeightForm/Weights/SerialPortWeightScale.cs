using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace XmWeightForm.Weights
{
    public class SerialPortWeightScale
    {

        /// <summary>
        /// 接收事件是否有效 false表示有效
        /// </summary>
        public bool ReceiveEventFlag = false;
        /// <summary>
        /// 结束符比特
        /// </summary>
        public byte EndByte = 0x23;//string End = "#";
        /// <summary>
        /// 完整协议的记录处理事件
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        public event SerialErrorReceivedEventHandler Error;

        #region 变量属性
        private string _portName = "COM1";//串口号，默认COM1
        private SerialPortBaudRates _baudRate = SerialPortBaudRates.BaudRate_57600;//波特率
        private Parity _parity = Parity.None;//校验位
        private StopBits _stopBits = StopBits.One;//停止位
        private SerialPortDatabits _dataBits = SerialPortDatabits.EightBits;//数据位

        private SerialPort comPort = new SerialPort();

        /// <summary>
        /// 串口号
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// 波特率
        /// </summary>
        public SerialPortBaudRates BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// 奇偶校验位
        /// </summary>
        public Parity Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// 数据位
        /// </summary>
        public SerialPortDatabits DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// 停止位
        /// </summary>
        public StopBits StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        #endregion
         #region 构造函数

        /// <summary>
        /// 参数构造函数（使用枚举参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortWeightScale(string name, SerialPortBaudRates baud, Parity par, SerialPortDatabits dBits, StopBits sBits)
        {
            _portName = name;
            _baudRate = baud;
            _parity = par;
            _dataBits = dBits;
            _stopBits = sBits;

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        /// <summary>
        /// 参数构造函数（使用字符串参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortWeightScale(string name, string baud, string par, string dBits, string sBits)
        {
            _portName = name;
            _baudRate = (SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), baud);
            _parity = (Parity)Enum.Parse(typeof(Parity), par);
            _dataBits = (SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), dBits);
            _stopBits = (StopBits)Enum.Parse(typeof(StopBits), sBits);

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SerialPortWeightScale()
        {
            _portName = "COM3";
            _baudRate = SerialPortBaudRates.BaudRate_9600;
            _parity = Parity.None;
            _dataBits = SerialPortDatabits.EightBits;
            _stopBits = StopBits.One;

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        } 

	    #endregion

        /// <summary>
        /// 端口是否已经打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return comPort.IsOpen;
            }
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        public void OpenPort()
        {
            if (comPort.IsOpen) comPort.Close();

            comPort.PortName = _portName;
            comPort.BaudRate = (int)_baudRate;
            comPort.Parity = _parity;
            comPort.DataBits = (int)_dataBits;
            comPort.StopBits = _stopBits;

            comPort.Open();
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            if (comPort.IsOpen) comPort.Close();
        }

        /// <summary>
        /// 丢弃来自串行驱动程序的接收和发送缓冲区的数据
        /// </summary>
        public void DiscardBuffer()
        {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
        }


       #region 称重计算参数
        /// <summary>
        /// 连续相同重量次数
        /// </summary>
        private int _sameCount = 10;
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

        #region 数据处理
        //public event DataReceivedEventHandler DataWatchEvent; 
        /// <summary>
        /// 数据接收处理
        /// </summary>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string strTemp = "";
            double iSecond = 0.5;

            DateTime dtOld = System.DateTime.Now;
            DateTime dtNow = System.DateTime.Now;
            TimeSpan dtInter;
            dtInter = dtNow - dtOld;

            int i = comPort.BytesToRead;
            if (i > 0)
            {
                try
                {
                    strTemp = comPort.ReadExisting();
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
                i = comPort.BytesToRead;
                if (i > 0)
                {
                    try
                    {
                        strTemp += comPort.ReadExisting();
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
            decimal outweight= WeightDataScale(tempStr);
            if (DataReceived != null)
            {
                DataReceived(new DataReceivedEventArgs(outweight));
            }
        }


        //public void OnDataCalculate(object sender, WeightEventArgs e)
        //{
        //    try
        //    {
        //        decimal weight = e.Weight;
        //        if (weight <= _minWeight)
        //        {
        //            _readCount = 0;
        //            _isChanged = true;
        //        }
        //        if (Math.Abs(weight - _lastWeight) <= _errorLimit)
        //        {
        //            //连续在误差范围里，就开始计数
        //            _readCount++;
        //        }
        //        _lastWeight = weight;
        //        if (_readCount >= _sameCount && _isChanged)
        //        {
        //            if (weight <= _minWeight)
        //                return;
        //            _dataQueue.Enqueue(weight);
        //            _lastWeight = weight;
        //            _isChanged = false;
        //        }
        //        //string recevieData = _serialPort.ReadExisting();
        //        //string logData=DateTime.Now.ToString("hh:mm:ss")+":"+recevieData;
        //        //if (_dataQueue.Count > 0)
        //        //{
        //        //    InvokeRichText.Log(this.richTextBox1, LogMsgType.Receiving, _dataQueue.Dequeue().ToString() + "\r\n");
        //        //}
        //    }
        //    catch
        //    {
        //    }
        //}

        private decimal WeightDataScale(string weight)
        {
            try
            {
                if (string.IsNullOrEmpty(weight) || weight.Length < 8)
                {
                    return 0.00M;
                }

                //替换字符串中的数据
                //string tempStr = weight.ToLower().Replace("\r\n", "");
                string tempStr = weight;
                var weightArray = tempStr.Split('g');

                decimal newWeight = 0.000M;
               // int arrLenght = weightArray.Length;
                decimal.TryParse(weightArray[0],out newWeight);
                //for (int i = 0; i < arrLenght; i++)
                //{
                //    if (newWeight > 0)
                //    {
                //        break;
                //    }
                //    string weightItem = weightArray[i];
                //    if (weightItem.Contains("-") || string.IsNullOrEmpty(weightItem) || weightItem.Length < 11)
                //    {
                //        continue;
                //    }

                //    string tempweight = weightItem.Replace("ww", "0").Replace("k", "0");
                //    decimal tempWeight = decimal.Parse(tempweight);

                //    if (arrLenght == 1)
                //    {
                //        newWeight = decimal.Parse(tempweight);
                //        break;
                //    }

                //    //eletScale.WeightDataScale(tempWeight, ref newWeight);
                //}

                //传进来的重量
               // decimal weight = tempweight;

                if (_lastWeight != Decimal.Zero)
                {
                    if (Math.Abs(newWeight - _lastWeight) <= _errorLimit)
                    {
                        _readCount++;
                    }
                }
                if (newWeight <= _minWeight)
                {
                    _readCount = 0;
                    _isChanged = true;
                }


                _lastWeight = newWeight;
                if (_readCount >= _sameCount && _isChanged)
                {
                    if (newWeight >= _minWeight)
                    {
                        //_dataQueue.Enqueue(newWeight);
                       _lastWeight = newWeight;
                        _isChanged = false;
                       // outWeight = newWeight;
                        _readCount = 0;
                        return newWeight;
                    }
                    // return weight;
                }

                //if (_dataQueue.Count >= _sameCount && _isChanged)
                //{
                //    //outWeight = (decimal)_dataQueue.ToArray()[0];

                //    _dataQueue.Clear();
                //    _readCount = 0;
                //    _lastWeight = 0.000M;
                //}
            }
            catch
            {
                //outWeight = 0.000M;
            }
            return 0.000M;
        }
        /// <summary>
        /// 错误处理函数
        /// </summary>
        void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (Error != null)
            {
                Error(sender, e);
            }
        }

              #endregion
    }

    public class DataReceivedEventArgs : EventArgs
    {
        public decimal DataReceived;
        public DataReceivedEventArgs(decimal m_DataReceived)
        {
            this.DataReceived = m_DataReceived;
        }


    }
    
    public delegate void DataReceivedEventHandler(DataReceivedEventArgs e);
}
