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
        CustomerController cc = new CustomerController();

        //Customer cust = (Customer)HttpContext.Current.Session["custObj"];
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

        public string insertOrder(double total_amt, int table_num)
        {
            cc.updateCustomer();
            Orders order = new Orders();
            return order.InsertOrder(total_amt, "Pending", table_num, 2);
        }

        public int getLatestOrderId()
        {
            Orders order = new Orders();
            return order.getLatestOrderId();
        }
    }
}