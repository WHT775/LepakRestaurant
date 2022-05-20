using LepakRestaurant.Controller;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class Owner : System.Web.UI.Page
    {
        UserController uc = new UserController();
        OrderSummaryController osc = new OrderSummaryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvUsers.DataSource = uc.PopulateGridViewUsers();
                gvUsers.DataBind();
                gvStatistics.DataSource = osc.RetrieveInsights(ddlInsights.SelectedIndex);
                gvStatistics.DataBind();
            }
            if (Request.QueryString["q"] == "u")
            {
                divInsights.Style.Add("display", "none");
                divQrCode.Style.Add("display", "none");
                divUsers.Style.Add("display", "block");
            }
            else if (Request.QueryString["q"] == "qr")
            {
                divInsights.Style.Add("display", "none");
                divQrCode.Style.Add("display", "block");
                divUsers.Style.Add("display", "none");
            }
            else
            {
                divInsights.Style.Add("display", "block");
                divQrCode.Style.Add("display", "none");
                divUsers.Style.Add("display", "none");
            }
        }

        protected void btnAddUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                HttpContext.Current.Session["edituserid"] = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("EditUser.aspx");
            }
            else if (e.CommandName == "Delete")
            {
                string msg = uc.DeleteUser(Convert.ToInt32(e.CommandArgument.ToString()));
                if (msg == "User deleted successfully")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + msg + "');", true);
                    gvUsers.DataSource = uc.PopulateGridViewUsers();
                    gvUsers.DataBind();
                    upOwner.Update();
                }
            }
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in gvUsers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button btn = row.FindControl("btnDelete") as Button;
                    btn.OnClientClick = "return confirm('Are you sure you want to delete this user?');";
                }
            }
        }

        protected void ddlInsights_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvStatistics.DataSource = osc.RetrieveInsights(ddlInsights.SelectedIndex);
            gvStatistics.DataBind();
        }

        protected void btnInsightsTab_Click(object sender, EventArgs e)
        {
            divQrCode.Style.Add("display", "none");
            divUsers.Style.Add("display", "none");
            divInsights.Style.Add("display", "block");
            btnInsightsTab.CssClass += " active";
            btnUserTab.CssClass = "tablinks";
            btnQrCode.CssClass = "tablinks";
            upOwner.Update();
        }

        protected void btnUserTab_Click(object sender, EventArgs e)
        {
            divQrCode.Style.Add("display", "none");
            divInsights.Style.Add("display", "none");
            divUsers.Style.Add("display", "block");
            btnUserTab.CssClass += " active";
            btnInsightsTab.CssClass = "tablinks";
            btnQrCode.CssClass = "tablinks";
            upOwner.Update();
        }

        protected void btnQrCode_Click(object sender, EventArgs e)
        {
            divUsers.Style.Add("display", "none");
            divInsights.Style.Add("display", "none");
            divQrCode.Style.Add("display", "block");
            btnQrCode.CssClass += " active";
            btnInsightsTab.CssClass = "tablinks";
            btnUserTab.CssClass = "tablinks";
            upOwner.Update();
        }

        protected void btnGenerateQrCode_Click(object sender, EventArgs e)
        {
            TableNumController tnc = new TableNumController();
            if (!tnc.CheckIfTableNumExists(txtTableId.Text))
            {
                QRCodeEncoder encoder = new QRCodeEncoder();
                encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
                encoder.QRCodeScale = 10;
                Bitmap img = encoder.Encode("http://localhost:44331/Boundary/CustomerLogin/?tableid=" + txtTableId.Text);
                string savePath = Server.MapPath("images/tableid" + txtTableId.Text + ".jpeg");
                img.Save(savePath, ImageFormat.Jpeg);
                string url = "images/tableid" + txtTableId.Text + ".jpeg";
                if (tnc.InsertTableNumber(txtTableId.Text, url))
                {
                    lblWrong3.Text = "";
                    //Retrieve the tablenum details
                    var tableObj = tnc.getTableDetails(txtTableId.Text);
                    lblTitle.Text = "Table Number: " + txtTableId.Text;
                    imgQrCode.ImageUrl = "./" + tableObj.image;
                    lblUniqueCode.Text = "Unique Code: <br/><b>" + tableObj.unique_code + "</b>";
                }
                else
                {
                    lblWrong3.Text = "Some issues with the generation, please try again";

                }

            }
            else
            {
                //Display the existing qr code and unique code
                lblWrong3.Text = "";
                var tableObj = tnc.getTableDetails(txtTableId.Text);
                lblTitle.Text = "Table Number: " + txtTableId.Text;
                imgQrCode.ImageUrl = "./" + tableObj.image;
                lblUniqueCode.Text = "Unique Code: <br/><b>" + tableObj.unique_code + "</b><br/><br/>Go to http://localhost/Boundary/CustomerLogin.aspx";
            }
            divInsights.Style.Add("display", "none");
            divQrCode.Style.Add("display", "block");
            divUsers.Style.Add("display", "none");
        }

    }
}