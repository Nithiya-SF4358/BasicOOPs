using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Xml.Serialization;
using oops1;
namespace BankAccount;
class Program
{
    static List<Customer> customers = new List<Customer>();
    public static void Main(string[] args)
    {
        string input = "Y";
        while (input == "Y" || input == "y")
        {
            Console.WriteLine("\n*****MAIN MENU*****");
            Console.WriteLine("\n 1.Registration\n 2.Login\n 3.Exit");
            Console.WriteLine("Enter your choice to proceed:");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Register();
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter your CustomerId:");
                string loginId = Console.ReadLine();
                bool found = false;
                Customer loggedIn = null;
                foreach (Customer customer in customers)
                {
                    if (customer.cusid == loginId)
                    {
                        found = true;
                        loggedIn = customer;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect CustomerId!!!");
                        break;
                    }
                }
                if (found)
                {
                    while (true)
                    {
                        Console.WriteLine("****CLICK HERE TO PROCEED****");
                        Console.WriteLine("1.Deposit\n 2.Withdraw \n3.CheckBalance\n4.Exit");
                        Console.WriteLine("Enter your Choice:");
                        int subchoice = Convert.ToInt32(Console.ReadLine());
                        switch (subchoice)
                        {
                            case 1:
                                {
                                    Console.Write("Enter amount to deposit:");
                                    double deposit = Convert.ToDouble(Console.ReadLine());
                                    loggedIn.Deposit(deposit);
                                    break;
                                }
                            case 2:
                                {
                                    Console.Write("Enter amount to Withdraw:");
                                    double withdrawn = Convert.ToDouble(Console.ReadLine());
                                    loggedIn.withdraw(withdrawn);
                                    break;
                                }
                            case 3:
                                {
                                    loggedIn.checkBalance();
                                    break;
                                }
                            case 4:
                                {
                                    Console.Write("Logged Out Returning to Main menu!!");
                                    break;
                                }
                            default:
                                {
                                    Console.WriteLine("InvalidChoice.Please try again:-(");
                                    break;
                                }

                        }
                        if (subchoice == 4)
                        {
                            break;
                        }
                    }
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Existing Application....");
                Console.WriteLine("Do you need another transactions:[Y/N]: ");
                input = Console.ReadLine().ToUpper();
            }
        }
        static void Register()
        {
            Console.WriteLine("Enter CustomerName: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("Enter Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter your phone number:");
            long phone = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter your MailId:");
            string mailId = Console.ReadLine();
            Console.WriteLine("Enter your DateOfBirth:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Customer customer1 = new Customer(customerName, phone, mailId, gender, dob);
            customers.Add(customer1);
            Console.WriteLine($"Registration Successfull!!Your Registration Id is{customer1.cusid}");

        }
    }
}