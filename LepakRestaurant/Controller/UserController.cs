using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LepakRestaurant.Entity;


namespace LepakRestaurant.Controller
{
    public class UserController
    {

        public string LoginUser(string username,string password)
        {
            User uc = new User() { user_id=username, user_pw=password };
            uc.CheckUserInDB();
            return "";
        }
    }
}