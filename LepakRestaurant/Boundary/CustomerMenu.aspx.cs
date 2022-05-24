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
        static int table_num = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                table_num = (int)HttpContext.Current.Session["tableNum"];
                tempCart.Clear();
                nameDict.Clear();
                total_amt = 0;
                BindCategoryData();
                BindItemData("");
                updateTempCart();
                lblTableNum.Text = "Table: "+HttpContext.Current.Session["tableNum"].ToString();
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
            //if (btn.Text.ToString() != "View Cart")
            BindItemData(btn.Text.ToString());
            //else
            //{
            //    updateTempCart();
            //}
            updateTempCart();
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
                    Table table = new Table();
                    
                    //Label cartId = new Label();
                    //Label cartName = new Label();
                    //Label cartQty = new Label();
                    Label menuItem = new Label();
                    menuItem.Text = nameDict[entry.Key].ToString() + " x" + entry.Value.ToString() + "<br/>";
                    //cartId.Text = "Item " + counter + ": Menu ID: " + entry.Key.ToString() + " ";
                    //cartName.Text = "Item Name: " + nameDict[entry.Key].ToString() + " ";
                    //cartQty.Text = "Quantity: " + entry.Value.ToString() + "<br />";
                    //cartDiv.Controls.Add(cartId);
                    //cartDiv.Controls.Add(cartName);
                    //cartDiv.Controls.Add(cartQty);
                    cartDiv.Controls.Add(menuItem);
                    counter++;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var tb = (Label)item.FindControl("lblQty");
            if(tb.Text == "")
            {
                return;
            }
            var itemId = (Label)item.FindControl("itemID");
            var labelName = (Label)item.FindControl("itemName");
            var labelPrice = (Label)item.FindControl("itemPrice");
            string itemName = labelName.Text.ToString();
            int menuId = Convert.ToInt32(itemId.Text.ToString());
            int qty = Convert.ToInt32(tb.Text.ToString()) + 1;
            tb.Text = qty.ToString();
            double price = Convert.ToDouble(labelPrice.Text.ToString().Remove(0,1));
            total_amt += price;
            if (tempCart.ContainsKey(menuId))
                tempCart[menuId] = qty;
            else
                tempCart.Add(menuId, qty);

            if(!nameDict.ContainsKey(menuId))
                nameDict.Add(menuId, itemName);
            updateTempCart();
            upMenu.Update();
            //btn.Focus();
            //ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            //scriptMan.RegisterAsyncPostBackControl(btn);
        }

        protected void cfmOrder_Click(object sender, EventArgs e)
        {
            Dictionary<int, Tuple<string, string, double, int>> paymentInfo = new Dictionary<int, Tuple<string, string, double, int>>();
            
            HttpContext.Current.Session["tableNum"] = table_num;
            HttpContext.Current.Session["tempCart"] = tempCart;
            HttpContext.Current.Session["subtotalAmt"] = total_amt;

            Response.Redirect("PaymentPage.aspx");

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var tb = (Label)item.FindControl("lblQty");
            var itemId = (Label)item.FindControl("itemID");
            var labelPrice = (Label)item.FindControl("itemPrice");
            int menuId = Convert.ToInt32(itemId.Text.ToString());
            int qty = Convert.ToInt32(tb.Text.ToString());
            double price = Convert.ToDouble(labelPrice.Text.ToString().Remove(0, 1));
            if (qty>0)
                total_amt -= price;
            qty = qty - 1;
            if (qty < 0)
                qty = 0;
            tb.Text = qty.ToString();
            
            
            if (qty == 0)
            {
                if (tempCart.ContainsKey(menuId))
                    tempCart.Remove(menuId);
                //tempCart[menuId] = qty;
                    //if (tempCart[menuId] <= 0)
                        
            }
            

            updateTempCart();
            upMenu.Update();
            //ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            //scriptMan.RegisterAsyncPostBackControl(btn);
        }

        protected void btnAddQty_Click(object sender, EventArgs e)
        {
            //var btn = (Button)sender;
            //var item = (RepeaterItem)btn.NamingContainer;
            //var tb = (Label)item.FindControl("lblQty");
            //int qty = Convert.ToInt32(tb.Text.ToString()) + 1;
            //tb.Text = qty.ToString();
        }

        protected void btnMinusQty_Click(object sender, EventArgs e)
        {
            //var btn = (Button)sender;
            //var item = (RepeaterItem)btn.NamingContainer;
            //var tb = (Label)item.FindControl("lblQty");
            //int qty = Convert.ToInt32(tb.Text.ToString()) - 1;
            //tb.Text = qty.ToString();
        }

        protected void rptItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var lnkBtnIndvidual = (Button)e.Item.FindControl("btnAdd");
            scriptManager1.RegisterAsyncPostBackControl(lnkBtnIndvidual);
        }
    }
}