using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace XmWeightForm.Weights
{
    public class BeepWarnHelper
    {
        /// <summary>
        /// 成功打开绿灯
        /// </summary>
        /// <param name="port"></param>
        public static void OpenGreenLed(SerialPort port)
        {
           byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x01;
            com[4] = 0xff;
            com[5] = 0x0;
            com[6] = 0xdd;
            com[7] = 0xfa;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
           
        }

        /// <summary>
        /// 关闭绿灯
        /// </summary>
        /// <param name="port"></param>
        public static void CloseGreedLed(SerialPort port)
        {
            byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x1;
            com[4] = 0x0;
            com[5] = 0x0;
            com[6] = 0x9c;
            com[7] = 0x0a;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
        }

        /// <summary>
        /// 红灯
        /// </summary>
        /// <param name="port"></param>
        public static void OpenRedLed(SerialPort port)
        {
            byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x0;
            com[4] = 0xff;
            com[5] = 0x0;
            com[6] = 0x8c;
            com[7] = 0x3a;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
        }

        /// <summary>
        /// 红灯
        /// </summary>
        /// <param name="port"></param>
        public static void CloseRedLed(SerialPort port)
        {
            byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x0;
            com[4] = 0x0;
            com[5] = 0x0;
            com[6] = 0xcd;
            com[7] = 0xca;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
        }
        /// <summary>
        /// 打开蜂鸣器
        /// </summary>
        /// <param name="port"></param>
        public static void OpenWarnBeep(SerialPort port)
        {
            byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x02;
            com[4] = 0xff;
            com[5] = 0x0;
            com[6] = 0x2d;
            com[7] = 0xfa;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
        }

        /// <summary>
        ///关闭蜂鸣器 
        /// </summary>
        /// <param name="port"></param>
        public static void CloseWarnBeep(SerialPort port)
        {
            byte[] com = new byte[8];
            com[0] = 0x01;
            com[1] = 0x05;
            com[2] = 0x0;
            com[3] = 0x2;
            com[4] = 0x0;
            com[5] = 0x0;
            com[6] = 0x6c;
            com[7] = 0x0a;
            if (port.IsOpen)
            {
                port.Write(com, 0, 8);
            }
        }
    }
}
