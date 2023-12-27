using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
namespace Syncart
{
    class Program
    {
        public static List<CustomerDetails> CustomerList = new List<CustomerDetails>();
        public static List<ProductDetails> ProductList = new List<ProductDetails>();
        public static List<OrderDetails> OrderList = new List<OrderDetails>();
        public static CustomerDetails currentCustomer;

        public static void Main(string[] args)
        {
            LoadData();
            string input = "yes";
            do
            {
                Console.WriteLine("------WELCOME TO THE SYNCART------");
                Console.WriteLine("Please Choose one to Proceed: ");
                Console.WriteLine("1.Customer Registration\n2.Login\n3.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Welcome to the Customer Registration Portal...");
                            CustomerRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Welcome to the Login page...");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Exit Sucessfully!!!");
                            input = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice:-(");
                            break;
                        }
                }
            } while (input == "yes");
        }
        public static void CustomerRegistration()
        {
            //get values from the user...
            Console.WriteLine("Enter your CustomerName:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your City:");
            string city = Console.ReadLine();
            Console.WriteLine("Enter your Mobile:");
            long mobile = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your WalletBalance:");
            double walletBalance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mailid:");
            string mailid = Console.ReadLine();
            //store the values in object
            CustomerDetails customerdetail1 = new CustomerDetails(name, city, mobile, walletBalance, mailid);
            //create the list and add the object to the list
            List<CustomerDetails> customerDetailsList = new List<CustomerDetails>();
            customerDetailsList.Add(customerdetail1);
            //display the values to check the flow
            string line="*******************************************************************************************************************************";
            System.Console.WriteLine(line);
            System.Console.WriteLine($"{"CUSTOMERID",-15}  {"CUSTOMERNAME",-20}  {"CITY",-15}  {"MOBILE",-10}  {"WALLET BALANCE",-15} {"MAILID",15}");
            System.Console.WriteLine(line);
            foreach (CustomerDetails customer in customerDetailsList)
            {
                System.Console.WriteLine($"{customer.CustomerID,-15}  {customer.Name,-20}  {customer.City,-15}  {customer.Mobile,-10}  {customer.WalletBalance,-15} {customer.MailID,15}");
                System.Console.WriteLine(line);
            }
            Console.WriteLine($"Registration Sucessfull!!! Your CustomerID is {customerdetail1.CustomerID}.");

        }
        public static void Login()
        {
            //get the customer Id from the user
            Console.WriteLine("Enter your CustomerId: ");
            string loginId = Console.ReadLine();
            //validate the user id
            bool flag = true;
            foreach (CustomerDetails customer in CustomerList)
            {
                //if user id is valid show submenu to proceed further
                if (loginId.Equals(customer.CustomerID))
                {
                    flag = false;
                    currentCustomer = customer;
                    SubMenu();
                    break;
                }
            }
            //if user id is invalid show invalid userid
            if (flag == true)
            {
                Console.WriteLine("Invalid loginId");
            }
        }

        public static void SubMenu()
        {
            string input1 = "yes";
          
            do
            {
                Console.WriteLine("Choose one to proceed further....");
                Console.WriteLine("a.Purchase\nb.Order History\nc.Cancel Order\nd.Wallet Balance\ne.Wallet Recharge\nf.Exit");
                char choice = char.Parse(Console.ReadLine().ToLower());
                switch (choice)
                {
                    case 'a':
                        {
                            Purchase();
                            break;
                        }
                    case 'b':
                        {
                            OrderHistory();
                            break;
                        }
                    case 'c':
                        {
                            CancelOrder();
                            break;
                        }
                    case 'd':
                        {
                            WalletBalance();
                            break;
                        }
                    case 'e':
                        {
                            WalletRecharge();
                            break;
                        }
                    case 'f':
                        {
                            input1 = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice");
                            break;
                        }
                }
            } while (input1.Equals("yes"));
        }
        public static void LoadData()
        {
            //load default data
            ProductDetails Product1 = new ProductDetails("Mobile (Samsung)", 10, 10000, 3);
            ProductDetails Product2 = new ProductDetails("Tablet (Lenovo)", 5, 15000, 2);
            ProductDetails Product3 = new ProductDetails("Camara (Sony)", 3, 20000, 4);
            ProductDetails Product4 = new ProductDetails("iphone", 5, 50000, 6);
            ProductDetails Product5 = new ProductDetails("Laptop (Lenovo I3)", 3, 40000, 3);
            ProductDetails Product6 = new ProductDetails("HeadPhone (Boat)", 5, 1000, 2);
            ProductDetails Product7 = new ProductDetails("Speakers (Boat)", 4, 500, 2);
            ProductList.Add(Product1);
            ProductList.Add(Product2);
            ProductList.Add(Product3);
            ProductList.Add(Product4);
            ProductList.Add(Product5);
            ProductList.Add(Product6);
            ProductList.Add(Product7);
            CustomerDetails customer1 = new CustomerDetails("Ravi", "Chennai", 9885858588, 50000, "ravi@mail.com");
            CustomerDetails customer2 = new CustomerDetails("Baskaran", "Chennai", 9888475757, 60000, "baskaran@mail.com");
            CustomerList.Add(customer1);
            CustomerList.Add(customer2);
            OrderDetails Order1 = new OrderDetails(customer1.CustomerID, Product1.ProductID, 20000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderDetails Order2 = new OrderDetails(customer2.CustomerID, Product2.ProductID, 40000, DateTime.Now, 2, OrderStatus.Ordered);
            OrderList.Add(Order1);
            OrderList.Add(Order2);
        }
        public static void Purchase()
        {
            bool flag=false;
            //display the product details
            Console.WriteLine("PRODUCT DETAILS:");
            string line="*******************************************************************************************************************************";
            System.Console.WriteLine(line);
            System.Console.WriteLine($"{"ProductID",-15}  {"ProductName:",-20}  {"ProductPrice:",-15}  {"Stock:",-10}  {"Shipping Duration:",-5} ");
            System.Console.WriteLine(line);
            foreach (ProductDetails product in ProductList)
            {
               System.Console.WriteLine($" {product.ProductID,-15}  {product.ProductName,-20}  {product.Price,-15}  {product.Stock,-15}  {product.ShippingDuration,-15} "); 
               System.Console.WriteLine(line);
            }
            //get the product id to be purchased from the customer
            Console.WriteLine("Enter the Product Id:");
            string wantedProduct = Console.ReadLine();
            //validate the productid
            foreach (ProductDetails product in ProductList)
            {
                if (wantedProduct.Equals(product.ProductID))
                {
                    //if valid get the quantity from customer
                    Console.WriteLine("Enter the Quantity:");
                    int quantity = Convert.ToInt32(Console.ReadLine());
                    //ensure the stock availability
                    if (quantity <= product.Stock)
                    {
                        //calculate total price
                        double totalPrice = quantity * product.Price + 50;
                        //validate wallet balance
                        if (totalPrice <= currentCustomer.WalletBalance)
                        {
                            //deduct the total amount from the customer wallet
                            currentCustomer.WalletBalance -= totalPrice;
                            Console.WriteLine($"Your Wallet Balance is {currentCustomer.WalletBalance}");
                            //reduce the count purchase  count from the stock
                            product.Stock -= quantity;
                            //create the obj for place the order
                            OrderDetails order3 = new OrderDetails(currentCustomer.CustomerID, product.ProductID, totalPrice, DateTime.Now, quantity, OrderStatus.Ordered);
                            //display the order details so the success message with order id and delivery date
                            OrderList.Add(order3);
                            Console.WriteLine($"Your order is placed sucessfully..your orderId is {order3.OrderId}.");
                            Console.WriteLine($"DeliveryDate is {DateTime.Now.AddDays(product.ShippingDuration)}");
                            flag=true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Balance...:-(");
                        }
                    }
                    else
                    {
                        Console.WriteLine("OUT OF STOCK...");
                    }
                }
                
            }
            if(flag==false){
                Console.WriteLine("Invalid ProductId!");
            }
        }
        public static void OrderHistory()
        {
            Console.WriteLine("ORDER DETAILS:");
            string line="*******************************************************************************************************************************";
            System.Console.WriteLine(line);
            System.Console.WriteLine($"{"ORDERID",-15} {"CUSTOMERID",-15} {"PRODUCTID",-15}  {"PRICE:",-15}  {"PURCHASE DATE:",-25}  {"QUANTITY:",-25} {"STATUS",-25}");
            System.Console.WriteLine(line);
            foreach (OrderDetails order in OrderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID)
                {
                    System.Console.WriteLine($"{order.OrderId,-15} {order.CustomerID,-15} {order.ProductId,-15}  {order.TotalPrice,-15}  {order.PurchaseDate,-30}  {order.Quantity,-20} {order.Order,-5}");
                    System.Console.WriteLine(line);
                }
            }
            
        }
        public static void CancelOrder()
        {
            Console.WriteLine("ORDER DETAILS:");
            string line="*******************************************************************************************************************************";
            System.Console.WriteLine(line);
            System.Console.WriteLine($"{"ORDERID",-15} {"CUSTOMERID",-15} {"PRODUCTID",-15}  {"PRICE:",-15}  {"PURCHASE DATE:",-25}  {"QUANTITY:",-25} {"STATUS",-25}");
            System.Console.WriteLine(line);
            foreach (OrderDetails order in OrderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID&&order.Order == OrderStatus.Ordered)
                {
                   System.Console.WriteLine($"{order.OrderId,-15} {order.CustomerID,-15} {order.ProductId,-15}  {order.TotalPrice,-15}  {order.PurchaseDate,-30}  {order.Quantity,-20} {order.Order,-5}");
                    System.Console.WriteLine(line);
                }
            }
            Console.WriteLine("which one do you want to cancel enter the id here:");
            string input=Console.ReadLine();
            foreach (OrderDetails order in OrderList)
            {
                if (currentCustomer.CustomerID == order.CustomerID && order.Order == OrderStatus.Ordered&&order.OrderId==input)
                {
                    //refund the money
                    currentCustomer.WalletBalance += order.TotalPrice;
                    Console.WriteLine($"Your money is Refunded sucessfullly...!");
                    Console.WriteLine($"Your Current balance is {currentCustomer.WalletBalance}");
                    foreach (ProductDetails product in ProductList)
                    {
                        if (order.ProductId == product.ProductID && order.Order == OrderStatus.Ordered)
                        {
                            //refund the stock
                            product.Stock += order.Quantity;
                            order.Order=OrderStatus.Cancelled;
                            Console.WriteLine("YOUR ORDER CANCELLED SUCESSFULLY....!");
                        }
                    }
                }
            }
        }
        public static void WalletRecharge()
        {
            Console.WriteLine("enter the amount to recharge:");
            int amount = Convert.ToInt32(Console.ReadLine());
            currentCustomer.WalletBalance += amount;
            Console.WriteLine("Recharged sucessfullly...!");

        }
        public static void WalletBalance()
        {
            Console.WriteLine($"Your Wallet Balance is {currentCustomer.WalletBalance}");

        }
    }
}