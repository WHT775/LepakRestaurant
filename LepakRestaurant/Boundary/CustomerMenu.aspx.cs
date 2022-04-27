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
            BindItemData(btn.Text.ToString());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}