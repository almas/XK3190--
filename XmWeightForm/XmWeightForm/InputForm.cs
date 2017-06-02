using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppService;
using AppService.Model;

using Dapper_NET20;

//using Dapper_NET20;

namespace XmWeightForm
{
    public partial class InputForm : UserControl
    {
        public InputForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 称重状态 1-结束，0-称重中
        /// </summary>
        public int WeghtState = 1;

        public string BatchId;
        private void InputForm_Load(object sender, EventArgs e)
        {
            var list = new List<string>();
            list.Add("羔羊");
            list.Add("绵羊");
            list.Add("牛");
            animalSel.DataSource = list;


            //var data = InitData();
            //if (data != null)
            //{
            //    txtName.Text = data.hostName;
            //    txtIdNumber.Text = data.IdNum;
            //    txtTel.Text = data.tel;

            //    animalSel.SelectedText = data.animalType;
            //    BatchId = data.batchId;

            //    //称重状态 1-结束，0-称重中
            //    SwitchButtonStatus(2);
            //}
            //else
            //{
            //    btnEnd.Enabled = false;
            //}


        }

        /// <summary>
        /// 开始称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            var batckId = DateTime.Now.ToString("yyyyMMdd");
            int timeInd = int.Parse(batckId);

            var uname = txtName.Text.Trim();
            var idNum = txtIdNumber.Text.Trim();
            var userTel = txtTel.Text.Trim();

            //if (string.IsNullOrEmpty(uname))
            //{
            //    MessageBox.Show("请输入送宰人信息");
            //    return;

            //}

            //if (!ValidaterHelper.IsIDCard(idNum))
            //{
            //    MessageBox.Show("身份证号码有误");
            //    return;

            //}

            //if (!ValidaterHelper.IsMobileNum(userTel))
            //{
            //    MessageBox.Show("手机号码有误");
            //    return;

            //}


            using (var db = GetOpenConnection())
            {
                var ds = db.ExecuteDataSet("select top 1 * from BatchInput where flag=0", null,null,null,null);
                int count = ds.Tables.Count;
            }

            SwitchButtonStatus(0);
        }

        /// <summary>
        /// 结束称重
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(BatchId))
            {
                var sql = "update BatchInput set flag=1 where batchId='" + BatchId + "'";

                int returnVal = 0;
                using (var db = GetOpenConnection())
                {
                    returnVal = db.Execute(sql, null);
                }

                if (returnVal > 0)
                {
                    txtName.Text = string.Empty;
                    txtIdNumber.Text = string.Empty;
                    txtTel.Text = string.Empty;
                    BatchId = string.Empty;
                    SwitchButtonStatus(1);
                }
            }
          
        }


        /// <summary>
        /// 0-称重中，1-结束
        /// </summary>
        /// <param name="state"></param>
        private void SwitchButtonStatus(int state)
        {
            if (state == 0)
            {

                WeghtState = state;
                this.btnStart.Enabled = false;
                this.btnStart.BackColor = Color.DarkGray;
                this.btnEnd.Enabled = true;
                this.btnEnd.BackColor = Color.MediumSeaGreen;
            }
            else
            {
                WeghtState = state;
                this.btnEnd.Enabled = false;
                this.btnEnd.BackColor = Color.DarkGray;
                this.btnStart.Enabled = true;
                this.btnStart.BackColor = Color.MediumSeaGreen;
            }
        }
        //private IDbConnection _conn;
        private static string connString = ConfigurationManager.ConnectionStrings["xlhotDbConn"].ConnectionString;
        //public IDbConnection Conn
        //{
        //    get
        //    {
        //        return _conn  = new SqlConnection(connString);
        //    }
        //}

        public static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(connString);
            connection.Open();
            return connection;
        }
        private void InitData()
        {
            var data=new BatchInput();
            using (var db = GetOpenConnection())
            {
                var query = "select top 1 * from BatchInput where flag=0";
                data = db.Query<BatchInput>(query, null).FirstOrDefault();
            }

            if (data != null)
            {
                txtName.Text = data.hostName;
                txtIdNumber.Text = data.PIN;
                txtTel.Text = data.tel;

                animalSel.SelectedText = data.animalTypeId.ToString();
                BatchId = data.batchId;

                //称重状态 1-结束，0-称重中
                SwitchButtonStatus(2);
            }
            else
            {
                btnEnd.Enabled = false;
            }

        }
    }
}
