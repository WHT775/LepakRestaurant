using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Menu
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public int menu_id { get; set; }

        public string item_name { get; set; }

        public string item_desc { get; set; }

        public double item_price { get; set; }

        public string item_img { get; set; }

        public string item_category { get; set; }

        public Menu()
        {

        }

        public List<Menu> retrieveItemByCategory(string item_category)
        {
            List<Menu> menuList = new List<Menu>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select * from Menu where ITEM_CATEGORY = @itemcategory";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemcategory", item_category);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Menu tempObj = new Menu();
                                tempObj.menu_id = Convert.ToInt32(dr["MENU_ID"].ToString());
                                tempObj.item_name = dr["ITEM_NAME"].ToString();
                                tempObj.item_desc = dr["ITEM_DESC"].ToString();
                                tempObj.item_price = Convert.ToDouble(dr["ITEM_PRICE"].ToString());
                                tempObj.item_img = dr["ITEM_IMG"].ToString();
                                tempObj.item_category = dr["ITEM_CATEGORY"].ToString();
                                menuList.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return menuList;
        }

        public string[] retrieveListOfCategory()
        {
            string[] categoryList = new string[] { };
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select distinct(ITEM_CATEGORY) from Menu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            List<string> tempList = new List<string>();
                            while (dr.Read())
                            {
                                tempList.Add(dr["ITEM_CATEGORY"].ToString());
                            }
                            categoryList = tempList.ToArray();
                        }
                    }
                }
            }
            return categoryList;
        }


    }
}