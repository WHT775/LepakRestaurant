using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class EditUser : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlRole.DataSource = uc.PopulateRoleDDL();
                ddlRole.DataBind();
                var userDetails = uc.RetrieveUserById(Convert.ToInt32(HttpContext.Current.Session["edituserid"].ToString()));
                txtLoginId.Text = userDetails.user_id;
                txtPassword.Text = userDetails.user_pw;
                ddlRole.SelectedValue = userDetails.fk_roles_id.ToString();
                ddlDisabled.SelectedValue = userDetails.is_deleted.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(uc.UpdateUserProfile(txtLoginId.Text, txtPassword.Text, Convert.ToInt32(ddlRole.SelectedValue), Convert.ToBoolean(ddlDisabled.SelectedValue), Convert.ToInt32(HttpContext.Current.Session["edituserid"].ToString())) == "No issue")
            {
                Response.Redirect("Owner.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            Response.Redirect("Owner.aspx");
        }
    }
}