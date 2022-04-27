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
        static Dictionary<int, int> tempCart = new Dictionary<int, int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategoryData();
                BindItemData("");
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
            if (tempCart.Count == 0)
            {
                cartId.Text = "0";
                cartQty.Text = "0";
                
            }
            else
            {
                foreach (KeyValuePair<int, int> entry in tempCart)
                {
                    cartId.Text += entry.Key;
                    cartQty.Text += entry.Value;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var item = (RepeaterItem)btn.NamingContainer;
            var tb = (TextBox)item.FindControl("itemQty");
            var itemId = (Label)item.FindControl("itemID");
            int menuId = Convert.ToInt32(itemId.Text.ToString());
            int qty = Convert.ToInt32(tb.Text.ToString());
            if (tempCart.ContainsKey(menuId))
                tempCart[menuId] += qty;
            else
                tempCart.Add(menuId, qty);
            updateTempCart();
        }
    }
}