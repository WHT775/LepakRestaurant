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
            return categoryList;
        }

        public DataSet retrieveItemsByCategory(string category)
        {
            Menu menu = new Menu();
            DataSet ds = new DataSet();
            ds = menu.retrieveItemsByCategory(category);
            return ds;
        }
    }
}