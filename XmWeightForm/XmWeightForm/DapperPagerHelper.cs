using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppService;
using Dapper_NET20;

namespace XmWeightForm
{
    public class DapperPagerHelper<T> where T:class 
    {
        public static List<T> GetPagerData(string tablename, int page, int psize, string ordefield,string wheresql,ref int total)
        {
            var data=new List<T>();
            try
            {
                int skipCount = psize * (page - 1);
                string sql =
                    "select top @psize * from (select row_number() over (order by @ordefield asc) as RowNumber,* from @tablename where 1=1";
                if (!string.IsNullOrEmpty(wheresql))
                {
                    sql += " " + wheresql;
                }
                sql += ") as temp where RowNumber > @skipCount";

                string countsql = "select count(0) from @tablename";


                if (!string.IsNullOrEmpty(wheresql))
                {
                    countsql += " " + wheresql;
                }
                using (var db = DapperDao.GetInstance())
                {
                    data = db.Query<T>(sql, new { tablename = tablename, wheresql = wheresql, psize = psize, ordefield = ordefield, skipCount = skipCount }).ToList();
                    total = db.Query<int>(countsql, new { tablename = tablename, wheresql = wheresql }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }

            return data;
        }

        public static List<T> QueryPagerData(string tablename, int page, int psize, string ordefield, string wheresql, ref int total)
        {
            var data = new List<T>();
            int startpage = psize * (page - 1)+1;
            int endpage = page*psize;
            StringBuilder sb=new StringBuilder();
            sb.AppendFormat(
                "select * from ( select * ,row_index=row_number() over(order by {0} asc ) from {1} where 1=1", ordefield,
                tablename);
            //string sql ="select * from ( select * ,row_index=row_number() over(order by @ordefield asc ) from @tablename where 1=1";
              
            if (!string.IsNullOrEmpty(wheresql))
            {
                sb.Append(" " + wheresql);
            }
           // sql += ") t where t.row_index between @startpage and @endpage";

            sb.AppendFormat(") t where t.row_index between {0} and {1}", startpage, endpage);
            string sql = sb.ToString();


            StringBuilder sbcount=new StringBuilder();
            sbcount.AppendFormat("select count(0) from {0} where 1=1",tablename);


            if (!string.IsNullOrEmpty(wheresql))
            {
                sbcount.Append(" " + wheresql);
            }
            string countsql = sbcount.ToString();
            try
            {
                using (var db = DapperDao.GetInstance())
                {
                    data = db.Query<T>(sql, null).ToList();
                    // data = db.Query<T>(AppendFormat, new { tablename = tablename, wheresql = wheresql, endpage = endpage, ordefield = ordefield, startpage = startpage }).ToList();
                    total = db.Query<int>(countsql, null).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                log4netHelper.Exception(ex);
            }
            return data;
        }
    }
}
