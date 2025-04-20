using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    internal class MenuModel
    {
        public int itemID { get; set; }
        public string name { get; set; } // Keep even if not displayed yet
        public double price { get; set; } // Use bool in C#

        public int inventoryAmnt { get; set; }
        public string itemType {  get; set; }
        public int? isAlcholic {  get; set; }
        public string? season { get; set; }
    }
}
