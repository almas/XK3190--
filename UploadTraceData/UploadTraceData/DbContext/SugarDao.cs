using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using SqlSugar;
using UploadTraceData.Common;

namespace UploadTraceData.DbContext
{
    public class SugarDao
    {
        private SugarDao()
        {
        }
        public static string ConnectionString
        {
            get
            {
                string reval = ConfigurationManager.ConnectionStrings["hookConn"].ConnectionString;
                return reval;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            try
            {
                var db = new SqlSugarClient(ConnectionString);
                return db;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           // return null;
        }
    }
}