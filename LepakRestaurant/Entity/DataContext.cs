using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Entity
{
    public class DataContext
    {
        public string connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
    }
}