using System;
using System.Collections.Generic;
using System.Text;

namespace XmWeightForm.log
{
        public delegate void CallBackDelegate();
        public class ThreadWithState
        {
            private string Message;
            // 回调委托
            private CallBackDelegate callback;

            // 构造函数
            public ThreadWithState(CallBackDelegate callbackDelegate)
            {
               // this.Message = message;
                this.callback = callbackDelegate;
            }

            // 线程方法
            public void ThreadProc()
            {
               // Console.WriteLine("新线程: 开始执行 ..");
                //Console.WriteLine("新线程: 传入的消息: {0}", Message);

                log4netHelper.Info("新线程: 开始执行 ..");
                if (callback != null) callback();  // 通过委托, 将数据回传给回调函数
            }

        
    }
}
