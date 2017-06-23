using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using SqlSugar;

namespace HookApi.DbContext
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
            var db = new SqlSugarClient(ConnectionString);
      
            return db;
        }
    }
}