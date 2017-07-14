using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppService.Model;

namespace XmWeightForm.SystemManage
{
    public partial class FactoryForm : UserControl
    {
        public FactoryForm()
        {
            InitializeComponent();
            factoryGrid.AutoGenerateColumns = false;
        }
        private void FactoryForm_Load(object sender, EventArgs e)
        {
            InitData();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var factoryFrm = new FactoryInfoForm();

            factoryFrm.ShowDialog();
            if (factoryFrm.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }


        private void InitData()
        {
            var data = GetData(string.Empty);
            ReloadGrid(data);
        }

        private void ReloadGrid(List<ParamsModel> data)
        {
           // lblCount.Text = "一共" + Total + "条数据";
            factoryGrid.DataSource = data;
            factoryGrid.ClearSelection();
        }

        public int Page = 1;
        public int Psize = 15;
        public int Total = 0;
        public int PageCount = 1;
        private List<ParamsModel> GetData(string whersql)
        {
            var list = DapperPagerHelper<ParamsModel>.QueryPagerData("Params", Page, Psize, "meatRate", whersql, ref Total);


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

        private void factoryGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = this.factoryGrid.SelectedRows[0].Cells[0].Value.ToString();

            var factoryFrm = new FactoryInfoForm(id);

            factoryFrm.ShowDialog();
            if (factoryFrm.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
