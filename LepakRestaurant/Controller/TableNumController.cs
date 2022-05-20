using LepakRestaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LepakRestaurant.Controller
{
    public class TableNumController
    {
        public int table_num_id { get; set; }

        public string unique_code { get; set; }

        public string image { get; set; }

        public TableNumController()
        {

        }

        public bool CheckIfTableNumExists(string tblnum)
        {
            Table_Num tne = new Table_Num();
            if (tne.getTableDetails(tblnum).table_num_id == 0) return false;
            else return true;
        }

        public bool InsertTableNumber(string tblnum, string ImagePath)
        {
            Table_Num tne = new Table_Num();
            string ID = "";
            ID = RandomCode(5);
            while (!tne.CheckIfUniqueCodeIsUnique(ID))
            {
                ID = RandomCode(5);
            }
            return tne.InsertTableDetails(tblnum, ID, ImagePath);
        }

        public Table_Num getTableDetails(string tableId)
        {
            Table_Num tne = new Table_Num();
            return tne.getTableDetails(tableId);
        }

        private static Random random = new Random();
        public static string RandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}