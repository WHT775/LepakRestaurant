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
                CommonController ccc = new CommonController();
                var userDetails = uc.RetrieveUserById(Convert.ToInt32(HttpContext.Current.Session["edituserid"].ToString()));
                txtLoginId.Text = userDetails.user_id;
                txtPassword.Text = ccc.Decrypt(userDetails.user_pw);
                ddlRole.SelectedValue = userDetails.fk_roles_id.ToString();
                ddlDisabled.SelectedValue = userDetails.is_deleted.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string msg = uc.UpdateUserProfile(txtLoginId.Text, txtPassword.Text, Convert.ToInt32(ddlRole.SelectedValue), Convert.ToBoolean(ddlDisabled.SelectedValue), Convert.ToInt32(HttpContext.Current.Session["edituserid"].ToString()));
            if (msg == "Successfully updated user")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("');window.location='Owner.aspx?q=u';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                lblWrong.Text = msg;
                lblWrong.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Owner.aspx?q=u");
        }
    }
}