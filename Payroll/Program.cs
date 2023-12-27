using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
namespace Payroll
{
    class Program
    {
        static EmployeeDetails currentEmployeeId;
        static AttendanceDetails attendance;
        static List<EmployeeDetails> employeeDetailsList = new List<EmployeeDetails>();
        static List<AttendanceDetails> attendanceDetailsList = new List<AttendanceDetails>();
        public static void Main(string[] args)
        {
            LoadData();
            Console.WriteLine("              PAYROLL MANAGEMENT SYSTEM                ");
            string input = "yes";
            do
            {
                Console.WriteLine("1.Employee Registration\n2.Employee Login\n3.Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            EmployeeRegistration();
                            break;
                        }
                    case 2:
                        {
                            EmployeeLogin();
                            break;
                        }
                    case 3:
                        {
                            input = "no";
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (input == "yes");
        }
        public static void LoadData()
        {
            EmployeeDetails employee1 = new EmployeeDetails("Ravi", DateTime.Parse("11/11/1999"), 9958858888, "Male", Branch.Eymard, Team.Developer);
            employeeDetailsList.Add(employee1);
            AttendanceDetails attendance1 = new AttendanceDetails("SF3001", DateTime.ParseExact("15/05/2022", "dd/MM/yyyy", null), TimeOnly.Parse("09:00 AM"), TimeOnly.Parse("6:10 PM"), 8);
            AttendanceDetails attendance2 = new AttendanceDetails("SF3002", DateTime.ParseExact("16/05/2022", "dd/MM/yyyy", null), TimeOnly.Parse("09:10 AM"), TimeOnly.Parse("6:50 PM"), 8);
            attendanceDetailsList.Add(attendance1);
            attendanceDetailsList.Add(attendance2);
        }
        public static void EmployeeRegistration()
        {
            Console.WriteLine("             WELCOME TO EMPLOYEE REGISTRATION PORTAL            ");
            Console.WriteLine("Enter your FullName:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the DateOfBirth:");
            DateTime dob;
            bool flag = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,System.Globalization.DateTimeStyles.None,out dob);
            while(!flag){
                Console.WriteLine(" you entered the date of birth incorrectly.");
                Console.WriteLine("please enter your date of birth:");
                flag = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null,System.Globalization.DateTimeStyles.None,out dob);
            }
            Console.WriteLine("Enter the Mobile:");
            long mobile;
            bool flag2= long.TryParse(Console.ReadLine(),out mobile);
            while(!flag2){
                Console.WriteLine("Invalid Input.");
                Console.WriteLine("Enter the Mobile:");
                flag2= long.TryParse(Console.ReadLine(),out mobile);

            }
            Console.WriteLine("Enter the Gender:\n1.Male\n2.Female\n3.Transgender");
            string gender = Console.ReadLine();
            Branch branch;
            Console.WriteLine("Enter the branch:\n1.Eymard\n2.Karuna\n3.Madhura");
            bool result = Enum.TryParse<Branch>(Console.ReadLine(), true, out branch);
            while (!result)
            {
                Console.WriteLine("You enter the invalid Gender...");
                Console.WriteLine("Enter your Branch:\n1.Eymard\n2.Karuna\n3.Madhura");
                result = Enum.TryParse<Branch>(Console.ReadLine(), true, out branch);
            }
            Team team;
            Console.WriteLine("Enter the Team:\n1.Network\n2.Hardware\n3.Developer\n4.Facility");
            bool result1 = Enum.TryParse<Team>(Console.ReadLine(), true, out team);
            while (!result1)
            {
                Console.WriteLine("You enter the invalid team...");
                Console.WriteLine("Enter your Team:\n1.Male\n2.Female");
                result1 = Enum.TryParse<Team>(Console.ReadLine(), true, out team);
            }
            EmployeeDetails employee2 = new EmployeeDetails(name, dob, mobile, gender, branch, team);
            employeeDetailsList.Add(employee2);
            Console.WriteLine($"Employee added successfully your id is:  {employee2.EmployeeID}");
        }
        public static void EmployeeLogin()
        {
            Console.WriteLine("                WELCOME TO EMPLOYEE LOGIN PAGE                 ");
            Console.WriteLine("Enter Your EMPLOYEEID to Proceed:");
            string loginId = Console.ReadLine();
            bool flag = true;
            foreach (EmployeeDetails employee in employeeDetailsList)
            {
                if (employee.EmployeeID == loginId.ToUpper())
                {
                    flag = false;
                    currentEmployeeId = employee;
                    Login();
                }
            }
            if (flag)
            {
                Console.WriteLine("Invalid StudentId:-(");
            }

        }
        public static void Login()
        {
            string input1 = "yes";
            do
            {
                Console.WriteLine("1.ATTENDANCE PORTAL\n2.DISPLAY DETAILS\n3.CALCULATE SALARY\n4.EXIT");
                Console.WriteLine("ENTER YOUR CHOICE TO PROCEED....");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("                ATTENDANCE PORTAL                ");
                            AddAttendance();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("                DISPLAY DETAILS                  ");
                            DisplayDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("               CALCULATE SALARY                  ");
                            CalculateSalary();
                            break;
                        }
                    case 4:
                        {
                            input1 = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("          Invalid Choice:-(          ");
                            break;
                        }
                }

            } while (input1 == "yes");
        }
        public static void AddAttendance()
        {
            Console.WriteLine("Do you want to check in[Y/N]:");
            string input = Console.ReadLine();
           
        }
        public static void DisplayDetails()
        {
            string line = "******************************************************************************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($"{"EmployeeId",-15}  {"Name",-15} {"DOB",15} {"Mobile",15} {"Gender",15} {"Branch",15} {"Team",15}");
            System.Console.WriteLine(line);
            foreach (EmployeeDetails employee in employeeDetailsList)
            {
                if (currentEmployeeId.EmployeeID == employee.EmployeeID)
                {
                    Console.WriteLine($"{currentEmployeeId.EmployeeID,-15}  {employee.FullName,-15}  {employee.DOB,-5}  {employee.Mobile,-15} {employee.Gender,-15} {employee.branch,-15} {employee.team,-15}");
                }
            }
        }
        public static void CalculateSalary()
        {
            double totalhours;
            string line = "******************************************************************************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($"{"AttendanceId",-15}  {"EmployeeId",-15}  {"Date",15} {"CheckIn",25} {"CheckOut",15} {"HoursWorked",15} ");
            System.Console.WriteLine(line);
            foreach (AttendanceDetails attendance in attendanceDetailsList)
            {
                if (currentEmployeeId.EmployeeID == attendance.EmployeeID)
                {
                    Console.WriteLine($"{attendance.AttendanceID,-15}  {currentEmployeeId.EmployeeID,-15}  {attendance.Date,-15} {attendance.CheckIn,20} {attendance.CheckOut,13} {attendance.Hours,10} ");
                    System.Console.WriteLine(line);
                    break;
                }
            }
            totalhours = attendance.Hours * 30;
            Console.WriteLine("your total salary is " + totalhours * 500);
        }

    }
}
