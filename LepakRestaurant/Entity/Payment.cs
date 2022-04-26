using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Payment : DataContext
    {
        public int payment_id { get; set; }

        public int fk_orders_id { get; set; }

        public int fk_customer_id { get; set; }

        public string card_type { get; set; }

        public Payment()
        {

        }
    }
}