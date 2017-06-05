using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppService.Model;
using DevComponents.DotNetBar;

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

        
    }
}
