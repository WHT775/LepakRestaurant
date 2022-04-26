using System;
using System.Collections.Generic;
using System.Data;
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

        public int category_id { get; set; }

        public Menu()
        {

        }

        public DataSet retrieveItemsByCategory(string item_category)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select * from Menu m inner join CATEGORY c on c.CATEGORY_ID = M.CATEGORY_ID where CATEGORY_NAME = @itemcategory";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if(item_category !="")
                        cmd.Parameters.AddWithValue("@itemcategory", item_category);
                    else
                        cmd.Parameters.AddWithValue("@itemcategory", "Rice");
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    //using (SqlDataReader dr = cmd.ExecuteReader())
                    //{
                    //    if (dr.HasRows)
                    //    {
                    //        List<string> tempList = new List<string>();
                    //        while (dr.Read())
                    //        {
                    //            tempList.Add(dr["ITEM_CATEGORY"].ToString());
                    //        }
                    //        categoryList = tempList.ToArray();
                    //    }
                    //}
                }
            }
            return ds;
        }

        public List<Menu> retrieveItemByCategory(int item_category)
        {
            List<Menu> menuList = new List<Menu>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select * from Menu where CATEGORY_ID = @itemcategory";
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
                                tempObj.category_id = Convert.ToInt32(dr["CATEGORY_ID"].ToString());
                                menuList.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return menuList;
        }

        public DataSet retrieveListOfCategory()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select CATEGORY_NAME from CATEGORY";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    //using (SqlDataReader dr = cmd.ExecuteReader())
                    //{
                    //    if (dr.HasRows)
                    //    {
                    //        List<string> tempList = new List<string>();
                    //        while (dr.Read())
                    //        {
                    //            tempList.Add(dr["ITEM_CATEGORY"].ToString());
                    //        }
                    //        categoryList = tempList.ToArray();
                    //    }
                    //}
                }
            }
            return ds;
        }


    }
}