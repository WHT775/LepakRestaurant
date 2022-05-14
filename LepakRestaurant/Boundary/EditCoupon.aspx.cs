using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class EditCoupon : System.Web.UI.Page
    {
        CouponController cc = new CouponController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var couponDetails = cc.RetrieveCouponById(Convert.ToInt32(HttpContext.Current.Session["editcouponid"].ToString()));
                txtCode.Text = couponDetails.coupon_code;
                txtDiscount.Text = couponDetails.discount_amt.ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string msg = cc.UpdateCoupon(Convert.ToInt32(HttpContext.Current.Session["editcouponid"].ToString()), txtCode.Text.Trim(),txtDiscount.Text);
            if (msg == "Successfully updated coupon")
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx?q=c");
        }
    }
}