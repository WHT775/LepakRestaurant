using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Order_Cancel : DataContext
    {
        public int order_cancel_id { get; set; }

        public int fk_order_cancel_id { get; set; }

        public string reason { get; set; }

        public List<Order_Cancel> RetrieveInsightsCancelOrder()
        {
            DataSet ds = new DataSet();
            List<Order_Cancel> objOrder_Summary = new List<Order_Cancel>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT ROW_NUMBER() OVER(ORDER BY reason ASC) AS RowNum, reason FROM order_cancel";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Order_Cancel tempObj = new Order_Cancel();
                                tempObj.fk_order_cancel_id = Convert.ToInt32(dr["RowNum"].ToString());
                                tempObj.reason = dr["reason"].ToString();
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