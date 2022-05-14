using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class AddCoupon : System.Web.UI.Page
    {
        CouponController cc = new CouponController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx?q=c");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string msg = cc.CreateCoupon(txtCode.Text.Trim(),txtDiscount.Text.Trim(),txtExpiryDate.Text.Trim());
            if (msg == "Successfully created coupon")
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(msg);
                sb.Append("');window.location='Manager.aspx?q=c';};");
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