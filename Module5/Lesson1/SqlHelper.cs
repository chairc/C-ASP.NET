using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Lesson1
{
    public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["itcast"].ConnectionString;
        public static int ExecuteNonQuery(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public static object ExecuteScalar(string sql, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    con.Open();
                    return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            {
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
