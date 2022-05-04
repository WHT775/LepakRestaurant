using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LepakRestaurant.Controller;

namespace LepakRestaurant.Boundary
{
    public partial class CustomerMenu : System.Web.UI.Page
    {
        CustomerMenuController cmc = new CustomerMenuController();
        OrderSummaryController osc = new OrderSummaryController();
        
        static Dictionary<int, int> tempCart = new Dictionary<int, int>();
        static Dictionary<int, string> nameDict = new Dictionary<int, string>();
        static double total_amt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryData();
                BindItemData("");
                updateTempCart();
            }
        }

        public void BindCategoryData()
        {
            rptItemCategory.DataSource = cmc.getListOfCategory();
            rptItemCategory.DataBind();
        }

        public void BindItemData(string category)
        {
            rptItem.DataSource = cmc.retrieveItemsByCategory(category);
            rptItem.DataBind();
        }

        protected void selectedCategory_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Text.ToString() != "View Cart")
                BindItemData(btn.Text.ToString());
            else
            {
                updateTempCart();
            }
        }

        public void updateTempCart()
        {
            cartDiv.Controls.Clear();
            if (tempCart.Count == 0)
            {
                Label itemId = new Label();
                itemId.Text = "No items in cart";
                cartDiv.Controls.Add(itemId);
                cfmOrder.Visible = false;
            }
            else
            {
                cfmOrder.Visible = true;
                int counter = 1;
                foreach (KeyValuePair<int, int> entry in tempCart)
                {
                    Label cartId = new Label();
                    Label cartName = new Label();
                    Label cartQty = new Label();

                    cartId.Text = "Item " + counter + ": Menu ID: " + entry.Key.ToString() + " ";
                    cartName.Text = "Item Name: " + nameDict[entry.Key].ToString() + " ";
                    cartQty.Text = "Quantity: " + entry.Value.ToString() + "<br />";
                    cartDiv.Controls.Add(cartId);
                    cartDiv.Controls.Add(cartName);
                    cartDiv.Controls.Add(cartQty);
                    counter++;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var tb = (TextBox)item.FindControl("itemQty");
            var itemId = (Label)item.FindControl("itemID");
            var labelName = (Label)item.FindControl("itemName");
            var labelPrice = (Label)item.FindControl("itemPrice");
            string itemName = labelName.Text.ToString();
            int menuId = Convert.ToInt32(itemId.Text.ToString());
            int qty = Convert.ToInt32(tb.Text.ToString());
            double price = Convert.ToDouble(labelPrice.Text.ToString().Remove(0,8));
            total_amt += qty * price;
            if (tempCart.ContainsKey(menuId))
                tempCart[menuId] += qty;
            else
                tempCart.Add(menuId, qty);

            if(!nameDict.ContainsKey(menuId))
                nameDict.Add(menuId, itemName);
            updateTempCart();
        }

        protected void cfmOrder_Click(object sender, EventArgs e)
        {
            Dictionary<int, Tuple<string, string, double, int>> paymentInfo = new Dictionary<int, Tuple<string, string, double, int>>();
            //int table_id = Convert.ToInt32(HttpContext.Current.Session["tableNum"].ToString());
            //string message = cmc.insertOrder(total_amt, table_id);
            //if(message == "Success")
            //{
            //    int orderId = cmc.getLatestOrderId();
            //    if(orderId != 0)
            //    {
            //        foreach (KeyValuePair<int, int> entry in tempCart)
            //        {
            //            osc.InsertOrderSummary(orderId, entry.Key, entry.Value);
            //        }
            //    }
            //}
            HttpContext.Current.Session["tempCart"] = tempCart;
            HttpContext.Current.Session["subtotalAmt"] = total_amt;

            Response.Redirect("PaymentPage.aspx");

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var tb = (TextBox)item.FindControl("itemQty");
            var itemId = (Label)item.FindControl("itemID");
            int menuId = Convert.ToInt32(itemId.Text.ToString());
            int qty = Convert.ToInt32(tb.Text.ToString());
            if (tempCart.ContainsKey(menuId))
                tempCart[menuId] -= qty;
                if(tempCart[menuId] <= 0)
                    tempCart.Remove(menuId);

            updateTempCart();
        }
    }
}