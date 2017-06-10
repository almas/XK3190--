using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XmWeightForm.SystemManage;

namespace XmWeightForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Application.Run(new SysManageForm());
            //Application.Run(new MainForm());
            //Application.Run(new SysManageNewForm());
            LoginForm fl = new LoginForm();
            fl.ShowDialog();
            if (fl.DialogResult == DialogResult.OK)
            {
                if (fl.IsAdmin)
                {
                    Application.Run(new SysManageNewForm());
                }
                else
                {
                    Application.Run(new MainForm());
                }
                
            }
            else
            {
                return;
            }
          
        }

        /// <summary>
        /// 线程异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            log4netHelper.Exception(e.Exception.Message);
        }
    }
}
