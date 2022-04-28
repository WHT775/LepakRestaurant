using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class EditMenu : System.Web.UI.Page
    {
        MenuController mc = new MenuController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = mc.getListOfCategory();
                ddlCategory.DataBind();
                var menuDetails = mc.getMenuByMenuId(Convert.ToInt32(HttpContext.Current.Session["editmenuid"].ToString()));
                txtName.Text = menuDetails.item_name;
                txtDescription.Text = menuDetails.item_desc;
                txtCost.Text = Convert.ToDouble(menuDetails.item_price).ToString();
                ddlCategory.SelectedValue = menuDetails.category_id.ToString();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] msg = mc.UpdateMenu(Convert.ToInt32(HttpContext.Current.Session["editmenuid"].ToString()), txtName.Text.Trim(),txtDescription.Text.Trim(),txtCost.Text,fUpload.PostedFile,ddlCategory.SelectedValue);
            if (msg[0] == "Successfully updated menu")
            {
                if(fUpload.HasFile)
                {
                    fUpload.SaveAs(Server.MapPath("images/" + msg[1]));
                }
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg[0]);
                sb.Append("');window.location='Manager.aspx';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                //Response.Redirect("Manager.aspx");
            }
            else
            {
                lblWrong.Text = msg[0];
                lblWrong.Visible = true;
            }
        }
    }
}