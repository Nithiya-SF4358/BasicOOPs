using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Transactions;
namespace OnlineLibrary
{

    class Program
    {
        static List<UserDetails> userdetailsList = new List<UserDetails>();
        static List<BookDetails> bookDetailsList = new List<BookDetails>();

        static List<BorrowDetails> borrowDetailsList = new List<BorrowDetails>();
        static UserDetails currentUser;
        static BookDetails currentBook;
        public static void Main(string[] args)
        {
            LoadData();
            string line = "***********************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine("                    WELCOME TO SYNCFUSION ONLINE LIBRARY MANAGEMENT                        ");
            System.Console.WriteLine(line);
            string input = "yes";
            do
            {
                Console.WriteLine("CHOOSE ONE TO PROCEED.....");
                Console.WriteLine("1.USER REGISTRATION\n2.USER LOGIN\n3.EXIT");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            UserRegistration();
                            break;
                        }
                    case 2:
                        {
                            UserLogin();
                            break;
                        }
                    case 3:
                        {
                            input = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice...:-(");
                            break;
                        }
                }









            } while (input == "yes");
        }
        public static void LoadData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.Male, Department.EEE, 9938388333, "ravi@gmail.com", 100);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.Female, Department.CSE, 9944444455, "priya@gmail.com", 150);
            userdetailsList.Add(user1);
            userdetailsList.Add(user2);
            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            bookDetailsList.Add(book1);
            bookDetailsList.Add(book2);
            bookDetailsList.Add(book3);
            bookDetailsList.Add(book4);
            bookDetailsList.Add(book5);
            BorrowDetails borrow1 = new BorrowDetails("BID1001", "SF3001", DateTime.ParseExact("10/09/2023", "dd/MM/yyyy", null), 2, Status.Borrowed, 0);
            BorrowDetails borrow2 = new BorrowDetails("BID1003", "SF3001", DateTime.ParseExact("12/09/2023", "dd/MM/yyyy", null), 1, Status.Borrowed, 0);
            BorrowDetails borrow3 = new BorrowDetails("BID1004", "SF3001", DateTime.ParseExact("14/09/2023", "dd/MM/yyyy", null), 1, Status.Returned, 16);
            BorrowDetails borrow4 = new BorrowDetails("BID1002", "SF3002", DateTime.ParseExact("11/09/2023", "dd/MM/yyyy", null), 2, Status.Borrowed, 0);
            BorrowDetails borrow5 = new BorrowDetails("BID1005", "SF3002", DateTime.ParseExact("09/09/2023", "dd/MM/yyyy", null), 1, Status.Returned, 20);
            borrowDetailsList.Add(borrow1);
            borrowDetailsList.Add(borrow2);
            borrowDetailsList.Add(borrow3);
            borrowDetailsList.Add(borrow4);
            borrowDetailsList.Add(borrow5);

        }
        public static void UserRegistration()
        {
            Console.WriteLine("**************************Welcome to the User Registration Page*********************************");
            Console.WriteLine("ENTER YOUR NAME:");
            string UserName = Console.ReadLine();
            Console.WriteLine("ENTER YOUR GENDER:");
            Gender gender1;
            bool gender = Enum.TryParse(Console.ReadLine(), out gender1);
            Console.WriteLine("ENTER YOUR DEPARTMENT:");
            Department department1;
            bool department = Enum.TryParse(Console.ReadLine(), out department1);
            Console.WriteLine("ENTER YOUR MOBILE:");
            long mobileNumber = long.Parse(Console.ReadLine());
            Console.WriteLine("ENTER YOUR MAILID:");
            string mailid = Console.ReadLine();
            Console.WriteLine("ENTER YOUR WALLET BALANCE:");
            double walletBalance = double.Parse(Console.ReadLine());
            UserDetails user3 = new UserDetails(UserName, gender1, department1, mobileNumber, mailid, walletBalance);
            userdetailsList.Add(user3);
            Console.WriteLine($"YOUR REGISTERED USERID IS {user3.UserID} ");
        }
        public static void UserLogin()
        {
            Console.WriteLine("********************************Welcome to the Login Portal***********************************");
            Console.WriteLine("Enter your UserId:");
            string loginId = Console.ReadLine().ToUpper();
            bool flag = false;
            foreach (UserDetails user in userdetailsList)
            {
                if (user.UserID == loginId)
                {
                    currentUser = user;
                    flag = true;
                    LoginPage();
                    break;

                }
            }
            if (flag == false)
            {
                Console.WriteLine("INVALID USERID....");
            }
        }
        public static void LoginPage()
        {
            string input = "yes";
            do
            {
                Console.WriteLine("CHOOSE ONE TO PROCEED.....");
                Console.WriteLine("1.BORROW BOOK\n2.SHOW BORROWED HISTORY \n3.RETURN BOOK\n4.WALLET RECHARGE\n5.EXIT");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Borrowbook();
                            break;
                        }
                    case 2:
                        {
                            ShowBorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            ReturnBook();
                            break;
                        }
                    case 4:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 5:
                        {
                            input = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice...:-(");
                            break;
                        }
                }
            } while (input == "yes");

        }
        public static void Borrowbook()
        {
            string line = "***********************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($"{"BOOKID",15}  {"BOOK NAME",15}  {"AUTHOR NAME",15}  {"BOOK COUNT",15}");
            System.Console.WriteLine(line);
            foreach (BookDetails book in bookDetailsList)
            {
                Console.WriteLine($"{book.BookId,15}  {book.BookName,15}  {book.AuthorName,15}  {book.BookCount,15}");
                System.Console.WriteLine(line);
            }
            bool flag = true;
            foreach (BookDetails book in bookDetailsList)
            {
                Console.WriteLine("Enter any BookId that you want to borrow:");
                string bookid = Console.ReadLine().ToUpper();
                if (book.BookId == bookid)
                {
                    currentBook = book;
                    flag = false;
                    Console.WriteLine("Enter the count of book:");
                    int count = int.Parse(Console.ReadLine());
                    bool flag1 = false;
                    if (count <= book.BookCount)
                    {
                        foreach (BorrowDetails borrow in borrowDetailsList)
                        {
                            if (borrow.UserID == currentUser.UserID)
                            {
                                flag1 = true;
                                if (borrow.BorrowBookCount <= 3)
                                {
                                    Console.WriteLine($"your borrowedID is{borrow.BorrowID}.");
                                    borrow.GetStatus = Status.Borrowed;
                                    book.BookCount -= count;
                                    BorrowDetails borrow6 = new BorrowDetails(borrow.BorrowID, currentUser.UserID, DateTime.Now, count, borrow.GetStatus, 0);
                                    borrowDetailsList.Add(borrow6);
                                    Console.WriteLine("Book Borrowed Sucessfully...!");
                                }
                                break;

                            }
                        }
                        if (flag1 == false)
                        {
                            Console.WriteLine("You have borrowed 3 books already");
                            Console.WriteLine("Do you want to request a book[yes/no]:");
                            string request = Console.ReadLine().ToLower();
                            int count1 = 0;
                            if (request == "yes")
                            {
                                count1++;
                                if (count1 > 3)
                                {
                                    Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is 3 and requested count is {count}, which exceeds 3 ”.");
                                }
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Books are not available for the selected count.");
                        DateTime date = DateTime.Now;
                        Console.WriteLine($"The next book will be available on {date.AddDays(15)}");
                        break;
                    }
                }
                break;
            }
            if (flag == true)
            {
                Console.WriteLine("Invalid Book ID, Please enter valid ID......");
            }

        }
        public static void ShowBorrowedHistory()
        {
            string line = "***********************************************************************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($"{"BORROWID",15}  {"BOOKID",15}  {"USERID",15}  {"BORROWDATE",15}  {"BORROW COUNT",25}  {"STATUS",10}  {"PAIDFINEAMOUNT",25}");
            System.Console.WriteLine(line);
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentUser.UserID == borrow.UserID)
                {
                    Console.WriteLine($"{borrow.BorrowID,15}  {borrow.BookID,15}  {borrow.UserID,15}  {borrow.BorrowDate,15}  {borrow.BorrowBookCount,15}  {borrow.GetStatus,15}  {borrow.PaidFineAmount,15}");
                    System.Console.WriteLine(line);
                }
            }
        }
        public static void ReturnBook()
        {
            string line = "***********************************************************************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($"{"BORROWID",15}  {"BOOKID",15}  {"USERID",15}  {"BORROWDATE",15}  {"BORROW COUNT",25}  {"STATUS",10}  {"PAIDFINEAMOUNT",25}");
            System.Console.WriteLine(line);
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                if (currentUser.UserID == borrow.UserID)
                {
                    Console.WriteLine($"{borrow.BorrowID,15}  {borrow.BookID,15}  {borrow.UserID,15}  {borrow.BorrowDate,15}  {borrow.BorrowBookCount,15}  {borrow.GetStatus,15}  {borrow.PaidFineAmount,15}");
                    System.Console.WriteLine(line);
                }
            }
            Console.WriteLine("which book do you want to return enter the borrowid:");
            string bid = Console.ReadLine();
            Console.WriteLine("enter the count of the book:");
            int count3 = int.Parse(Console.ReadLine());
            foreach (BorrowDetails borrow in borrowDetailsList)
            {
                DateTime days1 = borrow.BorrowDate;
                DateTime days2 = days1.AddDays(15);
                if (borrow.BorrowID == bid && currentUser.UserID == borrow.UserID)
                {
                    if (days1 <= days2)
                    {
                        Console.WriteLine($"Book will be returned Within 15 days.");
                        borrow.GetStatus = Status.Returned;
                        break;
                    }
                }
                else
                {
                    int daystodeduct = days2.Day - 15;
                    double fineAmount = 1 * daystodeduct * count3;
                    if (currentUser.WalletBalance <= fineAmount)
                    {
                        currentUser.DeductBalance(fineAmount);
                        Console.WriteLine("fineAmount will be dedeucted");
                        borrow.GetStatus = Status.Returned;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Balance");
                        break;
                    }
                }
                foreach (BookDetails book in bookDetailsList)
                {
                    if (borrow.BookID == book.BookId)
                    {
                        book.BookCount += count3;
                    }
                }
            }
        }
        public static void WalletRecharge()
        {
            Console.WriteLine("Do you want to recharge your wallet?[YES/NO]");
            string input = Console.ReadLine().ToUpper();
            if (input == "YES")
            {
                Console.WriteLine("Enter the amount:");
                double amount = double.Parse(Console.ReadLine());
                currentUser.WalletRechargeFunction(amount);
                Console.WriteLine($"your Balance is updated {currentUser.WalletBalance}.");
            }
        }
    }


}