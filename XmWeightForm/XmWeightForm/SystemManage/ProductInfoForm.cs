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

namespace XmWeightForm.SystemManage
{
    public partial class ProductInfoForm : Form
    {
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        public ProductInfoForm(int productId)
        {
            InitializeComponent();
            this.Id = productId;
            InitEditData(productId);
        }

        public int Id =0;


        private void btnSave_Click(object sender, EventArgs e)
        {
            var productName = this.productName.Text.Trim();
            var spec = txtSpec.Text.Trim();
            var productNo = txtNo.Text.Trim();
            var comment = txtRemark.Text.Trim();
            var barcode = txtBarcode.Text.Trim();
            var expiration = txtExpirate.Text.Trim();
            var pl = txtpl.Text.Trim();
            var storage = txtStorage.Text.Trim();
            string tempWeight = string.Empty;
            decimal normalWeight = 0.00M;

            bool isfixed = false;
            if(spec.Contains("*"))
            {
                isfixed = true;
                var tempweight1 = spec.Split('*');

                decimal.TryParse(tempweight1[0], out normalWeight);
            }

            int resultNum = 0;
            if (Id == 0)
            {
                string sql = "";
                if (!string.IsNullOrEmpty(productNo))
                {
                    sql += "update Products set productNo='' where productNo='" + productNo + "';";
                }
                 sql+=
                    @"insert into Products(productName,productNo,spec,comment,expiration,barcode,isFixedWeight,nominalWeight,ingredients,storageCondition)
                       values(@productName,@productNo,@spec,@comment,@expiration,@barcode,@isfixed,nominalWeight,ingredients,storageCondition);";
                using (var db=DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql, 
                        new { productName = productName, 
                              productNo = productNo,
                              spec = spec, 
                              comment = comment,
                              barcode = barcode,
                              expiration = expiration,
                              isfixed = isfixed,
                              nominalWeight = normalWeight,
                              ingredients = pl,
                              storageCondition=storage
                        });
                }
              
            }
            else
            {
                string sql = "";
                if (!string.IsNullOrEmpty(productNo))
                {
                    sql += "update Products set productNo='' where productNo='" + productNo + "' and productId<>" + Id + ";";
                }
                sql +=
                    @"update Products set productName = @productName, productNo = @productNo, spec = @spec, comment = @comment, barcode = @barcode, expiration = @expiration, isFixedWeight = @isfixed,
                    nominalWeight=@nominalWeight,ingredients=@ingredients,storageCondition=@storageCondition where productId=@id";

                using (var db = DapperDao.GetInstance())
                {
                    resultNum = db.Execute(sql, new
                    {
                        productName = productName,
                        productNo = productNo,
                        spec = spec,
                        comment = comment,
                        barcode = barcode,
                        expiration = expiration,
                        isfixed = isfixed,
                        nominalWeight = normalWeight,
                        ingredients = pl,
                        storageCondition = storage,
                        Id = Id
                    });
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitEditData(int id)
        {
            var model = new ProductModel();
            using (var db = DapperDao.GetInstance())
            {
                 model = db.Query<ProductModel>("select * from Products where Id=@id", new {id = id}).FirstOrDefault();
            }

            if (model != null)
            {
                this.productName.Text = model.productName;
                txtSpec.Text = model.spec;
                txtNo.Text = model.productNo;
                txtRemark.Text = model.comment;
                txtBarcode.Text = model.barcode;
                txtExpirate.Text = model.expiration;
            }
            else
            {
                Id = 0;
            }
        }

        private void ProductInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
        }
    }
}
