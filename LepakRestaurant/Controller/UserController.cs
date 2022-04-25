using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LepakRestaurant.Entity;


namespace LepakRestaurant.Controller
{
    public class UserController
    {

        public string LoginUser(string username, string password)
        {
            if (username == "" && password.Length == 0)
            {
                return "Please key in credentials";
            }
            else
            {
                User ue = new User() { user_id = username, user_pw = password };
                User ucObj = ue.CheckIfUserInDB();
                if (ucObj.id == 0)
                {
                    return "Incorrect user/password.";
                }
                else
                {
                    //User found, proceed to check if its disabled
                    ue = new User() { id = ucObj.id };
                    ue = ue.RetrieveUserById();
                    if (ue.is_deleted)
                    {
                        //Account Disabled
                        return "Account blocked<br/>Please contact system administrator";
                    }
                    else
                    {
                        HttpContext.Current.Session["id"] = ue.id;
                        HttpContext.Current.Session["user_id"] = ue.user_id;
                        HttpContext.Current.Session["user_pw"] = ue.user_pw;
                        return ue.fk_roles_id.ToString();
                    }
                }
            }
        }

        public string CreateUser(string username, string password, int role, bool isdisabled)
        {
            User ue = new User() { user_id = username, user_pw = password, fk_roles_id = role, is_deleted = isdisabled };
            if (ue.CheckIfUserExist())
            {
                return "User Exist";
            }
            else
            {
                string msg = ue.InsertUser();
                return msg;
            }
        }

        public List<Roles> PopulateRoleDDL()
        {
            Roles re = new Roles();
            List<Roles> role = new List<Roles>();
            role = re.RetrieveRoles();
            return role;
        }

        public List<User> PopulateGridViewUsers()
        {
            User ue = new User() { };
            List<User> ueList = new List<User>();
            ueList = ue.RetrieveUsers();
            return ueList;
        }

        public string DeleteUser(int userid)
        {
            User ue = new User() { id = userid };
            return ue.DeleteUser();

        }
        public User RetrieveUserById(int userid)
        {
            User ue = new User() { id = userid };
            return ue.RetrieveUserById();
        }

        public string UpdateUserProfile(string username, string password, int roleid, bool isdisabled, int id)
        {
            User ue = new User() { id=id ,user_id = username, user_pw = password, fk_roles_id = roleid, is_deleted = isdisabled };
            string msg = ue.UpdateUserProfile();
            if (msg == "No issue")
            {
                return "No issue";
            }
            else
            {
                throw new Exception(msg);
            }

        }
    }
}