using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Category : DataContext
    {
        public int category_id { get; set; }

        public string category_name { get; set; }

        public Category()
        {

        }

        public Category(int category_id, string category_name)
        {
            this.category_id = category_id;
            this.category_name = category_name;
        }

        public List<Category> RetrieveCategories()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [CATEGORY]";
                List<Category> objUser = new List<Category>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Category tempObj = new Category();
                                tempObj.category_id = Convert.ToInt32(dr["CATEGORY_ID"].ToString());
                                tempObj.category_name = dr["CATEGORY_NAME"].ToString();
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