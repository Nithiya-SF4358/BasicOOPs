using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Buffers;

namespace Syncart
{
    public class FileHandling
    {
        public static void Create(){
            if(!Directory.Exists("Syncart")){
                Console.WriteLine("Creating Folder...");
                Directory.CreateDirectory("Syncart");
            }
            //File for Customer Info
            if(!File.Exists("Syncart/CustomerDetails.csv")){
                System.Console.WriteLine("Creating Folder....");
                File.Create("Syncart/CustomerDetails.csv").Close();
            }
            //File for Order Info
            if(!File.Exists("Syncart/OrderDetails.csv")){
                System.Console.WriteLine("Creating Folder....");
                File.Create("Syncart/OrderDetails.csv").Close();
            }
            //File for Product Info
            if(!File.Exists("Syncart/ProductDetails.csv")){
                System.Console.WriteLine("Creating Folder....");
                File.Create("Syncart/ProductDetails.csv").Close();
            }
        }
        public static void WriteToCsv(){
            string[] customers=new string[Program.CustomerList.Count];
            for(int i=0;i<Program.CustomerList.Count;i++){
                customers[i]=Program.CustomerList[i].CustomerID+","+Program.CustomerList[i].Name+","+Program.CustomerList[i].City+","+Program.CustomerList[i].Mobile+","+Program.CustomerList[i].WalletBalance+","+Program.CustomerList[i].MailID;
            }
            File.WriteAllLines("Syncart/CustomerDetails.csv",customers);
            string[] orders=new string[Program.OrderList.Count];
            for(int i=0;i<Program.OrderList.Count;i++){
                orders[i]=Program.OrderList[i].OrderId+","+Program.OrderList[i].CustomerID+","+Program.OrderList[i].ProductId+","+Program.OrderList[i].TotalPrice+","+Program.OrderList[i].PurchaseDate.ToString("dd/MM/yyyy")+","+Program.OrderList[i].Quantity+","+Program.OrderList[i].Order;
            }
            File.WriteAllLines("Syncart/OrderDetails.csv",orders);
            string[] products=new string[Program.ProductList.Count];
            for(int i=0;i<Program.ProductList.Count;i++){
                products[i]=Program.ProductList[i].ProductID+","+Program.ProductList[i].ProductName+","+Program.ProductList[i].Price+","+Program.ProductList[i].Stock+","+Program.ProductList[i].ShippingDuration;
            }
            File.WriteAllLines("Syncart/ProductDetails.csv",products);
        }
        public static void ReadFromCsv(){
            string[]customers=File.ReadAllLines("Syncart/CustomerDetails.csv");
            foreach(string customer in customers){
                CustomerDetails customer1=new CustomerDetails(customer);
                Program.CustomerList.Add(customer1);
            }
            string []order=File.ReadAllLines("Syncart/ProductDetails.csv");
            foreach(string order1 in order){
                OrderDetails orderDetails=new OrderDetails(order1);
                Program.OrderList.Add(orderDetails);         
            }
            string[]product=File.ReadAllLines("Syncart/ProductDetails.csv");
            foreach(string product1 in product){
                ProductDetails productDetails=new ProductDetails(product1);
                Program.ProductList.Add(productDetails);
            }
        }
    }
}