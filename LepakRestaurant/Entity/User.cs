using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class User
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public int id { get; set; }

        public string user_id { get; set; }

        public string user_pw { get; set; }

        public bool is_deleted { get; set; }

        public int fk_roles_id { get; set; }

        public Roles Roles { get; set; }


        public User()
        {
            Roles = new Roles();
        }

        public User CheckIfUserInDB()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [user] where UPPER(USER_ID) = @userid and USER_PW = @userpw";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.user_id.ToUpper());
                    cmd.Parameters.AddWithValue("@userpw", this.user_pw);
                    conn.Open();
                    User tempObj = new User();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                tempObj.id = Convert.ToInt32(dr["id"].ToString());
                                tempObj.user_id = dr["USER_ID"].ToString();
                                tempObj.user_pw = dr["USER_PW"].ToString();
                                tempObj.is_deleted = Convert.ToBoolean(dr["IS_DELETED"].ToString());
                                tempObj.fk_roles_id = Convert.ToInt32(dr["ROLES_ID"].ToString());
                            }
                        }
                    }
                    return tempObj;
                }
            }
        }
        public string InsertUser()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO [USER] VALUES (@userid,@userpw,@isdeleted,@roleid)";
                string result = "True";
                List<User> objUser = new List<User>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.user_id.ToUpper());
                    cmd.Parameters.AddWithValue("@userpw", this.user_pw);
                    cmd.Parameters.AddWithValue("@isdeleted", this.is_deleted);
                    cmd.Parameters.AddWithValue("@roleid", this.fk_roles_id);
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
        public bool CheckIfUserExist()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * from [User] where UPPER(user_id) = @userid";
                bool result = false;
                List<User> objUser = new List<User>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.user_id.ToUpper());
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            result = true;
                        }
                    }
                    return result;
                }
            }
        }

        public List<User> RetrieveUsers()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT id,user_id,user_pw,is_deleted,u.roles_id,role_name from [User] as u join [Roles] as r on u.roles_id = r.roles_id";
                List<User> objUser = new List<User>();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                User tempObj = new User();
                                tempObj.id = Convert.ToInt32(dr["ID"].ToString());
                                tempObj.user_id = dr["USER_ID"].ToString();
                                tempObj.user_pw = dr["USER_PW"].ToString();
                                tempObj.is_deleted = Convert.ToBoolean(dr["IS_DELETED"].ToString());
                                tempObj.fk_roles_id = Convert.ToInt32(dr["ROLES_ID"].ToString());
                                tempObj.Roles.role_name = dr["ROLE_NAME"].ToString();
                                objUser.Add(tempObj);
                            }
                        }
                    }
                    return objUser;
                }
            }
        }

        public string DeleteUser()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM [USER] where id = @id";
                string result = "User deleted successfully";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", this.id);
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
        public User RetrieveUserById()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "Select * from [USER] where id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    User tempObj = new User();
                    cmd.Parameters.AddWithValue("@id", this.id);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())  // or load a DataTable, ExecuteScalar, etc.    
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                tempObj.id = Convert.ToInt32(dr["ID"].ToString());
                                tempObj.user_id = dr["USER_ID"].ToString();
                                tempObj.user_pw = dr["USER_PW"].ToString();
                                tempObj.is_deleted = Convert.ToBoolean(dr["IS_DELETED"].ToString());
                                tempObj.fk_roles_id = Convert.ToInt32(dr["ROLES_ID"].ToString());
                                //objUser.Add(tempObj);
                            }
                        }
                    }
                    return tempObj;
                }
            }
        }
        public string UpdateUserProfile()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE [USER] set USER_ID=@userid, USER_PW=@userpw, IS_DELETED=@isdeleted, ROLES_ID=@roleid where id = @id";
                string result = "No issue";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userid", this.user_id);
                    cmd.Parameters.AddWithValue("@userpw", this.user_pw);
                    cmd.Parameters.AddWithValue("@isdeleted", this.is_deleted);
                    cmd.Parameters.AddWithValue("@roleid", this.fk_roles_id);
                    cmd.Parameters.AddWithValue("@id", this.id);
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