using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using LepakRestaurant.Controller;

namespace LepakRestaurant.Boundary
{
    public partial class PaymentPage : System.Web.UI.Page
    {
        MenuController mc = new MenuController();
        CustomerMenuController cmc = new CustomerMenuController();
        OrderSummaryController osc = new OrderSummaryController();

        static double total_amt = 0;
        static Dictionary<int, int> tempCart = new Dictionary<int, int>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                total_amt = (double)HttpContext.Current.Session["subtotalAmt"];
                tempCart = (Dictionary<int, int>)HttpContext.Current.Session["tempCart"];
                var itemList = new List<(int menuId, string itemName, string itemImg, double price, int qty)>();
                foreach(KeyValuePair<int, int> entry in tempCart)
                {
                    var obj = mc.getMenuByMenuId(entry.Key);
                    itemList.Add((obj.menu_id, obj.item_name, obj.item_img, obj.item_price, entry.Value));
                }
                
            }
        }
        
        
    }
}