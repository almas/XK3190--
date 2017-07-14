using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppService.Model;
using AppService;
using Dapper_NET20;
using System.Linq;
namespace XmWeightForm.SystemManage
{
    public partial class CardNumForm : UserControl
    {
        public CardNumForm()
        {
            InitializeComponent();
        }

        private void CardNumForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            InitData();
        }

        private void InitData()
        {
            var data = new List<BatchCard>();
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    data = db.Query<BatchCard>("select * from BatchCard", null).ToList();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            dataGridView1.DataSource = data;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var info = new CardNumInfoForm();
            info.Show();
            if (info.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int intId = int.Parse(id);
            var infoFarm = new CardNumInfoForm(intId);

            infoFarm.Show();
            if (infoFarm.DialogResult == DialogResult.OK)
            {
                InitData();
            }
        }
    }
}
