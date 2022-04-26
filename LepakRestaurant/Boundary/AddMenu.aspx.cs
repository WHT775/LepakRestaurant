using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class AddMenu : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CustomerMenuController uc = new CustomerMenuController();
                ddlCategory.DataSource = uc.getListOfCategory();
                ddlCategory.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}