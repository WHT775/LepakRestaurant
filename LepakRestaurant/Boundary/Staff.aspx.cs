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
            //OrderID
            int orderid = (int)DataBinder.Eval(e.Item.DataItem, "orders.orders_id");
            Label lblOrderid = (e.Item.FindControl("lblOrderId") as Label);
            lblOrderid.Text = "Order ID: " + orderid.ToString();
            //TableID
            int tableid = (int)DataBinder.Eval(e.Item.DataItem, "orders.fk_table_num_id");
            Label lblTableid = (e.Item.FindControl("lblTableId") as Label);
            lblTableid.Text = "Table No: " + tableid.ToString();
            //TotalCost
            //double totalcost = (Double)DataBinder.Eval(e.Item.DataItem, "orders.total_amt");
            //Label lblTotalCost = (e.Item.FindControl("lblTotalCost") as Label);
            //lblTotalCost.Text = "Total Cost: $" + totalcost.ToString();

            //Order repeater
            Repeater rptOrders = (e.Item.FindControl("rptMenu") as Repeater);
            rptOrders.DataSource = osc.RetrieveAllMenuByOrderId(orderid);
            rptOrders.DataBind();

            //

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

        protected void rptMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Menu Name
            string menuname = (string)DataBinder.Eval(e.Item.DataItem, "menu.item_name");
            Label lblMenuName = (e.Item.FindControl("lblMenuName") as Label);
            lblMenuName.Text = menuname.ToString();

            //Quantity
            int quantity = (int)DataBinder.Eval(e.Item.DataItem, "quantity");
            Label lblQuantity = (e.Item.FindControl("lblQuantity") as Label);
            lblQuantity.Text = "x" + quantity;

            //itemprice
            double itemprice = (double)DataBinder.Eval(e.Item.DataItem, "menu.item_price");
            Label lblCost = (e.Item.FindControl("lblCost") as Label);
            lblCost.Text = "$" + itemprice;

        }
    }
}