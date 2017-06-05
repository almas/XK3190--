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
using DevComponents.DotNetBar;

namespace XmWeightForm.SystemManage
{
    public partial class SysPersonInfoForm : Office2007Form
    {
        public SysPersonInfoForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        public int DataId = 0;
        public SysPersonInfoForm(int id)
        {
            InitializeComponent();
            this.EnableGlass = false;
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
                txtJobNum.Text = model.jobNumber;
                txtPwd.Text = model.Password;
                chkAdmin.Checked = model.isAdmin;
                txtJobStation.Text = model.jobStation;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var uname = txtUname.Text.Trim();
            var nickname = txtNickName.Text.Trim();
            var pwd = txtPwd.Text.Trim();
            var jobNum = txtJobNum.Text.Trim();
            var isadmin = chkAdmin.Checked;
            var txtStation = txtJobStation.Text.Trim();
            int resultNum = 0;
            if (DataId == 0)
            {
                string sql =
                    @"insert into Opers(userName,operName,password,jobNumber,isAdmin,isRepoter,stopped,jobStation)
                       values(@uname,@nickname,@pwd,@jobNum,@isadmin,@isRepoter,@stopped,@jobStation)";
                using (var db = DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql,
                        new { uname = uname, nickname = nickname, pwd = pwd, jobNum = jobNum, isadmin = isadmin, isRepoter = false, stopped = false, jobStation =txtStation});
                }
            }
            else
            {
                string sql = "update Opers set userName=@uname,operName=@nickname,password=@pwd,jobNumber=@jobNum,isAdmin=@isadmin,jobStation=@jobStation where Id=" + DataId;

                using (var db = DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql, new { uname = uname, nickname = nickname, pwd = pwd, jobNum = jobNum, isadmin = isadmin, jobStation = txtStation });
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
