using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

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

            if (string.IsNullOrEmpty(uname))
            {
                MessageBox.Show("请输入用户名");

                return ;
            }
            if (uname.ToLower() == "admin")
            {
                IsAdmin = true;
            }
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
    }
}
