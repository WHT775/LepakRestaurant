using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using LepakRestaurant.Entity;

namespace LepakRestaurant.Controller
{
    public class CustomerMenuController
    {
        public List<Category> getListOfCategory()
        {
            List<Category> categoryList = new List<Category>();
            Category cat = new Category();
            categoryList = cat.RetrieveCategories();
            cat = new Category(1, "View Cart");
            categoryList.Add(cat);
            return categoryList;
        }

        public DataSet retrieveItemsByCategory(string category)
        {
            Menu menu = new Menu();
            DataSet ds = new DataSet();
            ds = menu.retrieveItemsByCategory(category);
            return ds;
        }

        public string[] createMenu(string name,string description,string price, HttpPostedFile imgfile, int categoryid)
        {
            Menu menu = new Menu();
            if (name == "" || description == "" || price == "")
            {
                return new string[]{ "Please fill up the form"};
            }
            string ID = "";
            if(imgfile.ContentLength != 0)
            {
                ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                menu = new Menu() { item_img = ID};
                while (menu.CheckIfImageNameIsUnique())
                {
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                }
            }
            menu = new Menu() { item_name = name, item_desc = description, item_price = Convert.ToDouble(price), item_img = ID, category_id = categoryid };
            bool result = menu.CreateMenu();
            if (!result) 
            {
                return new string[]{ "Error creating menu" };
            }
            else
            {
                return new string[] { "Successfully created menu",ID};
            }
        }
    }
}