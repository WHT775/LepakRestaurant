using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Roles
    {
        public int roles_id { get; set; }
        public string role_name { get; set; }

        public Roles()
        {

        }

        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public List<Roles> RetrieveRoles()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [roles]";
                List<Roles> objUser = new List<Roles>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Roles tempObj = new Roles();
                                tempObj.roles_id = Convert.ToInt32(dr["roles_id"].ToString());
                                tempObj.role_name = dr["ROLE_NAME"].ToString();
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