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
using CCWin.SkinClass;
using Dapper_NET20;
using DevComponents.DotNetBar;

namespace XmWeightForm.SystemManage
{
    public partial class PriceInfoForm : Office2007Form
    {
        public PriceInfoForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }

        public int PriceKeyId = 0;
        public PriceInfoForm(int priceKeyId)
        {
            InitializeComponent();
            this.EnableGlass = false;
            PriceKeyId = priceKeyId;

            InitEditData(priceKeyId);
        }


        private void InitEditData(int id)
        {
            var model=new AnimalTypes();
            using (var db = DapperDao.GetInstance())
            {
                model = db.Query<AnimalTypes>("select * from AnimalTypes where animalTypeId=@id", new { id = id }).FirstOrDefault();
            }

            if (model != null)
            {
                animalName.Text = model.animalTypeName;
                txtPrice.Text = model.price.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var name = animalName.Text.Trim();
            var price = txtPrice.Text.Trim();
            decimal priceDecimal = 0;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("动物类型不能为空");
                return;
            }
            if (!string.IsNullOrEmpty(price))
            {

                try
                {
                    priceDecimal=decimal.Parse(price);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("价格数据格式不正确");
                    return;
                }
                //if (!ValidaterHelper.IsNumber(price))
                //{
                //    MessageBox.Show("价格数据格式不正确");
                //    return;
                    
                //}
            }
            try
            {
                int resultNum = 0;
                if (PriceKeyId == 0)
                {
                    string sql = "insert into AnimalTypes(animalTypeName,price)values(@animalTypeName,@price)";
                    using (var db = DapperDao.GetInstance())
                    {
                        resultNum = db.Execute(sql, new { animalTypeName = name, price = priceDecimal });
                    }
                }
                else
                {
                    string sql = "update AnimalTypes set animalTypeName=@animalTypeName,price=@price where animalTypeId=" +
                                 PriceKeyId;

                    using (var db = DapperDao.GetInstance())
                    {
                        resultNum = db.Execute(sql, new { animalTypeName = name, price = price });
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
    }
}
