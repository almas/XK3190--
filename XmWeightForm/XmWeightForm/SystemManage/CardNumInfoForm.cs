using AppService;
using AppService.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dapper_NET20;
using System.Linq;

namespace XmWeightForm.SystemManage
{
    public partial class CardNumInfoForm : Form
    {
        public CardNumInfoForm()
        {
            InitializeComponent();
        }
        private int Id = 0;
        public CardNumInfoForm(int id)
        {
            InitializeComponent();
            Id = id;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var cnum = txtCardNum.Text.Trim();
            if (string.IsNullOrEmpty(cnum))
            {
                MessageBox.Show("请填写卡号");
                return;
            }
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    if (Id == 0)
                    {
                        var isExist = db.Query<int>("select count(0) from BatchCard where cardNum=@cnum", new { cnum = cnum }).FirstOrDefault();
                        if (isExist == 0)
                        {
                            var sql = "insert into BatchCard(cardNum,createTime)values(@cardNum,@ctime)";

                            db.Execute(sql, new { cardNum = cnum, ctime = DateTime.Now });
                        }
                        else
                        {
                            MessageBox.Show("卡号已存在");
                        }
                    }
                    else
                    {
                        var isExist = db.Query<int>("select count(0) from BatchCard where cardNum=@cnum && Id<>@id", new { id = Id, cnum = cnum }).FirstOrDefault();
                        if (isExist == 0)
                        {
                            var sql = "update BatchCard set cardNum=@cardNum)";

                            db.Execute(sql, new { cardNum = cnum });
                        }
                        else
                        {
                            MessageBox.Show("卡号已存在");
                        }
                    }

                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
                MessageBox.Show("保存失败");
            }

        }

        private void CardNumInfoForm_Load(object sender, EventArgs e)
        {
            if (Id==0)
            {
                InitData();
            }
            
        }

        private void InitData()
        {
            var model = new BatchCard();
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    model = db.Query<BatchCard>("select * from BatchCard where Id=@Id", new { Id = Id }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            if (model != null)
            {
                txtCardNum.Text = model.cardNum;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
