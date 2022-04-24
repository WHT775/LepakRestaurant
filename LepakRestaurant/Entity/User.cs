using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class User
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public int id { get; set; }

        public string user_id { get; set; }

        public string user_pw { get; set; }

        public int is_deleted { get; set; }

        public int fk_roles_id { get; set; }

        public User()
        {

        }

        public User CheckUserInDB()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from user where USER_ID = @userid and USER_PW = @userpw";
                User objUser = new User();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.user_id);
                    cmd.Parameters.AddWithValue("@userpw", this.user_pw);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                User tempObj = new User();
                                tempObj.user_id = dr["USER_ID"].ToString();
                                tempObj.user_pw = dr["USER_PW"].ToString();
                                tempObj.is_deleted = Convert.ToInt32(dr["IS_DELETED"].ToString());
                                tempObj.fk_roles_id = Convert.ToInt32(dr["ROLES_ID"].ToString());
                            }
                        }
                    }
                    return objUser;
                }



            }

        }
    }
}