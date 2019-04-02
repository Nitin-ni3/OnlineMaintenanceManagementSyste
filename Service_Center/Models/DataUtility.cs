using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Service_Center.Models
{
    public class DataUtility
    {
        private static string Constr = ConfigurationManager.ConnectionStrings["DBCON"].ConnectionString;
        public SqlConnection con = new SqlConnection(Constr);
        public SqlCommand cmd = new SqlCommand();
        public SqlDataAdapter ad = new SqlDataAdapter();
        public DataSet ds;
        
        public DataSet BindDataset(string Query)
        {
            ds = new DataSet();
            try
            {
                ad = new SqlDataAdapter(Query,con);
                ad.Fill(ds);
            }
            catch (Exception e)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Type", typeof(string));
                table.Columns.Add("Error", typeof(string));

                table.Rows.Add("Error", e.Message);
                table.Rows.Add("0", "Error : " + e.Message);
                ds.Tables.Add(table);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return ds;
        }
    }
}