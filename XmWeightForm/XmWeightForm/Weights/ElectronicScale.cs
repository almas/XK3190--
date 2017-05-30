using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace XmWeightForm.Weights
{
    /// <summary>
    /// 电子秤对象：
    /// </summary>
    public class ElectronicScale
    {
        /// <summary>
        /// 连续相同重量次数
        /// </summary>
        private int _sameCount =10;
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

        #region 构造函数

        public ElectronicScale()
        {
        }
        #endregion

        #region 属性
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


        public void WeightDataScale(decimal tempweight,ref decimal outWeight)
        {
            try
            {
                //传进来的重量
                decimal weight = tempweight;

                if (_lastWeight != Decimal.Zero)
                {
                    if (Math.Abs(weight - _lastWeight) <= _errorLimit)
                    {
                        _readCount++;
                    }
                }
               
                
                _lastWeight = weight;
                if (_readCount >= _sameCount && _isChanged)
                {
                    if (weight >= _minWeight)
                    {
                        //_dataQueue.Enqueue(weight);
                        _lastWeight = weight;
                        _isChanged = false;
                        outWeight = weight;
                        _readCount = 0;
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
                outWeight= 0.000M;
            }

        }

        public  void OnDataReceived(decimal tempweight,decimal outWeight)
        {
            try
            {
                decimal weight = tempweight;
                //if (weight <= _minWeight)
                //{
                //    _readCount = 0;
                //    _isChanged = true;
                //    return;
                //}
               
                if (Math.Abs(weight - _lastWeight) <= _errorLimit)
                {
                    //连续在误差范围里，就开始计数
                    _readCount++;
                }
                _lastWeight = weight;
                if (_readCount >= _sameCount && _isChanged)
                {
                    if (weight >= _minWeight)
                    {
                        _dataQueue.Enqueue(weight);
                        _lastWeight = weight;
                        _isChanged = false;
                    }
                    // return weight;
                }

                if (_dataQueue.Count >= _sameCount)
                {
                     outWeight = (decimal)_dataQueue.ToArray()[0];
                    _dataQueue.Clear();
                    _readCount = 0;
                    _lastWeight = 0.000M;
                }
                

                //string recevieData = _serialPort.ReadExisting();
                //string logData = DateTime.Now.ToString("hh:mm:ss") + ":" + recevieData;
                //if (_dataQueue.Count > 0)
                //{
                //    InvokeRichText.Log(this.richTextBox1, LogMsgType.Receiving, _dataQueue.Dequeue().ToString() + "\r\n");
                //}
            }
            catch
            {
            }
        }
    }
}
