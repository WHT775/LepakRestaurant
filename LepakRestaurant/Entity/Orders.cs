using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Orders
    {
        public int orders_id { get; set; }

        public double total_amt { get; set; }

        public string orders_status { get; set; }

        public int fk_table_num_id { get; set; }

        public int fk_customer_id { get; set; }

        public Orders()
        {

        }
    }
}