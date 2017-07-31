using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;


namespace ReportClient
{
    public partial class MainForm : Office2007Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private ReportUForm psReport=null;
        private ReportForm reportForm=null;
        private void ttTab_Click(object sender, EventArgs e)
        {
            if (reportForm == null)
            {
                reportForm = new ReportForm();
                reportForm.TopLevel = false;
                reportForm.FormBorderStyle = FormBorderStyle.None;
                reportForm.Dock = DockStyle.Fill;
                reportForm.Show();
                ttTab.AttachedControl.Controls.Clear();
                ttTab.AttachedControl.Controls.Add(reportForm);
            }

        }


        private bool IsShowTab(string tabName)
        {
            bool have = false;
            foreach (SuperTabItem tab in superTabControl1.Tabs)
            {
                if (tab.Text == tabName)
                {
                    have = true;
                    this.superTabControl1.SelectedTab = tab;
                    return have;
                }
            }

            return false;
        }

        private void psTab_Click(object sender, EventArgs e)
        {
            if (psReport == null)
            {
                psReport = new ReportUForm();
                psReport.Show();
                psTab.AttachedControl.Controls.Clear();
                psTab.AttachedControl.Controls.Add(psReport);
            }


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           // superTabControl1.SelectedTab = ttTab;
            ttTab_Click(null, null);
        }
    }
}
