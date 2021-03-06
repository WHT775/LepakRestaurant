using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Customer : DataContext
    {

        public int id { get; set; }

        public string customer_name { get; set; }

        public string phone_num { get; set; }

        public DateTime last_visit { get; set; }

        public Customer(string phone_num)
        {
            this.phone_num = phone_num;
        }

        public Customer()
        {

        }

        public void CheckExistingCustomer()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from CUSTOMER where PHONE_NUM = @phonenum";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@phonenum", this.phone_num);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                this.id = Convert.ToInt32(dr["CUSTOMER_ID"].ToString());
                                this.customer_name = dr["CUSTOMER_NAME"].ToString();
                                this.phone_num = dr["PHONE_NUM"].ToString();
                                this.last_visit = Convert.ToDateTime(dr["LAST_VISIT"].ToString());
                            }
                        }
                    }
                }
            }
        }

        public void createCustomer(string custName, string phoneNum)
        {
            using(SqlConnection conn = new SqlConnection(connString))
            {
                string query = "insert into CUSTOMER values (@custName, @phoneNum, getdate())";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@custName", custName);
                    cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public void updateLastVisit()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "update CUSTOMER set LAST_VISIT = getdate() where CUSTOMER_ID = @custID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@custID", this.id);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public DataSet retrieveCustomerData(string item_category)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "";
                if (item_category != "")
                    query = "select * from Menu m inner join CATEGORY c on c.CATEGORY_ID = M.CATEGORY_ID where CATEGORY_NAME = @itemcategory and m.MENUSTATUS_ID = 1";
                else
                    query = "select * from Menu m inner join CATEGORY c on c.CATEGORY_ID = M.CATEGORY_ID where m.CATEGORY_ID = 1 and m.MENUSTATUS_ID = 1";
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
    }
}