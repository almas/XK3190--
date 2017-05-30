using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppService;
using AppService.Model;
using Dapper_NET20;

namespace XmWeightForm.SystemManage
{
    public partial class SysPersonInfoForm : Form
    {
        public SysPersonInfoForm()
        {
            InitializeComponent();
        }

        public int DataId = 0;
        public SysPersonInfoForm(int id)
        {
            InitializeComponent();

            DataId = id;
            InitEditData(id);
        }


        private void InitEditData(int id)
        {
            var model = new OpersModel();
            using (var db = DapperDao.GetInstance())
            {
                model = db.Query<OpersModel>("select * from Opers where Id=@id", new { id = id }).FirstOrDefault();
            }

            if (model != null)
            {
                txtUname.Text = model.userName;
                txtNickName.Text = model.OperName;
                txtJobNum.Text = model.JobNumber;
                txtPwd.Text = model.Password;
                chkAdmin.Checked = model.isAdmin;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uname = txtUname.Text.Trim();
            var nickname = txtNickName.Text.Trim();
            var pwd = txtPwd.Text.Trim();
            var jobNum = txtJobNum.Text.Trim();
            var isadmin = chkAdmin.Checked;

            int resultNum = 0;
            if (DataId == 0)
            {
                string sql =
                    @"insert into Opers(userName,operName,password,JobNumber,isAdmin,isRepoter,stopped)
                       values(@uname,@nickname,@pwd,@jobNum,@isadmin,@isRepoter,@stopped)";
                using (var db = DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql,
                        new { uname = uname, nickname = nickname, pwd = pwd, jobNum = jobNum, isadmin = isadmin, isRepoter = false, stopped =false});
                }
            }
            else
            {
                string sql = "update Opers set userName=@uname,operName=@nickname,password=@pwd,JobNumber=@jobNum,isAdmin=@isadmin where Id=" + DataId;

                using (var db = DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql, new { uname = uname, nickname = nickname, pwd = pwd, jobNum = jobNum, isadmin = isadmin });
                }
            }

            if (resultNum > 0)
            {
                MessageBox.Show("保存成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("保存失败");
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
