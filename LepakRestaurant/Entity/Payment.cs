using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Payment : DataContext
    {
        public int payment_id { get; set; }

        public int fk_orders_id { get; set; }

        public int fk_customer_id { get; set; }

        public string card_type { get; set; }

        public Payment()
        {

        }

        public string insertPayment()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [PAYMENT] VALUES (@order_id,@customer_id,@cardType)";
                string result = "Success";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", fk_orders_id);
                    cmd.Parameters.AddWithValue("@customer_id", fk_customer_id);
                    cmd.Parameters.AddWithValue("@cardType", card_type);
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