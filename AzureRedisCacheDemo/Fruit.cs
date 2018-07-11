using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureRedisCacheDemo
{
    public class Fruit
    {
        public int FruitID { get; set; }
        public string FruitName { get; set; }
        public string Color { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CountryHQ { get; set; }
        public int CompanyRank { get; set; }
    }
}