using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppService.Model;

namespace XmWeightForm.SystemManage
{
    public partial class SysManageForm : Form
    {
        private ProductForm productForm;
        private AnimalPriceForm animalPriceForm;
        private SysPersonInfo personInfoForm;
        private FactoryForm factoryForm;
        public SysManageForm()
        {
            InitializeComponent();
        }


        private void SysManageForm_Load(object sender, EventArgs e)
        {
           
            //inputForm = new InputForm();
            //reportForm = new ReportForm();
        }
        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            productForm = new ProductForm();
             productForm.Show();
             groupMain.Controls.Clear();
             groupMain.Controls.Add(productForm);
             groupMain.Text = "产品信息";
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            animalPriceForm=new AnimalPriceForm();
            animalPriceForm.Show();
            groupMain.Controls.Clear();
            groupMain.Controls.Add(animalPriceForm);
            groupMain.Text = "酮体价格";
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            factoryForm=new FactoryForm();
            factoryForm.Show();
            groupMain.Controls.Clear();
            groupMain.Controls.Add(factoryForm);
            groupMain.Text = "加工厂";
        }

        private void btnPerson_Click(object sender, EventArgs e)
        {
            personInfoForm=new SysPersonInfo();
            personInfoForm.Show();
            groupMain.Controls.Clear();
            groupMain.Controls.Add(personInfoForm);
            groupMain.Text = "人员管理";
        }


    }
}
