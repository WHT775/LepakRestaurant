using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class AddMenu : System.Web.UI.Page
    {
        MenuController mc = new MenuController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = mc.getListOfCategory();
                ddlCategory.DataBind();
                ddlStatus.DataSource = mc.getListOfMenuStatus();
                ddlStatus.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx?q=m");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] msg = mc.createMenu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), fUpload.PostedFile, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue));
            if (msg[0] == "Successfully created menu")
            {
                if(msg[1] != "")
                {
                    fUpload.SaveAs(Server.MapPath("images/" + msg[1]));
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg[0]);
                sb.Append("');window.location='Manager.aspx?q=m';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                lblWrong.Text = msg[0];
                lblWrong.Visible = true;
            }
        }
    }
}