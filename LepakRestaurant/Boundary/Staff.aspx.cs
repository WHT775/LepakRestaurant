using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class Staff : System.Web.UI.Page
    {
        OrderSummaryController osc = new OrderSummaryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindPendingOrders();
            }
        }

        protected void rptOrders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ////Image
            //string imageUrl = (string)DataBinder.Eval(e.Item.DataItem, "item_img");
            //Image img = (e.Item.FindControl("menuImage") as Image);
            //string url = "./images/" + imageUrl;
            //img.Style.Add("vertical-align", "middle");
            //img.ImageUrl = url;
            ////Price
            //double price = (Double)DataBinder.Eval(e.Item.DataItem, "item_price");
            //Label lblPrice = (e.Item.FindControl("menuPrice") as Label);
            //lblPrice.Text = "$" + price;

            //Button btn = (e.Item.FindControl("btnDelete") as Button);
            //btn.OnClientClick = "return confirm('Are you sure you want to delete this menu?');";
        }

        protected void rptOrders_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Cancel")
            {
                string msg = osc.CancelOrderById(Convert.ToInt32(e.CommandArgument.ToString()));
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + msg + "');", true);
            }
            else if (e.CommandName == "Complete")
            {
                string msg = osc.CompleteOrderById(Convert.ToInt32(e.CommandArgument.ToString()));
                if (msg == "Successfully completed order")
                {
                    msg += " " + e.CommandArgument.ToString();
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + msg + "');", true);
            }
            bindPendingOrders();
            upStaff.Update();
        }
        public void bindPendingOrders()
        {
            rptOrders.DataSource = osc.GetAllPendingOrders();
            rptOrders.DataBind();
        }
    }
}