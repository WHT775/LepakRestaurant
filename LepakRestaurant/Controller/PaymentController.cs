using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class PaymentController
    {
        
        public string insertPayment(int ordersId, int custId, string cardType)
        {
            Payment payment = new Payment() { fk_orders_id = ordersId, fk_customer_id = custId, card_type = cardType };
            return payment.insertPayment().ToString();
        }
    }
}