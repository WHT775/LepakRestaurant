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
        public List<Coupon> RetrieveAllCoupon()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [COUPON]";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    List<Coupon> resultObj = new List<Coupon>();
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Coupon tempObj = new Coupon();
                                tempObj.coupon_id = Convert.ToInt32(dr["COUPON_ID"].ToString());
                                tempObj.coupon_code = dr["COUPON_CODE"].ToString();
                                tempObj.discount_amt = Convert.ToDouble(dr["DISCOUNT_AMT"].ToString());
                                resultObj.Add(tempObj);
                            }
                        }
                    }
                    return resultObj;
                }
            }
        }
        public Coupon RetrieveCouponById()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [COUPON] WHERE COUPON_ID = @couponid";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponid", coupon_id);
                    Coupon resultObj = new Coupon();
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                resultObj.coupon_code = dr["COUPON_CODE"].ToString();
                                resultObj.discount_amt = Convert.ToDouble(dr["DISCOUNT_AMT"].ToString());
                            }
                        }
                    }
                    return resultObj;
                }
            }
        }
        public string DeleteCoupon()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM [COUPON] where COUPON_ID = @couponid";
                string result = "Coupon deleted successfully";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponid", coupon_id);
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
        public string UpdateCoupon()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [COUPON] set COUPON_CODE=@couponcode, DISCOUNT_AMT=@discountamt where COUPON_ID = @couponid";
                string result = "Successfully updated coupon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponid", coupon_id);
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    cmd.Parameters.AddWithValue("@discountamt", discount_amt);
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
    }
}