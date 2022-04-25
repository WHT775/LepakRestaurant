using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Menu
    {
        public int menu_id { get; set; }

        public string item_name { get; set; }

        public string item_description { get; set; }

        public decimal item_price { get; set; }

        public string item_img { get; set; }


    }
}