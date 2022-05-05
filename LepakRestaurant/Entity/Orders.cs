using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Orders : DataContext
    {
        public int orders_id { get; set; }

        public double total_amt { get; set; }

        public string orders_status { get; set; }

        public int fk_table_num_id { get; set; }

        public int fk_customer_id { get; set; }

        public Order_Cancel order_cancel { get; set; }
        
        public Orders()
        {
            order_cancel = new Order_Cancel();
        }

        public Orders(int oid)
        {
            orders_id = oid;
        }

        public string InsertOrder(double total_amt, string orderStatus, int tableId, int custId)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [ORDERS] VALUES (@total_amt,@order_status,@table_num_id,@customer_id)";
                string result = "Success";
                List<User> objUser = new List<User>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@total_amt", total_amt);
                    cmd.Parameters.AddWithValue("@order_status", orderStatus);
                    cmd.Parameters.AddWithValue("@table_num_id", tableId);
                    cmd.Parameters.AddWithValue("@customer_id", custId);
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

        public int getLatestOrderId()
        {
            int orderId = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select max(ORDERS_ID) as ORDERS_ID from ORDERS";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                orderId = Convert.ToInt32(dr["ORDERS_ID"].ToString());
                                
                            }
                        }
                    }
                }
            }
            return orderId;
        }
    }
}