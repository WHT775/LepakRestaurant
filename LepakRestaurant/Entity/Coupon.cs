using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Coupon : DataContext
    {
        public int coupon_id { get; set; }

        public string coupon_code { get; set; }

        public double discount_amt { get; set; }

        public Coupon()
        {

        }

        public bool InsertCoupon()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [COUPON] VALUES(@couponcode,@discountamt)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    cmd.Parameters.AddWithValue("@discountamt", discount_amt);
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
        public bool CheckIfCouponExist()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT COUPON_CODE FROM [COUPON] WHERE UPPER(COUPON_CODE) = @couponcode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
        }

    }
}