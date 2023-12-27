using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart

{
    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_OrderId=1000;
        public string OrderId { get; }
        public string CustomerID { get; }
        public string ProductId { get; }
        public double TotalPrice { get; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Order{get;set;}
        public OrderDetails(string CusID,string proid,double price,DateTime dateofpurchase,int quantity,OrderStatus status ){
            s_OrderId++;
            OrderId="OID"+s_OrderId;
            CustomerID=CusID;
            ProductId=proid;
            TotalPrice=price;
            PurchaseDate=dateofpurchase;
            Quantity=quantity;
            Order=status;
        }
    }
}