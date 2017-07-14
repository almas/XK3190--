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
    public partial class GrossWeightForm : Office2007Form
    {
        public GrossWeightForm()
        {
            InitializeComponent();
        }

        private string facId = string.Empty;
        public decimal HookWeight = 0.0m;
        private void GrossWeightForm_Load(object sender, EventArgs e)
        {
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    var qeury = db.Query<ParamsModel>("select top 1 factoryId, hookWeight from Params", null).FirstOrDefault();

                    if (qeury != null)
                    {
                        facId = qeury.factoryId;
                        txtWeight.Text = qeury.hookWeight.ToString();
                        HookWeight = qeury.hookWeight;
                    }
                }
            }
            catch (Exception ex)
            {
               log4netHelper.Exception(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var weight = txtWeight.Text.Trim();
            if (string.IsNullOrEmpty(facId))
            {
                MessageBox.Show("系统错误，请联系管理员");
                return;
            }
            if (!ValidaterHelper.IsNumberOrFloat(weight))
            {
                MessageBox.Show("毛重格式不正确");
                return;

            }

            try
            {
                int refResult = 0;
                decimal dweight = decimal.Parse(weight);

                using (var db = DapperDao.GetInstance())
                {
                    refResult = db.Execute("update Params set hookWeight=@dweight where factoryId=@facid", new { dweight = dweight, facid=facId });
                }


                if (refResult > 0)
                {
                    HookWeight = dweight;
                    MessageBox.Show("保存成功");

                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {
              log4netHelper.Exception(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
