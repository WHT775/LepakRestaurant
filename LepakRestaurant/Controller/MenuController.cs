using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class MenuController
    {
        public List<Category> getListOfCategory()
        {
            List<Category> categoryList = new List<Category>();
            Category cat = new Category();
            categoryList = cat.RetrieveCategories();
            return categoryList;
        }

        public string[] createMenu(string name, string description, string price, HttpPostedFile imgfile, int categoryid)
        {
            Menu menu = new Menu();
            if (name == "" || description == "" || price == "")
            {
                return new string[] { "Please fill up the form" };
            }
            string ID = "";
            if (imgfile.ContentLength != 0)
            {
                ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                menu = new Menu() { item_img = ID };
                while (menu.CheckIfImageNameIsUnique())
                {
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                }
            }
            menu = new Menu() { item_name = name, item_desc = description, item_price = Convert.ToDouble(price), item_img = ID, category_id = categoryid };
            bool result = menu.CreateMenu();
            if (!result)
            {
                return new string[] { "Error creating menu" };
            }
            else
            {
                return new string[] { "Successfully created menu", ID };
            }
        }
    }
}