using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    internal class TransactionItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalOrdered { get; set; }
        public double price { get; set; }
        public int discountRate { get; set; }
        public double baseprice { get; set; }
        public TransactionItem(int id, string name, int totalOrdered, double price, int discountRate, double baseprice)
        {
            this.id = id;
            this.name = name;
            this.totalOrdered = totalOrdered;
            this.price = price;
            this.discountRate = discountRate;
            this.baseprice = baseprice;
        }
    }
}
