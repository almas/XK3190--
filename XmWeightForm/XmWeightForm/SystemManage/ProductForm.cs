using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppService;
using AppService.Model;
using Dapper_NET20;

namespace XmWeightForm.SystemManage
{
    public partial class ProductForm : UserControl
    {
        public ProductForm()
        {
            InitializeComponent();

            
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            btnImport.Visible = false;
            productGrid.AutoGenerateColumns = false;
           // Thread.Sleep(1000);
            InitData();
        } 
        private void InitData()
        {
            var data = GetProduct(string.Empty);
            ReloadGrid(data);
            //if (PageCount <= 1)
            //{
            //    btnNext.Enabled = false;
            //    //btnLast.Enabled = false;
            //    //btnFirst.Enabled = false;
            //    btnPre.Enabled = false;
            //}
            //else
            //{
               
            //}
            //productGrid.DataBindings()
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            var pname = queryProductName.Text.Trim();
            if (!string.IsNullOrEmpty(pname))
            {
                Page = 1;

                var data = GetProduct("and productName like'%" + pname + "%'");

                ReloadGrid(data);
            }
            else
            {
                InitData();
            }
        }


        public int Page = 1;
        public int Psize = 15;
        public int Total = 0;
        public int PageCount=1;
        private List<ProductModel> GetProduct(string whersql)
        {
            var list = DapperPagerHelper<ProductModel>.QueryPagerData("Products", Page, Psize, "productId", whersql, ref Total);


            if (Total > Psize)
            {
                int tempCount = Total/Psize;
                if (Total%Psize > 0)
                {
                    tempCount += 1;
                }
                PageCount = tempCount;
            }
            else
            {
                PageCount = 1;
            }

            return list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var productFrm=new ProductInfoForm();

            productFrm.Show();
            if (productFrm.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }

        //private void productGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string id= this.productGrid.SelectedRows[0].Cells[0].Value.ToString();
        //   // MessageBox.Show(id);
        //}

        private void productGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = this.productGrid.SelectedRows[0].Cells[0].Value.ToString();

            int intId = int.Parse(id);
            var info=new ProductInfoForm(intId);
            info.ShowDialog();

            if (info.DialogResult == DialogResult.OK)
            {
                InitData();
            }


        }


        private void ReloadGrid(List<ProductModel> data)
        {
            lblCount.Text = "一共" + Total + "条数据";
            productGrid.DataSource = data;
            productGrid.ClearSelection();
        }

        //private void btnFirst_Click(object sender, EventArgs e)
        //{
        //    Page = 1;
        //    btnQuery.PerformClick();
        //}

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (Page > 1)
            {
                Page--;

                var data=new List<ProductModel>();
                var pname = queryProductName.Text.Trim();
                if (!string.IsNullOrEmpty(pname))
                {
                    data = GetProduct("and productName like'%" + pname + "%'");
                }
                else
                {
                    data = GetProduct(String.Empty);
                }

                ReloadGrid(data);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Page < PageCount)
            {
                Page++;
                var data = new List<ProductModel>();
                var pname = queryProductName.Text.Trim();
                if (!string.IsNullOrEmpty(pname))
                {
                    data = GetProduct("and productName like'%" + pname + "%'");
                }
                else
                {
                    data = GetProduct(String.Empty);
                }

                ReloadGrid(data);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Page = 1;
            InitData();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var rows = productGrid.SelectedRows;
            if (rows.Count == 1)
            {
                string rowId = this.productGrid.SelectedRows[0].Cells[0].Value.ToString();
                string productName = productGrid.SelectedRows[0].Cells[1].Value.ToString();
                int intId = int.Parse(rowId);

                string msg = "确认删除[" + productName + "]吗？";
                DialogResult dr = MessageBox.Show(msg, "确认删除", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)//如果点击“确定”按钮
                {
                    var affectCount = 0;
                    using (var db = DapperDao.GetInstance())
                    {
                        var sql = "delete from Products where Id=@id";
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
