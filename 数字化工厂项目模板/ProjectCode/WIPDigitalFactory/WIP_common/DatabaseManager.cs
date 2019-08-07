using SysManager.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WIP_common
{
    public class DatabaseManager
    {
        public string Constr;

        public DatabaseManager()
        {
            Constr = DESEncryptHelper.Decrypt(ConfigurationManager.ConnectionStrings["SOACon"].ToString());
        }


        public DataTable GetSqlTableWithUsing(SqlCommand cmd)
        {
            using (var con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                using (cmd)
                {
                    var dt = new DataTable("SqlTable");
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public string ReturnFirstResult(SqlCommand cmd)
        {
            using (var con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                con.Open();
                using (cmd)
                {
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }

        public bool ExecProcWithUsing(SqlCommand cmd)
        {
            using (var con = new SqlConnection(Constr))
            {
                cmd.Connection = con;
                using (cmd)
                {
                    try
                    {
                        con.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch
                    {

                        throw;
                    }
                }
            }
        }
    }
}
