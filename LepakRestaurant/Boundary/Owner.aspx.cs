using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class Owner : System.Web.UI.Page
    {
        UserController uc = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvUsers.DataSource = uc.PopulateGridViewUsers();
                gvUsers.DataBind();
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
                    gvUsers.DataSource = uc.PopulateGridViewUsers();
                    gvUsers.DataBind();
                    upUsers.Update();
                    //System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    //sb.Append("<script type = 'text/javascript'>");
                    //sb.Append("window.onload=function(){");
                    //sb.Append("alert('");
                    //sb.Append(msg);
                    //sb.Append("')};");
                    //sb.Append("</script>");
                    //ClientScript.RegisterClientScriptBlock(Page.GetType(), "alert", msg.ToString());
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
    }
}