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
        CouponController cc = new CouponController();
        PaymentController pc = new PaymentController();

        static double total_amt = 0;
        static double final = 0;
        static int table_num = 0;
        static int custId = 0;
        static double gst = 0;
        static Dictionary<int, int> tempCart = new Dictionary<int, int>();
        static List<(int menuId, string itemName, string itemImg, double price, int qty)> itemList = new List<(int menuId, string itemName, string itemImg, double price, int qty)>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblDiscountTxt.Visible = false;
                paySuccess.Visible = false;
                total_amt = (double)HttpContext.Current.Session["subtotalAmt"];
                final = (double)HttpContext.Current.Session["subtotalAmt"];
                table_num = (int)HttpContext.Current.Session["tableNum"];
                custId = (int)HttpContext.Current.Session["custId"];
                gst = total_amt * 0.07;
                final = total_amt + gst;
                lblGst.Text = "GST: $" + gst.ToString();
                lblTableNum.Text = "Table number: " + table_num.ToString() + "<br />";
                lblSubtotal.Text = "Subtotal: $" + total_amt.ToString();
                lblFinalTotal.Text = "Total: $" + final.ToString();
                tempCart = (Dictionary<int, int>)HttpContext.Current.Session["tempCart"];

                foreach(KeyValuePair<int, int> entry in tempCart)
                {
                    var obj = mc.getMenuByMenuId(entry.Key);
                    itemList.Add((obj.menu_id, obj.item_name, obj.item_img, obj.item_price, entry.Value));
                }

                int counter = 1;
                foreach (var item in itemList)
                {
                    Label cartId = new Label();
                    Label cartName = new Label();
                    Label cartQty = new Label();

                    cartId.Text = "Item " + counter + ": Menu ID: " + item.menuId.ToString() + " ";
                    cartName.Text = "Item Name: " + item.itemName.ToString() + " ";
                    cartQty.Text = "Quantity: " + item.qty.ToString() + "<br />";

                    itemDiv.Controls.Add(cartId);
                    itemDiv.Controls.Add(cartName);
                    itemDiv.Controls.Add(cartQty);
                }

            }
            else
            {
                int counter = 1;
                foreach (var item in itemList)
                {
                    Label cartId = new Label();
                    Label cartName = new Label();
                    Label cartQty = new Label();

                    cartId.Text = "Item " + counter + ": Menu ID: " + item.menuId.ToString() + " ";
                    cartName.Text = "Item Name: " + item.itemName.ToString() + " ";
                    cartQty.Text = "Quantity: " + item.qty.ToString() + "<br />";

                    itemDiv.Controls.Add(cartId);
                    itemDiv.Controls.Add(cartName);
                    itemDiv.Controls.Add(cartQty);
                }
            }
        }

        protected void checkCoupon_Click(object sender, EventArgs e)
        {
            bool isExist = cc.checkIfCouponExist(couponTxt.Text.ToString());
            if (isExist)
            {
                bool isExpired = cc.CheckIfCouponExpired(couponTxt.Text.ToString());
                if (isExpired)
                {
                    lblDiscountTxt.Text = "This coupon is expired!";
                    lblDiscountTxt.Visible = true;
                }
                else
                {
                    var obj = cc.RetrieveCouponByCode(couponTxt.Text.ToString());
                    double discount = Convert.ToDouble(obj.discount_amt);
                    final = Convert.ToDouble(lblFinalTotal.Text.ToString().Remove(0, 8));
                    total_amt = total_amt - discount;
                    gst = total_amt * 0.07;
                    final = total_amt + gst;
                    lblGst.Text = "GST: $" + gst.ToString();
                    lblDiscountTxt.Text = "Discount: $" + discount;
                    lblDiscountTxt.Visible = true;
                    lblFinalTotal.Text = "Total: $" + final.ToString();
                    checkCoupon.Visible = false;
                }
            }
            else
            {
                lblDiscountTxt.Text = "This coupon does not exist!";
                lblDiscountTxt.Visible = true;
            }
                
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            string message = cmc.insertOrder(final, table_num);
            if (message == "Success")
            {
                int orderId = cmc.getLatestOrderId();
                if (orderId != 0)
                {
                    foreach (KeyValuePair<int, int> entry in tempCart)
                    {
                        osc.InsertOrderSummary(orderId, entry.Key, entry.Value);
                    }
                    
                    string m1 = pc.insertPayment(orderId, custId, cardType.SelectedItem.Text);
                    if(m1 == "Success")
                    {
                        paySuccess.Visible = true;
                        mainPay.Visible = false;
                    }
                }
            }
        }
    }
}