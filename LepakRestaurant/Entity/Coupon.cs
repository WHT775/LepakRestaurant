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

        public string expiry_date { get; set; }
        public Coupon()
        {

        }

        public bool InsertCoupon()
        {

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [COUPON] VALUES(@couponcode,@discountamt,@expirydate)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    cmd.Parameters.AddWithValue("@discountamt", discount_amt);
                    cmd.Parameters.AddWithValue("@expirydate", expiry_date);
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
            bool yes = false;
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
                            yes = true;
                        }
                        else
                            yes = false;
                        return yes;
                    }
                }
            }
        }

        public bool CheckIfCouponExpired()
        {
            bool yes = true;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT EXPIRY_DATE FROM [COUPON] WHERE UPPER(COUPON_CODE) = @couponcode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                DateTime expiry = Convert.ToDateTime(dr["EXPIRY_DATE"].ToString());
                                if (expiry > DateTime.Now)
                                    yes = false;
                                else
                                    yes = true;
                            }
                        }
                        return yes;
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
                                tempObj.expiry_date = DateTime.Parse(dr["EXPIRY_DATE"].ToString()).ToString("yyyy-MMM-dd");
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
                                resultObj.expiry_date = dr["EXPIRY_DATE"].ToString();
                            }
                        }
                    }
                    return resultObj;
                }
            }
        }

        public Coupon RetrieveCouponByCode()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [COUPON] WHERE COUPON_Code = @couponCode";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponCode", coupon_code);
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
                string query = "UPDATE [COUPON] set COUPON_CODE=@couponcode, DISCOUNT_AMT=@discountamt, EXPIRY_DATE=@expirydate where COUPON_ID = @couponid";
                string result = "Successfully updated coupon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@couponid", coupon_id);
                    cmd.Parameters.AddWithValue("@couponcode", coupon_code);
                    cmd.Parameters.AddWithValue("@discountamt", discount_amt);
                    cmd.Parameters.AddWithValue("@expirydate", expiry_date);
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