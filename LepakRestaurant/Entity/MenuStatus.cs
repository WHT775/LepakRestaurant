using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class MenuStatus : DataContext
    {
        public int status_id { get; set; }

        public string status_name { get; set; }

        public MenuStatus()
        {

        }
        public List<MenuStatus> RetrieveMenuStatus()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [MENUSTATUS]";
                List<MenuStatus> objUser = new List<MenuStatus>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                MenuStatus tempObj = new MenuStatus();
                                tempObj.status_id = Convert.ToInt32(dr["STATUS_ID"].ToString());
                                tempObj.status_name = dr["STATUS_NAME"].ToString();
                                objUser.Add(tempObj);
                            }
                        }
                    }
                    return objUser;
                }
            }
        }
    }
}