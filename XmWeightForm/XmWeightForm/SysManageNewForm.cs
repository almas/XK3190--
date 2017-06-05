using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using XmWeightForm.SystemManage;

namespace XmWeightForm
{
    public partial class SysManageNewForm : Office2007Form
    {
        private ProductForm productForm;
        private AnimalPriceForm animalPriceForm;
        private SysPersonInfo personInfoForm;
        private FactoryForm factoryForm;
        private ReportUForm reportForm;
        public SysManageNewForm()
        {
            InitializeComponent();
            this.EnableGlass = false;
        }
        private void SysManageNewForm_Load(object sender, EventArgs e)
        {
            sysTabControl.SelectedTab = tabReport;
            tabReport_Click(null,null);
            
        }
        private void tabReport_Click(object sender, EventArgs e)
        {
            //if (IsOpenTab(tabReport.Text))
           // {
                reportForm = new ReportUForm();
                reportForm.Show();
                tabReport.AttachedControl.Controls.Clear();
                tabReport.AttachedControl.Controls.Add(reportForm);
            // }
           
        }

        private void tabProduct_Click(object sender, EventArgs e)
        {
            //if (IsOpenTab(tabProduct.Text))
           // {
                productForm = new ProductForm();
                productForm.Show();
                tabProduct.AttachedControl.Controls.Clear();
                tabProduct.AttachedControl.Controls.Add(productForm);
            // }

        }

        private void tabPrice_Click(object sender, EventArgs e)
        {
            //if (IsOpenTab(tabPrice.Text))
            //{
                animalPriceForm = new AnimalPriceForm();
                animalPriceForm.Show();
                tabPrice.AttachedControl.Controls.Clear();
                tabPrice.AttachedControl.Controls.Add(animalPriceForm);
            //}
        }

        private void tabFactory_Click(object sender, EventArgs e)
        {
            //if (IsOpenTab(tabFactory.Text))
            //{
                factoryForm = new FactoryForm();
                factoryForm.Show();
                tabFactory.AttachedControl.Controls.Clear();
                tabFactory.AttachedControl.Controls.Add(factoryForm);
            //}
        }

        private void tabUser_Click(object sender, EventArgs e)
        {
            //if (IsOpenTab(tabUser.Text))
            //{
                personInfoForm = new SysPersonInfo();
                personInfoForm.Show();
                tabUser.AttachedControl.Controls.Clear();
                tabUser.AttachedControl.Controls.Add(personInfoForm);
           // }
        }

        private bool IsOpenTab(string tabName)
        {
            bool isOpened = false;

            foreach (SuperTabItem tab in sysTabControl.Tabs)
            {
                if (tab.Text.Trim() == tabName.Trim() && sysTabControl.SelectedTab != tab)
                {
                    isOpened = true;
                    sysTabControl.SelectedTab = tab;
                    break;
                }
            }
            return isOpened;
        }
    }
}
