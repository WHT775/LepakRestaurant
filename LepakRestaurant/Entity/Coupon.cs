using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Coupon : DataContext
    {
        public int coupon_id { get; set; }

        public double discount_amt { get; set; }

        public Coupon()
        {

        }

    }
}