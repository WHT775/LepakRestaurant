using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Controller
{
    public class OrderSummaryController
    {
        public List<Order_Summary> GetAllPendingOrders()
        {
            Order_Summary ose = new Order_Summary();
            return ose.GetAllPendingOrders();
        }
        public string CancelOrderById(int orderid, string reasoning)
        {
            if (reasoning == "") return "Please fill up the reasoning";
            Order_Summary ose = new Order_Summary() { _oid = orderid, _reason = reasoning };
            string msg = ose.CancelOrderById();
            if (msg == "Successfully cancelled order")
            {
                return ose.InsertCancelOrderReason();
            }
            return msg;
        }

        public string CompleteOrderById(int orderid)
        {
            Order_Summary ose = new Order_Summary() { _oid = orderid };
            return ose.CompleteOrderById();
        }

        public List<Order_Summary> RetrieveAllMenuByOrderId(int orderid)
        {
            Order_Summary ose = new Order_Summary() { _oid = orderid };
            return ose.RetrieveAllMenuByOrderId();
        }

        public string InsertOrderSummary(int orderId, int menuId, int qty)
        {
            Order_Summary sum = new Order_Summary();
            return sum.InsertOrderSummary(orderId, menuId, qty);
        }


        public DataTable RetrieveInsights(int ddlIndex)
        {
            Order_Summary sum = new Order_Summary();
            DataTable dtTemp = new DataTable();
            switch (ddlIndex)
            {
                case 0:
                    //Customer name, last visit, food preference, avg spent
                    List<Order_Summary> listOS = sum.RetrieveInsights();
                    dtTemp.Columns.Add("Customer Name", typeof(string));
                    dtTemp.Columns.Add("Last Visit", typeof(string));
                    dtTemp.Columns.Add("Most Preferred Menu", typeof(string));
                    dtTemp.Columns.Add("Average Spent", typeof(string));
                    foreach (var obj in listOS)
                    {
                        dtTemp.Rows.Add(obj.customer.customer_name, obj.customer.last_visit, obj.menu.item_name, "$"+ Math.Round(obj.orders.total_amt, 2).ToString("#.00"));
                    }
                    //dtSet = sum.RetrieveInsights();
                    break;
                case 1:
                    List<Order_Summary> listOSMenu = sum.RetrieveInsightsMostMenuOrdered();
                    dtTemp.Columns.Add("Customer Name", typeof(string));
                    dtTemp.Columns.Add("Last Visit", typeof(string));
                    dtTemp.Columns.Add("Most Preferred Menu", typeof(string));
                    dtTemp.Columns.Add("Average Spent", typeof(string));
                    foreach (var obj in listOSMenu)
                    {
                        dtTemp.Rows.Add(obj.customer.customer_name, obj.customer.last_visit, obj.menu.item_name, "$" + Math.Round(obj.orders.total_amt, 2).ToString("#.00"));
                    }
                    break;
                default:
                    break;
            }
            return dtTemp;
        }
    }
}