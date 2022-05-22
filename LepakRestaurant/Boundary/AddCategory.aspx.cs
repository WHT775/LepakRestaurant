using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LepakRestaurant.Controller;

namespace LepakRestaurant.Boundary
{
    public partial class AddCategory : System.Web.UI.Page
    {
        MenuController mc = new MenuController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx?q=cc");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string msg = mc.CreateCategory(txtCategory.Text.Trim());
            if (msg == "Successfully created category")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("');window.location='Manager.aspx?q=cc';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                lblWrong.Text = msg;
                lblWrong.Visible = true;
            }
        }
    }
}