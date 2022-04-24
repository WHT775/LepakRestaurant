using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LepakRestaurant.Controller;

namespace LepakRestaurant.Boundary
{
    public partial class CustomerLogin1 : System.Web.UI.Page
    {
        CustomerController cc = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            custDiv.Visible = false;
        }

        protected void btnCode_Click(object sender, EventArgs e)
        {
            if (phoneTxt.Text != null || phoneTxt.Text != "")
            {
                bool isExist = cc.checkExistingCustomer(phoneTxt.Text);
                if (isExist)
                {
                    Response.Redirect("");
                }
                else
                {
                    custDiv.Visible = true;
                    btnCode.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "")
            {
                cc.createCustomer(nameTxt.Text, phoneTxt.Text);
                Response.Redirect("");
            }
        }
    }
}