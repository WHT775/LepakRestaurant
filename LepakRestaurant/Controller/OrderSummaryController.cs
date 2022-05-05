using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class OrderSummaryController
    {
        public List<Order_Summary> GetAllPendingOrders()
        {
            Order_Summary ose = new Order_Summary();
            return ose.GetAllPendingOrders();
        }
        public string CancelOrderById(int orderid)
        {
            Order_Summary ose = new Order_Summary() {_oid = orderid };
            return ose.CancelOrderById();
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
    }
}