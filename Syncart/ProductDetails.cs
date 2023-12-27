using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class ProductDetails
    {
        private static int s_ProductID=101;
        public string ProductID { get; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }
        public  ProductDetails(string name,double price,int stock,int ShipDuration){
            ProductID="PID"+s_ProductID;
            s_ProductID++;
            ProductName=name;
            Price=price;
            Stock=stock;
            ShippingDuration=ShipDuration;
        }
    }
}