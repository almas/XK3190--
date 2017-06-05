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
                txtHook.Text = model.hookWeight;
                txtextraRate.Text = model.extraRate;
                txtmeatRate.Text = model.meatRate;
                txtTraceUrl.Text = model.traceURL;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var factoryName = txtFactoryName.Text.Trim();
            var factoryNum = txtFactoryNum.Text.Trim();
            var hook = txtHook.Text.Trim();
            var meatRate = txtmeatRate.Text.Trim();
            var extraRate = txtextraRate.Text.Trim();
            var traceUrl = txtTraceUrl.Text.Trim();

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
            if (string.IsNullOrEmpty(extraRate))
            {
                MessageBox.Show("耗损率不能为空");
                return;
            }
            if (string.IsNullOrEmpty(traceUrl))
            {
                MessageBox.Show("溯源地址不能为空");
                return;
            }

            var affectRow = 0;
            if (string.IsNullOrEmpty(DataId))
            {
                string sql =
                    @"insert into Params values(@factoryId,@factoryName,@meatRate,@extraRate,@hookWeight,@autoWeighing1,@autoWeighing2,@autoWeighing1,@traceURL)";
                using (var db = DapperDao.GetInstance())
                {
                    affectRow = db.Execute(sql, new { factoryId = factoryNum, factoryName = factoryName, meatRate = meatRate, extraRate = extraRate, hookWeight = hook, autoWeighing1 = true, autoWeighing2 = true, autoWeighing3 = true, traceURL=traceUrl });
                }

                
            }
            else
            {
                string sql =
                    @"update Params set factoryId =@factoryId, factoryName = @factoryName, meatRate = @meatRate, extraRate = @extraRate,
                      hookWeight =@hookWeight, autoWeighing1 = @autoWeighing1, autoWeighing2 = @autoWeighing2, autoWeighing3=@autoWeighing3,traceURL=@traceUrl where factoryId=@id";

                using (var db = DapperDao.GetInstance())
                {
                    affectRow = db.Execute(sql, new { factoryId = factoryNum, factoryName = factoryName, meatRate = meatRate, extraRate = extraRate, hookWeight = hook, autoWeighing1 = true, autoWeighing2 = true, autoWeighing3 = true, traceUrl = traceUrl, id = DataId });
                }
            }

            if (affectRow > 0)
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
