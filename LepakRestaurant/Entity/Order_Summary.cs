using System;
using System.Collections.Generic;
using System.Data;
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

        public Order_Cancel order_cancel { get; set; }

        public string _reason { get; set; }

        public Customer customer { get; set; }
        public string _customername { get; set; }

        public DateTime _lastvisit { get; set; }

        public Order_Summary()
        {
            orders = new Orders();
            orders.orders_id = _oid;
            menu = new Menu();
            order_cancel = new Order_Cancel();
            order_cancel.reason = _reason;
            customer = new Customer();
            customer.customer_name = _customername;
            customer.last_visit = _lastvisit;

        }

        public List<Order_Summary> GetAllPendingOrders()
        {
            List<Order_Summary> OrderList = new List<Order_Summary>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //string query = "select os.quantity, o.table_num_id, o.ORDERS_ID, o.total_amt, m.item_name from [ORDER_SUMMARY] as os join [ORDERS] as o on os.orders_id = o.orders_id join [MENU] as m on os.MENU_ID = m.MENU_ID WHERE o.ORDERS_STATUS = 'Pending'";
                string query = "select distinct o.ORDERS_ID, o.table_num_id from [ORDER_SUMMARY] as os join [ORDERS] as o on os.orders_id = o.orders_id join [MENU] as m on os.MENU_ID = m.MENU_ID WHERE o.ORDERS_STATUS = 'Pending'";
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
                                tempObj.orders.orders_id = Convert.ToInt32(dr["ORDERS_ID"].ToString());
                                //tempObj.orders.total_amt = Convert.ToDouble(dr["total_amt"].ToString());
                                tempObj.orders.fk_table_num_id = Convert.ToInt32(dr["table_num_id"].ToString());
                                OrderList.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return OrderList;
        }

        public List<Order_Summary> RetrieveAllMenuByOrderId()
        {
            List<Order_Summary> OrderList = new List<Order_Summary>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select os.quantity, m.item_price, m.item_name from [ORDER_SUMMARY] as os join [ORDERS] as o on os.orders_id = o.orders_id join [MENU] as m on os.MENU_ID = m.MENU_ID WHERE o.ORDERS_STATUS = 'Pending' and o.orders_id = @orderid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderid", _oid);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Order_Summary tempObj = new Order_Summary();
                                tempObj.quantity = Convert.ToInt32(dr["quantity"].ToString());
                                tempObj.menu.item_price = Convert.ToDouble(dr["item_price"].ToString());
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

        public string InsertCancelOrderReason()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO ORDER_CANCEL VALUES(@orderid,@reason)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@orderid", _oid);
                    cmd.Parameters.AddWithValue("@reason", _reason);
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

        public List<Order_Summary> RetrieveInsights()
        {
            DataSet ds = new DataSet();
            List<Order_Summary> objOrder_Summary = new List<Order_Summary>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "select top 1 c.customer_name, c.last_visit, avg(total_amt) as 'Avgspent', item_name, count(os.menu_id ) as Frequency from [customer] as c join orders as o on c.customer_id = o.customer_id  join order_summary as os on o.orders_id = os.orders_id " +
                    "join menu as m on os.menu_id = m.menu_id where orders_status = 'Completed' " +
                    "group by c.customer_id,  customer_name, item_name, last_visit";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Order_Summary tempObj = new Order_Summary();
                                tempObj.customer.customer_name = dr["customer_name"].ToString();
                                tempObj.customer.last_visit = Convert.ToDateTime(dr["last_visit"].ToString());
                                tempObj.menu.item_name = dr["item_name"].ToString();
                                tempObj.orders.total_amt = Convert.ToDouble(dr["Avgspent"].ToString());
                                objOrder_Summary.Add(tempObj);
                            }
                        }
                    }
                }
            }
            return objOrder_Summary;
        }
    }
}