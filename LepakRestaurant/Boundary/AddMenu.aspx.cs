using LepakRestaurant.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class AddMenu : System.Web.UI.Page
    {
        CustomerMenuController uc = new CustomerMenuController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategory.DataSource = uc.getListOfCategory();
                ddlCategory.DataBind();
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Manager.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string[] msg = uc.createMenu(txtName.Text.Trim(), txtDescription.Text.Trim(), txtCost.Text.Trim(), fUpload.PostedFile, Convert.ToInt32(ddlCategory.SelectedValue));
            if (msg[0] == "Successfully created menu")
            {
                if(msg[1] != "")
                {
                    fUpload.SaveAs(Server.MapPath("images/" + msg[1] + "." + fUpload.PostedFile.ContentType));
                }
                Response.Redirect("Manager.aspx");
            }
            else
            {
                lblWrong.Text = msg[0];
                lblWrong.Visible = true;
            }
            //         If(FileUpload.HasFile) Then
            //Dim ID As String = Guid.NewGuid().ToString("N").Substring(0, 10)
            //    Dim testImageName As Menu = New Menu(ID)
            //    While(Not testImageName.CheckImageNameIsUnique())
            //        ID = Guid.NewGuid().ToString("N").Substring(0, 10)
            //        testImageName = New Menu(ID)
            //    End While
            //             FileUpload.SaveAs(Server.MapPath("images//menu//" + ID + Path.GetExtension(FileUpload.FileName)))
            //             imageUrl = ID + Path.GetExtension(FileUpload.FileName)
            //         End If
        }
    }
}