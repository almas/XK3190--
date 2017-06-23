using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using AppService;
using AppService.Model;
using Dapper_NET20;
using System.Linq;
using System.IO;
using Microsoft.Win32;
namespace XmWeightForm
{
    public partial class LoginForm :Office2007Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        public bool IsAdmin = false;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            var uname = txtName.Text.Trim();
            var pwd = txtPwd.Text.Trim();
            if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("请输入用户名");

                return ;
            }
            if (uname.ToLower() == "admin")
            {
                if (string.IsNullOrEmpty(pwd))
                {
                    MessageBox.Show("密码不能为空");
                    return;
                }

                var loginResult = AdminLogin(uname, pwd);
                if (loginResult.Status)
                {
                    IsAdmin = true;
                }
                else
                {
                    MessageBox.Show(loginResult.Msg);
                    return;
                }
                
            }

            bool flag = chkStart.Checked;
            StartAppOn(flag);
           
            this.DialogResult=DialogResult.OK;
            this.Close();
            
            //MainForm fm = new MainForm();
            //fm.Show(); //打开主窗口
            //this.Close();    //关闭登录窗口
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();    //关闭登录窗口
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private LoginResult AdminLogin(string uname, string pwd)
        {
            var result = new LoginResult();
            try
            {
                OpersModel model = null;
                using (var db = DapperDao.GetInstance())
                {
                    model = db.Query<OpersModel>("select * from Opers where userName=@uname and password=@pwd", new { uname = uname,pwd=pwd }).FirstOrDefault();
                }
                if (model == null)
                {
                    result.Msg = "用户名密码错误";
                }
                else
                {
                    result.Status = true;
                }
            }
            catch(Exception ex)
            {
                result.Msg = "登录异常，请联系管理员";
            }

            return result;
        }


        private void StartAppOn(bool flag)
        {
            try
            {
                string dir = Directory.GetCurrentDirectory();

                ////获取可执行文件的全部路径  
                string exeDir = dir + "\\XmWeightForm.exe";  
                //string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup);
                //System.IO.File.Copy(exeDir, StartupPath + "XmWeightForm.exe", true);

                RegistryKey key1 = Registry.LocalMachine;
                RegistryKey key2 = key1.CreateSubKey("SOFTWARE");
                RegistryKey key3 = key2.CreateSubKey("Microsoft");
                RegistryKey key4 = key3.CreateSubKey("Windows");
                RegistryKey key5 = key4.CreateSubKey("CurrentVersion");
                RegistryKey key6 = key5.CreateSubKey("Run");

                //在Run键中写入一个新的键值  
                if (flag)
                {
                    key6.SetValue("xmweightApp", exeDir);
                }
                else
                {
                    key6.SetValue("xmweightApp", false);
                }

                key6.Close();

                //如果要取消的话就将key6.SetValue("myForm",exeDir);改成  
                //key6.SetValue("myForm",false);
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }
    }

    public class LoginResult
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
}
