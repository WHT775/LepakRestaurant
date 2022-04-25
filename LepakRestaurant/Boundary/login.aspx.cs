using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class login : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string msg = uc.LoginUser(txtUser.Text.Trim(), txtPass.Text.Trim());
            if (msg == "1")//Owner
                Response.Redirect("Owner.aspx");
            else if (msg == "2")//Manager
                Response.Redirect("Manager.aspx");
            else if (msg == "3")//Staff
                Response.Redirect("Staff.aspx");
            else
                lblWrong.Text = msg;
            lblWrong.Visible = true;
        }
    }
}