using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Menu : DataContext
    {

        public int menu_id { get; set; }

        public string item_name { get; set; }

        public string item_desc { get; set; }

        public double item_price { get; set; }

        public string item_img { get; set; }

        public int category_id { get; set; }

        public Category category { get; set; }

        public Menu()
        {
            category = new Category();
        }

        public DataSet retrieveItemsByCategory(string item_category)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "";
                if (item_category != "")
                    query = "select * from Menu m inner join CATEGORY c on c.CATEGORY_ID = M.CATEGORY_ID where CATEGORY_NAME = @itemcategory";
                else
                    query = "select * from Menu m inner join CATEGORY c on c.CATEGORY_ID = M.CATEGORY_ID where m.CATEGORY_ID = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (item_category != "")
                        cmd.Parameters.AddWithValue("@itemcategory", item_category);

                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
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
                }
            }
            return ds;
        }

        public bool CreateMenu()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO MENU VALUES(@itemname,@itemdesc,@itemprice,@itemimg,@categoryid)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemname", item_name);
                    cmd.Parameters.AddWithValue("@itemdesc", item_desc);
                    cmd.Parameters.AddWithValue("@itemprice", item_price);
                    cmd.Parameters.AddWithValue("@itemimg", item_img);
                    cmd.Parameters.AddWithValue("@categoryid", category_id);
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

        public string DeleteMenu()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM [MENU] where MENU_ID=@menuid";
                string result = "Menu deleted successfully";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menuid", menu_id);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        result = e.Message;
                    }
                }
                return result;
            }
        }
        public bool UpdateMenu()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [Menu] SET ITEM_NAME = @itemname, ITEM_DESCRIPTION = @itemdesc, ITEM_PRICE = @itemprice, ITEM_IMG = @itemimg, CATEGORY_ID = @categoryid WHERE MENU_ID = @menuid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menuid", menu_id);
                    cmd.Parameters.AddWithValue("@itemname", item_name);
                    cmd.Parameters.AddWithValue("@itemdesc", item_desc);
                    cmd.Parameters.AddWithValue("@itemprice", item_price);
                    cmd.Parameters.AddWithValue("@itemimg", item_img);
                    cmd.Parameters.AddWithValue("@categoryid", category_id);
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

        public bool CheckIfImageNameIsUnique()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select ITEM_IMG from [MENU] where ITEM_IMG = @itemimg";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@itemimg", this.item_img);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return false;
                        }
                        return true;
                    }
                }
            }
        }
        public List<Menu> RetrieveAllMenu()
        {
            List<Menu> menuList = new List<Menu>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select menu_id, item_name, item_description, item_price, item_img, m.category_id,category_name from Menu as m join category as c on m.category_id = c.category_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
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
                                tempObj.item_desc = dr["ITEM_DESCRIPTION"].ToString();
                                tempObj.item_price = Convert.ToDouble(dr["ITEM_PRICE"].ToString());
                                tempObj.item_img = dr["ITEM_IMG"].ToString();
                                //tempObj.category_id = Convert.ToInt32(dr["category_id"].ToString());
                                tempObj.category.category_name = dr["category_name"].ToString();
                                menuList.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return menuList;
        }
        public Menu RetrieveMenuByMenuId()
        {
            Menu tempObj = new Menu();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM MENU WHERE MENU_ID = @menuid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@menuid", menu_id);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                tempObj.menu_id = Convert.ToInt32(dr["MENU_ID"].ToString());
                                tempObj.item_name = dr["ITEM_NAME"].ToString();
                                tempObj.item_desc = dr["ITEM_DESCRIPTION"].ToString();
                                tempObj.item_price = Convert.ToDouble(dr["ITEM_PRICE"].ToString());
                                tempObj.item_img = dr["ITEM_IMG"].ToString();
                                tempObj.category_id = Convert.ToInt32(dr["category_id"].ToString());
                                //tempObj.category.category_name = dr["category_name"].ToString();
                            }
                        }
                    }
                }
            }
            return tempObj;
        }
    }
}