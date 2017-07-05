using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AppService
{
    public class DapperDao
    {
        private DapperDao()
        {
        }

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["xlhotDbConn"].ConnectionString;

        public static IDbConnection GetInstance()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }
    }


}
