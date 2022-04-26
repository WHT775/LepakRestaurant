using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Order_Summary : DataContext
    {
        public int order_sum_id { get; set; }

        public int fk_orders_id { get; set; }

        public int fk_menu_id { get; set; }

        public int quantity { get; set; }

        public Order_Summary()
        {

        }
    }
}