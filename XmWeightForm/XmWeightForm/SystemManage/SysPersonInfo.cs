using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppService;
using AppService.Model;
using Dapper_NET20;

namespace XmWeightForm.SystemManage
{
    public partial class SysPersonInfo : UserControl
    {
        public SysPersonInfo()
        {
            InitializeComponent();
        }
        public int Page = 1;
        public int Psize = 10;
        public int Total = 0;
        public int PageCount = 1;
        private void SysPersonInfo_Load(object sender, EventArgs e)
        {
            personGrid.AutoGenerateColumns = false;
            InitData();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            var data = GetData(string.Empty);
            ReloadGrid(data);
            
        }

        private List<OpersModel> GetData(string whersql)
        {
            var list = DapperPagerHelper<OpersModel>.QueryPagerData("Opers", Page, Psize, "Id", whersql, ref Total);


            if (Total > Psize)
            {
                int tempCount = Total / Psize;
                if (Total % Psize > 0)
                {
                    tempCount += 1;
                }
                PageCount = tempCount;
            }
          
            return list;
        }
        private void ReloadGrid(List<OpersModel> data)
        {
            lblCount.Text = "一共" + Total + "条数据";
            personGrid.DataSource = data;
            personGrid.ClearSelection();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Page = 1;
            InitData();

        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (Page > 1)
            {
                Page--;
                brnQuery.PerformClick();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Page < PageCount)
            {
                Page++;
                brnQuery.PerformClick();
            }
        }

        private void brnQuery_Click(object sender, EventArgs e)
        {
            var pname = txtName.Text.Trim();

            if (!string.IsNullOrEmpty(pname))
            {
                var data = GetData("and operName like'%" + pname + "%'");

                ReloadGrid(data);
            }
            else
            {
                InitData();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var rows = personGrid.SelectedRows;
            if (rows.Count == 1)
            {
                string rowId = this.personGrid.SelectedRows[0].Cells[0].Value.ToString();
                string productName = personGrid.SelectedRows[0].Cells[1].Value.ToString();
                int intId = int.Parse(rowId);

                string msg = "确认删除[" + productName + "]吗？";
                DialogResult dr = MessageBox.Show(msg, "确认删除", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    var affectCount = 0;
                    using (var db = DapperDao.GetInstance())
                    {
                        var sql = "delete from Opers where Id=@id";
                        affectCount = db.Execute(sql, new { id = intId });
                    }

                    if (affectCount > 0)
                    {
                        InitData();
                    }
                }
                else//如果点击“取消”按钮
                {
                    //e.Cancel = true;
                }

            }
            else
            {
                MessageBox.Show("请选择需要删除的数据行");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var productFrm = new SysPersonInfoForm();

            productFrm.Show();
            if (productFrm.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }

        private void personGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = this.personGrid.SelectedRows[0].Cells[0].Value.ToString();

            int intId = int.Parse(id);
            var info = new SysPersonInfoForm(intId);
            info.ShowDialog();

            if (info.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }


    }
}
