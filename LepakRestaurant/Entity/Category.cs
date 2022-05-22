using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Category :DataContext
    {
        public int category_id { get; set; }

        public string category_name { get; set; }

        public Category()
        {

        }
        public Category(int category_id)
        {
            this.category_id = category_id;
        }

        public Category(string category_name)
        {
            this.category_name = category_name;
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

        public string RetrieveCategoryById()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [CATEGORY] WHERE CATEGORY_ID = @categoryid";
                string categoryName = "No Category";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryid", this.category_id);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                categoryName = dr["CATEGORY_NAME"].ToString();
                            }
                        }
                    }
                    return categoryName;
                }
            }
        }

        public string DeleteCategory()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM [CATEGORY] where CATEGORY_ID = @categoryid";
                string result = "Category deleted successfully";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryid", this.category_id);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        result = e.Message;
                    }
                    return result;
                }
            }
        }

        public string UpdateCategory()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [CATEGORY] set CATEGORY_NAME=@categoryName where CATEGORY_ID = @categoryid";
                string result = "Successfully updated category";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryid", this.category_id);
                    cmd.Parameters.AddWithValue("@categoryName", this.category_name);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        result = e.Message;
                    }
                    return result;
                }
            }
        }

        public bool InsertCategory()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [CATEGORY] VALUES(@categoryname)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryname", this.category_name);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
        public bool CheckIfCategoryExist()
        {
            bool yes = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT CATEGORY_NAME FROM [CATEGORY] WHERE UPPER(CATEGORY_NAME) = @categoryname";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@categoryname", this.category_name);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            yes = true;
                        }
                        else
                            yes = false;
                        return yes;
                    }
                }
            }
        }

    }
}