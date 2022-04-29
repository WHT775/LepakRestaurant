using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class CouponController
    {
        public string CreateCoupon(string coupon,string discount)
        {
            if(coupon == "" || discount == "") return "Please fill up the form" ;
            try
            {
                Convert.ToDouble(discount);
            }
            catch (Exception)
            {
                return "Please key in appropriate price";
            }
            Coupon ce = new Coupon() { coupon_code=coupon.ToUpper(), discount_amt = Convert.ToDouble(discount)};
            if (ce.CheckIfCouponExist()) return "Coupon exist";
            bool result = ce.InsertCoupon();
            if (!result)
            {
                return "Error creating coupon" ;
            }
            else
            {
                return "Successfully created coupon";
            }
        }
    }
}