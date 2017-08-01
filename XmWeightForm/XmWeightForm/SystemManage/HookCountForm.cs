using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppService;
using DevComponents.DotNetBar;
using XmWeightForm.log;

namespace XmWeightForm.SystemManage
{
    public partial class HookCountForm : Office2007Form
    {
        public HookCountForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        public int DefaultHookCount = 1;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var hcounttxt = txtHookCount.Text.Trim();
            if (string.IsNullOrEmpty(hcounttxt))
            {
                MessageBox.Show("数量不能为空");
                return;
            }
            if (!ValidaterHelper.IsInt(hcounttxt))
            {
                MessageBox.Show("请输入一个整数");
                return;
            }


            try
            {
                int hookcount = int.Parse(hcounttxt);
                if (hookcount==0)
                {
                    hookcount = 1;
                }

                string sql = string.Empty;
                var ds = SQLiteHelper.ExecuteDataSet("select hookCount from localParams LIMIT 1", null);
                if (ds.Tables.Count == 1)
                {
                    var paramtable = ds.Tables[0];
                    if (paramtable.Rows.Count == 1)
                    {
                        sql = "update localParams set hookCount=@hcount";
                    }
                    else
                    {
                        sql = "insert into localParams(paramId,hookCount)values(1001,@hcount)";
                    }

                }
                if (!string.IsNullOrEmpty(sql))
                {
                    SQLiteParameter[] lastparams = new SQLiteParameter[]{
                                                 new SQLiteParameter("@hcount",DbType.Int32)
                                         };
                    lastparams[0].Value = hookcount;
                    int affectCount = SQLiteHelper.ExecuteNonQuery(sql, lastparams);
                    if (affectCount > 0)
                    {
                        DefaultHookCount = hookcount;
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("保存成功");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HookCountForm_Load(object sender, EventArgs e)
        {
            try
            {
                var ds = SQLiteHelper.ExecuteDataSet("select hookCount from localParams LIMIT 1", null);
                if (ds.Tables.Count == 1)
                {
                    var paramtable = ds.Tables[0];
                    if (paramtable.Rows.Count == 1)
                    {
                        DefaultHookCount = int.Parse(paramtable.Rows[0]["hookCount"].ToString());

                    }
                }

                txtHookCount.Text = DefaultHookCount.ToString();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
        }
    }
}
