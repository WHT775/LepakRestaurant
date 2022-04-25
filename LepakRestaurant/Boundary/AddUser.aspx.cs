using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                ddlRole.DataSource= uc.PopulateRoleDDL();
                ddlRole.DataBind();
            }
            else
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           string msg = uc.CreateUser(txtLoginId.Text,txtPassword.Text,Convert.ToInt32(ddlRole.SelectedValue),Convert.ToBoolean(ddlDisabled.SelectedValue));
            if(msg != "True")
            {
                lblWrong.Text = msg;
                lblWrong.Visible = true;
            }
            else
            {
                Response.Redirect("Owner.aspx");
            }
            //run using clientScript.Register
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owner.aspx");
        }
    }
}