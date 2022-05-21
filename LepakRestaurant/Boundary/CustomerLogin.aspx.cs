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
    public partial class CustomerLogin : System.Web.UI.Page
    {
        CustomerController cc = new CustomerController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                custDiv.Visible = false;
                errorDiv.Visible = false;
                errorMsg.ForeColor = System.Drawing.Color.Red;
                HttpContext.Current.Session.Clear();
                if (!string.IsNullOrEmpty(Request.QueryString["tableid"]))
                {
                    codeTxt.Text = cc.getTableCode(Convert.ToInt32(Request.QueryString["tableid"].ToString()));
                    codeTxt.Enabled = false;
                }
            }

        }

        protected void btnCode_Click(object sender, EventArgs e)
        {
            if (phoneTxt.Text != "" && codeTxt.Text != "")
            {
                int table_num = cc.getTableNum(codeTxt.Text);
                if (table_num == 0)
                {
                    errorDiv.Visible = true;
                    errorMsg.Text = "Please enter a correct unique code!";
                }
                else
                {
                    HttpContext.Current.Session["tableNum"] = table_num;
                    bool isExist = cc.checkExistingCustomer(phoneTxt.Text);
                    if (isExist)
                    {
                        cc.updateCustomer();
                        HttpContext.Current.Session["custId"] = cc.getCustId();
                        Response.Redirect("CustomerMenu.aspx");
                    }
                    else
                    {
                        custDiv.Visible = true;
                        btnCode.Visible = false;
                        codeTxt.Enabled = false;
                        phoneTxt.Enabled = false;
                    }
                }
            }
            else
            {
                errorDiv.Visible = true;
                errorMsg.Text = "Please enter your phone number and unique code";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "")
            {
                cc.createCustomer(nameTxt.Text, phoneTxt.Text);
                HttpContext.Current.Session["custId"] = cc.getCustId();
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append("Customer registered successfully!");
                sb.Append("');window.location='CustomerMenu.aspx';};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
            else
            {
                errorDiv.Visible = true;
                errorMsg.Text = "Please enter your name";
            }
        }
    }
}