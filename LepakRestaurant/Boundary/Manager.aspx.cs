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
        CustomerMenuController cmc = new CustomerMenuController();
        CouponController cc = new CouponController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptMenu.DataSource = mc.RetrieveAllMenu();
                rptMenu.DataBind();
                gvCoupon.DataSource = cc.RetrieveAllCoupon();
                gvCoupon.DataBind();
                rptItemCategory.DataSource = cmc.getListOfCategoryWithAll();
                rptItemCategory.DataBind();
                lblCategories.Text = "All Menu";
                if(Request.QueryString["q"] == "m")
                {
                    divMenu.Style.Add("display", "block");
                    divCoupon.Style.Add("display", "none");
                }
                else if(Request.QueryString["q"] == "c")
                {
                    divMenu.Style.Add("display", "none");
                    divCoupon.Style.Add("display", "block");
                }
                else
                {
                    divMenu.Style.Add("display", "block");
                    divCoupon.Style.Add("display", "none");
                }

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

            //Button btn = (e.Item.FindControl("btnDelete") as Button);
            //btn.OnClientClick = "return confirm('Are you sure you want to delete this menu?');";
        }

        protected void rptMenu_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                HttpContext.Current.Session["editmenuid"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditMenu.aspx");
            }
            //else if (e.CommandName == "Delete")
            //{
            //    string msg = mc.DeleteMenu(Convert.ToInt32(e.CommandArgument.ToString()));
            //    if (msg == "Menu deleted successfully")
            //    {
            //        rptMenu.DataSource = mc.RetrieveAllMenu();
            //        rptMenu.DataBind();
            //    }
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + msg + "');", true);
            //    upManager.Update();
            //}
        }

        protected void btnAddCoupon_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCoupon.aspx");
        }

        protected void gvCoupon_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                HttpContext.Current.Session["editcouponid"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditCoupon.aspx");
            }
            //else if (e.CommandName == "Delete")
            //{
            //    string msg = cc.DeleteCoupon(Convert.ToInt32(e.CommandArgument.ToString()));
            //    if(msg == "Coupon deleted successfully")
            //    {
            //        gvCoupon.DataSource = cc.RetrieveAllCoupon();
            //        gvCoupon.DataBind();
            //    }
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('"+msg+"');", true);
            //    upManager.Update();
            //}
        }

        protected void gvCoupon_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //divCoupon.Style.Add("display", "block");
            //divMenu.Style.Add("display", "none");
        }

        protected void gvCoupon_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in gvCoupon.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = row.FindControl("btnDelete") as Button;
                    btn.OnClientClick = "return confirm('Are you sure you want to delete this coupon?');";
                }
            }
        }

        protected void rptItemCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            lblCategories.Text = e.CommandName.ToString() + " Menu";
            rptMenu.DataSource = mc.RetrieveAllMenuByCategoryId(Convert.ToInt32(e.CommandArgument.ToString()));
            rptMenu.DataBind();
        }

        protected void btnMenuTab_Click(object sender, EventArgs e)
        {
            divMenu.Style.Add("display","block");
            divCoupon.Style.Add("display", "none");
            btnMenuTab.CssClass += " active";
            btnCouponTab.CssClass = "tablinks";
            //btnMenuTab.Attributes.Add("class","active");
            //btnCouponTab.Attributes.Remove("active");
            upManager.Update();
        }

        protected void btnCouponTab_Click(object sender, EventArgs e)
        {
            divMenu.Style.Add("display", "none");
            divCoupon.Style.Add("display", "block");
            btnCouponTab.CssClass += " active";
            btnMenuTab.CssClass = "tablinks";
            upManager.Update();
            //btnCouponTab.Attributes.Add("class", "active");
            //btnMenuTab.Attributes.Remove("active");
        }
    }
}