using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppService.Model;
using DevComponents.DotNetBar;
using AppService;
using Dapper_NET20;
using System.Linq;

namespace XmWeightForm.SystemManage
{
    public partial class AnimalPriceForm : UserControl
    {
        public AnimalPriceForm()
        {
            InitializeComponent();
            priceGrid.AutoGenerateColumns = false;
        }

        private void AnimalPriceForm_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void InitData()
        {
            var data = AnimalList(string.Empty);

            ReloadGrid(data);
        }

        public int Page = 1;
        public int Psize = 10;
        public int Total = 0;
        public int PageCount = 1;
        private List<AnimalTypes> AnimalList(string whersql)
        {
            var list = DapperPagerHelper<AnimalTypes>.QueryPagerData("AnimalTypes", Page, Psize, "animalTypeId", whersql, ref Total);


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

        private void ReloadGrid(List<AnimalTypes> data)
        {
            priceGrid.DataSource = data;
            priceGrid.ClearSelection();
        }

        private void priceGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = this.priceGrid.SelectedRows[0].Cells[0].Value.ToString();

            int intId = int.Parse(id);
            var info = new PriceInfoForm(intId);
            info.ShowDialog();

            if (info.DialogResult == DialogResult.OK)
            {
                InitData();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var info = new PriceInfoForm();
            info.ShowDialog();

            if (info.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void priceGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var rows = priceGrid.SelectedRows;
            if (rows.Count == 1)
            {
                string rowId = this.priceGrid.SelectedRows[0].Cells[0].Value.ToString();
                string productName = priceGrid.SelectedRows[0].Cells[1].Value.ToString();
                int intId = int.Parse(rowId);

                string msg = "确认删除[" + productName + "]吗？";
                DialogResult dr = MessageBox.Show(msg, "确认删除", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    var affectCount = 0;
                    using (var db = DapperDao.GetInstance())
                    {
                        var sql = "delete from AnimalTypes where animalTypeId=@id";
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

        
    }
}
