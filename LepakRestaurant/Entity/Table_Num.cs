using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Table_Num : DataContext
    {
        public int table_num_id { get; set; }

        public string unique_code { get; set; }

        public Table_Num()
        {

        }

        public int getTableNum(string code)
        {
            int table_id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select TABLE_NUM_ID from TABLE_NUM where UNIQUE_CODE = @code";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@code", code);
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                table_id = Convert.ToInt32(dr["TABLE_NUM_ID"].ToString());

                            }
                        }
                    }
                }
            }
            return table_id;
        }
    }
}