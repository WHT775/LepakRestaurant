using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class MenuController
    {
        public string[] createMenu(string name, string description, string price, HttpPostedFile imgfile, int categoryid)
        {
            Menu menu = new Menu();
            if (name == "" || description == "" || price == "")
            {
                return new string[] { "Please fill up the form" };
            }
            try
            {
                Convert.ToDouble(price);
            }
            catch (Exception)
            {
                return new string[] { "Please key in appropriate price" };
            }
            string ID = "";
            if (imgfile.ContentLength != 0)
            {
                ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                menu = new Menu() { item_img = ID };
                while (!menu.CheckIfImageNameIsUnique())
                {
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                }
                ID += ID + "." + GetFileExtension(imgfile.FileName);
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

        private string GetFileExtension(string filename)
        {
            string[] result = filename.Split('.');
            return result[result.Length - 1];
        }

        public List<Menu> RetrieveAllMenu()
        {
            Menu me = new Menu();
            return me.RetrieveAllMenu();
        }

        public string DeleteMenu(int menuid)
        {
            Menu me = new Menu() { menu_id = menuid};
            return me.DeleteMenu();
        }
        public List<Category> getListOfCategory()
        {
            Category cat = new Category();
            return cat.RetrieveCategories();
        }

        public Menu getMenuByMenuId(int menuid)
        {
            Menu me = new Menu() { menu_id = menuid };
            return me.RetrieveMenuByMenuId();
        }
        public string[] UpdateMenu(int menuid,string menuname, string menudesc, string price, HttpPostedFile imgfile, string categoryid)
        {
            Menu menu = new Menu();
            if (menuname == "" || menudesc == "" || price == "")
            {
                return new string[] { "Please fill up the form" };
            }
            try
            {
                Convert.ToDouble(price);
            }
            catch (Exception)
            {
                return new string[] { "Please key in appropriate price" };
            }
            string ID = "";
            if (imgfile.ContentLength != 0)
            {
                //Updating image
                ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                menu = new Menu() { item_img = ID };
                while (!menu.CheckIfImageNameIsUnique())
                {
                    ID = Guid.NewGuid().ToString("N").Substring(0, 10);
                }
                ID += ID + "." + GetFileExtension(imgfile.FileName);
            }
            else
            {
                //Retrieve file name to stay status quo
                menu = new Menu() {menu_id = menuid };
                ID = menu.RetrieveMenuByMenuId().item_img;
            }
            menu = new Menu() {menu_id= menuid, item_name = menuname, item_desc = menudesc, item_price = Convert.ToDouble(price), item_img = ID, category_id = Convert.ToInt32(categoryid) };
            bool result = menu.UpdateMenu();
            if (!result)
            {
                return new string[] { "Error updating menu" };
            }
            else
            {
                return new string[] { "Successfully updated menu", ID};
            }

        }

        public List<Menu> RetrieveAllMenuByCategoryId(int categoryid)
        {
            Menu me = new Menu() { category_id = categoryid };
            return me.RetrieveAllMenuByCategoryId();
        }
    }
}