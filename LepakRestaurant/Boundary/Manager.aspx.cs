using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class Manager : System.Web.UI.Page
    {
        MenuController mc = new MenuController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptMenu.DataSource = mc.RetrieveAllMenu();
                rptMenu.DataBind();
            }
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddMenu.aspx");
        }

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Image
            string imageUrl = (string)DataBinder.Eval(e.Item.DataItem, "item_img");
            Image img = (e.Item.FindControl("menuImage") as Image);
            string url = "./images/" + imageUrl;
            img.Style.Add("vertical-align", "middle");
            img.ImageUrl = url;
            //Price
            double price = (Double)DataBinder.Eval(e.Item.DataItem, "item_price");
            Label lblPrice = (e.Item.FindControl("menuPrice") as Label);
            lblPrice.Text = "$" + price;

            Button btn = (e.Item.FindControl("btnDelete") as Button);
            btn.OnClientClick = "return confirm('Are you sure you want to delete this menu?');";
        }

        protected void rptMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                HttpContext.Current.Session["editmenuid"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditMenu.aspx");
            }
            else if (e.CommandName == "Delete")
            {
                string msg = mc.DeleteMenu(Convert.ToInt32(e.CommandArgument.ToString()));
                if (msg == "Menu deleted successfully")
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(msg);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    rptMenu.DataSource = mc.RetrieveAllMenu();
                    rptMenu.DataBind();
                }
            }
        }

        protected void btnAddCoupon_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCoupon.aspx");
        }
    }
}