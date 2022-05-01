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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           string msg = uc.CreateUser(txtLoginId.Text,txtPassword.Text,Convert.ToInt32(ddlRole.SelectedValue),Convert.ToBoolean(ddlDisabled.SelectedValue));
            if(msg != "Successfully created user")
            {
                lblWrong.Text = msg;
                lblWrong.Visible = true;
            }
            else
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("');window.location='Owner.aspx';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owner.aspx");
        }
    }
}