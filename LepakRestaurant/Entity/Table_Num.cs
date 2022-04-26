using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class Table_Num : DataContext
    {
        public int table_num_id { get; set; }

        public string unique_code { get; set; }

        public Table_Num()
        {

        }
    }
}