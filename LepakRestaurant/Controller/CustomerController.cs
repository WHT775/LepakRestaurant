﻿using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class CustomerController
    {
        public Boolean checkExistingCustomer(string phone_num)
        {
            Customer cust = new Customer(phone_num);
            cust.CheckExistingCustomer();
            if(cust.customer_name == null)
            { 
                return false;
            }
            HttpContext.Current.Session["custObj"] = cust;
            return true;
        }

        public void updateCustomer()
        {
            Customer cust = (Customer)HttpContext.Current.Session["custObj"];
            cust.updateLastVisit();
            cust.CheckExistingCustomer();
            HttpContext.Current.Session["custObj"] = cust;
        }

        public int getCustId()
        {
            Customer cust = (Customer)HttpContext.Current.Session["custObj"];
            return Convert.ToInt32(cust.id);
        }

        public void createCustomer(string custName, string phoneNum)
        {
            Customer cust = new Customer(phoneNum);
            cust.createCustomer(custName, phoneNum);

            cust.CheckExistingCustomer();
            HttpContext.Current.Session["custObj"] = cust;
        }
        
        public int getTableNum(string code)
        {
            Table_Num table_Num = new Table_Num();
            return table_Num.getTableNum(code);
        }

        public string getTableCode(int tableId)
        {
            Table_Num table_Num = new Table_Num();
            return table_Num.getTableCode(tableId);
        }
    }
}