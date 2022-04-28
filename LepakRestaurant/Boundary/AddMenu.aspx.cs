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
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] msg = mc.createMenu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), fUpload.PostedFile, Convert.ToInt32(ddlCategory.SelectedValue));
            if (msg[0] == "Successfully created menu")
            {
                if(msg[1] != "")
                {
                    fUpload.SaveAs(Server.MapPath("images/" + msg[1]));
                }
                Response.Redirect("Manager.aspx");
            }
            else
            {
                lblWrong.Text = msg[0];
                lblWrong.Visible = true;
            }
        }
    }
}