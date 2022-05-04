using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Order_Summary : DataContext
    {
        public int order_sum_id { get; set; }

        public int fk_orders_id { get; set; }

        public int fk_menu_id { get; set; }

        public int quantity { get; set; }

        public Orders orders { get; set; }

        public Menu menu { get; set; }
        public int _oid { get; set; }

        public Order_Summary()
        {
            orders = new Orders();
            orders.orders_id = _oid;
            menu = new Menu();
        }

        public List<Order_Summary> GetAllPendingOrders()
        {
            List<Order_Summary> OrderList = new List<Order_Summary>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select os.quantity, o.table_num_id, o.ORDERS_ID, o.total_amt, m.item_name from [ORDER_SUMMARY] as os join [ORDERS] as o on os.orders_id = o.orders_id join [MENU] as m on os.MENU_ID = m.MENU_ID WHERE o.ORDERS_STATUS = 'Pending'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Order_Summary tempObj = new Order_Summary();
                                tempObj.quantity = Convert.ToInt32(dr["quantity"].ToString());
                                tempObj.orders.fk_table_num_id = Convert.ToInt32(dr["table_num_id"].ToString());
                                tempObj.orders.orders_id = Convert.ToInt32(dr["ORDERS_ID"].ToString());
                                tempObj.orders.total_amt = Convert.ToDouble(dr["total_amt"].ToString());
                                tempObj.menu.item_name = dr["item_name"].ToString();
                                OrderList.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return OrderList;
        }

        public string CancelOrderById()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [ORDERS] SET ORDERS_STATUS = 'Cancelled' WHERE ORDERS_ID = @orderid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderid", _oid);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return "Successfully cancelled order";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        public string CompleteOrderById()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [ORDERS] SET ORDERS_STATUS = 'Completed' WHERE ORDERS_ID = @orderid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderid", _oid);
                    conn.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                        return "Successfully completed order";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }

        public string InsertOrderSummary(int orderId, int menuId, int qty)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [ORDER_SUMMARY] VALUES (@OrderId,@menuId,@qty)";
                string result = "Success";
                List<User> objUser = new List<User>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    cmd.Parameters.AddWithValue("@menuId", menuId);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    conn.Open();
                    try
                    {
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
    }
}