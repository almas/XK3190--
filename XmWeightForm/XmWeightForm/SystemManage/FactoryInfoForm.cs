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
    public partial class FactoryInfoForm : Office2007Form
    {
        public FactoryInfoForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }
        public string DataId = String.Empty;
        public FactoryInfoForm(string id)
        {
            InitializeComponent();
            this.EnableGlass = false;
            DataId=id;
            InitEditData(id);
        }


        private void InitEditData(string id)
        {
            var model=new ParamsModel();

            using (var db = DapperDao.GetInstance())
            {
                model =
                    db.Query<ParamsModel>("select * from Params where factoryId=@id", new {id = id}).FirstOrDefault();
            }

            if (model != null)
            {
                txtFactoryName.Text = model.factoryName;
                txtFactoryNum.Text = model.factoryId;
                txtHook.Text = model.hooksWeight.ToString();
                txtmeatRate.Text = model.meatRate.ToString();
                txtTraceUrl.Text = model.traceURL;
                txtServerIp.Text = model.serverUrl;
                txtBone.Text = model.bonedRate.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var factoryName = txtFactoryName.Text.Trim();
            var factoryNum = txtFactoryNum.Text.Trim();
            var hook = txtHook.Text.Trim();
            var meatRate = txtmeatRate.Text.Trim();
            var traceUrl = txtTraceUrl.Text.Trim();
            var serverIp = txtServerIp.Text.Trim();
            var boneRate = txtBone.Text.Trim();
            decimal boneRated = 0;
            if (!string.IsNullOrEmpty(boneRate))
            {
                decimal.TryParse(boneRate, out boneRated);
            }
            if (string.IsNullOrEmpty(factoryName))
            {
                MessageBox.Show("名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(factoryNum))
            {
                MessageBox.Show("编号不能为空");
                return;
            }
            if (string.IsNullOrEmpty(hook))
            {
                MessageBox.Show("毛重不能为空");
                return;
            }
            if (string.IsNullOrEmpty(meatRate))
            {
                MessageBox.Show("出肉率不能为空");
                return;
            }
            if (string.IsNullOrEmpty(traceUrl))
            {
                MessageBox.Show("溯源地址不能为空");
                return;
            }
            if (string.IsNullOrEmpty(serverIp))
            {
                MessageBox.Show("服务器地址不能为空");
                return;
            }
            if (!ValidaterHelper.IsNumberOrFloat(hook))
            {
                MessageBox.Show("毛重格式不正确");
                return;

            }
            //总毛重
            decimal dweight = decimal.Parse(hook);
            //单只毛重
            decimal hookWeight = Math.Round(dweight / 4, 2);
            try
            {
                var affectRow = 0;
                if (string.IsNullOrEmpty(DataId))
                {
                    string sql =
                        @"insert into Params values(@factoryId,@factoryName,@meatRate,@hookWeight,@traceURL,@serverUrl,@bonedRate,@hooksWeight)";
                    using (var db = DapperDao.GetInstance())
                    {
                        affectRow = db.Execute(sql, new { factoryId = factoryNum, factoryName = factoryName, meatRate = meatRate, hookWeight = hookWeight, traceURL = traceUrl, serverUrl = serverIp, bonedRate = boneRated, hooksWeight = dweight });
                    }


                }
                else
                {
                    string sql =
                        @"update Params set factoryId =@factoryId, factoryName = @factoryName, meatRate = @meatRate,
                      hookWeight =@hookWeight,traceURL=@traceUrl,serverUrl=@serverIp,bonedRate=@bonedRate,hooksWeight=@hooksWeight where factoryId=@id";

                    using (var db = DapperDao.GetInstance())
                    {
                        affectRow = db.Execute(sql, new { factoryId = factoryNum, factoryName = factoryName, meatRate = meatRate, hookWeight = hookWeight, traceUrl = traceUrl, serverIp = serverIp, bonedRate = boneRated,hooksWeight = dweight, id = DataId });
                    }
                }

                if (affectRow > 0)
                {
                    MessageBox.Show("保存成功");

                }
                else
                {
                    MessageBox.Show("保存失败");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
                MessageBox.Show("保存失败");
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FactoryInfoForm_Load(object sender, EventArgs e)
        {

        }


    }
}
