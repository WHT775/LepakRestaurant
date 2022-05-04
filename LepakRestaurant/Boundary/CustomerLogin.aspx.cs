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
            custDiv.Visible = false;
            errorDiv.Visible = false;
            errorMsg.ForeColor = System.Drawing.Color.Red;
        }

        protected void btnCode_Click(object sender, EventArgs e)
        {
            if (phoneTxt.Text != "" || codeTxt.Text != "")
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

                        Response.Redirect("CustomerMenu.aspx");
                    }
                    else
                    {
                        custDiv.Visible = true;
                        btnCode.Visible = false;
                    }
                }
            }
            else
            {
                errorDiv.Visible = true;
                errorMsg.Text = "Please enter your phone number or unique code";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text != "")
            {
                cc.createCustomer(nameTxt.Text, phoneTxt.Text);
                MessageBox.Show("Customer registered successfully!", "Registered!");
                Response.Redirect("CustomerMenu.aspx");
            }
            else
            {
                errorMsg.Text = "Please enter your name";
            }
        }
    }
}