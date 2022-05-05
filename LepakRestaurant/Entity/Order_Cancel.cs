using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Order_Cancel : DataContext
    {
        public int order_cancel_id { get; set; }

        public int fk_order_cancel_id { get; set; }

        public string reason { get; set; }
    }
}