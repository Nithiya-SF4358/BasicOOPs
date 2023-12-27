using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Transactions;
namespace CollegeAdmission
{
    class Program
    {
        static List<StudentDetails> studentDetailList = new List<StudentDetails>();
        static List<AdmissionDetails> admissionDetailsList = new List<AdmissionDetails>();
        static List<DepartmentDetails> departmentDetailsList = new List<DepartmentDetails>();
        static StudentDetails currentStudentId;
        public static void Main(string[] args)
        {
            //Load the default data in the list
            LoadData();
            //build the application main menu
            Console.WriteLine("                   SYNCFUSION COLLEGE OF ENGINEERING AND TECHNOLOGY               ");
            string input = "yes";
            do
            {
                Console.WriteLine("1.STUDENT REGISTRATION\n2.STUDENT LOGIN\n3.DEPARTMENT WISE SEAT AVAILABLITY\n4.EXIT");
                Console.WriteLine("CLICK YOUR CHOICE TO PROCEED.....");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("                 STUDENT REGISTRATION PAGE                   ");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("                 DEPARTMENTS                   ");
                            DepartmentAvailability();
                            break;
                        }
                    case 4:
                        {
                            input = "no";
                            break;
                        }
                }

            } while (input == "yes");
        }
        public static void LoadData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", DateTime.Parse("11/11/1999"), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", DateTime.Parse("11/11/1999"), Gender.Male, 95, 95, 95);
            studentDetailList.Add(student1);
            studentDetailList.Add(student2);
            DepartmentDetails Department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails Department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails Department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails Department4 = new DepartmentDetails("ECE", 30);
            departmentDetailsList.Add(Department1);
            departmentDetailsList.Add(Department2);
            departmentDetailsList.Add(Department3);
            departmentDetailsList.Add(Department4);
            AdmissionDetails admission1 = new AdmissionDetails("SF3001","DID101",DateTime.Parse("11/05/2022"), AdmissionStatus.Booked);
            AdmissionDetails admission2 = new AdmissionDetails("SF3002","DID102",DateTime.Parse("11/05/2022"), AdmissionStatus.Booked);
            admissionDetailsList.Add(admission1);
            admissionDetailsList.Add(admission2);
        }
        public static void StudentRegistration()
        {
            //get values from the user...
            Console.WriteLine("Enter your StudentName:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your FatherName:");
            string fathername = Console.ReadLine();
            Console.WriteLine("Enter your DateOfBirth:");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Gender:");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter your mark in Physics:");
            int physics = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mark in Chemistry:");
            int chemistry = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your mark in Maths:");
            int maths = int.Parse(Console.ReadLine());
            //store the values in object
            StudentDetails student3 = new StudentDetails(name, fathername, dob, gender, physics, chemistry, maths);
            //create the list and add the object to the list
            studentDetailList.Add(student3);
            Console.WriteLine($"Student Added Sucessfully and Student ID is {student3.StudentID}.");
        }
        public static void StudentLogin()
        {
            Console.WriteLine("                WELCOME TO LOGIN PAGE                 ");
            Console.WriteLine("Enter Your StudentId to Proceed:");
            string loginId = Console.ReadLine();
            bool flag=true;
            foreach (StudentDetails student in studentDetailList)
            {
                if (student.StudentID == loginId.ToUpper())
                {
                    flag=false;
                    currentStudentId = student;
                    Login();
                }
            }
            if(flag){
                Console.WriteLine("Invalid StudentId:-(");
            }
        }
        public static void DepartmentAvailability()
        {
            string line = "*******************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($" {"DepartmentID",-15} {"DepartmentName",-15} {"NumberOfSeats",20}");
            System.Console.WriteLine(line);
            foreach (DepartmentDetails department in departmentDetailsList)
            {
                Console.WriteLine($" {department.DepartmentID,-15} {department.DepartmentName,-25} {department.NumberOfSeats,5}");
                System.Console.WriteLine(line);
            }
        }
        public static void Login()
        {
            string input1 = "yes";
            do
            {
                Console.WriteLine("1.CHECK ELIGIBILTY\n2.SHOW DETAILS\n3.TAKE ADMISSION\n4.CANCEL ADMISSION\n5.SHOW ADMISSION DETAILS\n6.EXIT");
                Console.WriteLine("ENTER YOUR CHOICE TO PROCEED....");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Wait for few minutes.....checking your eligibility...!");
                            Thread.Sleep(3000);
                            Eligible();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("                STUDENT DETAILS                ");
                            Thread.Sleep(3000);
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("               ADMISSION PAGE               ");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("               CANCEL ADMISSION               ");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("               ADMISSION DETAILS               ");
                            ShowAdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("              EXIT SUCESSFULLY!              ");
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
        public static void Eligible()
        {
            int average = (currentStudentId.Physics + currentStudentId.Chemistry + currentStudentId.Maths) / 3;
            bool eligible = currentStudentId.CheckEligibility(average);
            if (eligible == true)
            {
                Console.WriteLine($"{currentStudentId.Name} you are eligible...");
            }
            else
            {
                Console.WriteLine($"{currentStudentId.Name} you are not eligible...");
            }
        }
        public static void ShowDetails()
        {
            foreach (StudentDetails student in studentDetailList)
            {
                if (currentStudentId == student)
                {
                    Console.WriteLine($"{"YOUR DETAILS:"}");
                    Console.WriteLine("StudenntName:" + currentStudentId.Name);
                    Console.WriteLine("StudenntID:" + currentStudentId.StudentID);
                    Console.WriteLine("StudentFatherName:" + currentStudentId.FatherName);
                    Console.WriteLine("StudenntDOB:" + currentStudentId.DOB);
                    Console.WriteLine("Gender:" + currentStudentId.GetGender);
                    Console.WriteLine("Student mark in Physics:" + currentStudentId.Physics);
                    Console.WriteLine("Studennt mark in Chemistry:" + currentStudentId.Chemistry);
                    Console.WriteLine("Studennt mark in Maths:" + currentStudentId.Maths);
                }
            }

        }
        public static void TakeAdmission()
        {
            string line = "*******************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($" {"DepartmentID",-15} {"DepartmentName",-15} {"NumberOfSeats",20}");
            System.Console.WriteLine(line);
            foreach (DepartmentDetails department in departmentDetailsList)
            {
                Console.WriteLine($" {department.DepartmentID,-15} {department.DepartmentName,-25} {department.NumberOfSeats,5}");
                System.Console.WriteLine(line);
            }
            Console.WriteLine("Enter the DepartmentId:");
            string id=Console.ReadLine();
            int average=(currentStudentId.Physics+currentStudentId.Chemistry+currentStudentId.Maths)/3;
            foreach(DepartmentDetails department in departmentDetailsList){
                if(department.DepartmentID==id){
                    bool input=currentStudentId.CheckEligibility(average);
                    if(input==true){
                        int seats=1;
                        if(seats<=department.NumberOfSeats){
                            foreach(AdmissionDetails admission in admissionDetailsList){
                                if(admission.StudentID!=currentStudentId.StudentID){
                                    department.NumberOfSeats-=seats;
                                    AdmissionDetails admission3=new AdmissionDetails(currentStudentId.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Booked);
                                    admissionDetailsList.Add(admission3);
                                    Console.WriteLine($"Admission took successfully. Your admission ID {admission.AdmissionID}.");
                                    break;
                                }else{
                                    Console.WriteLine("already you have a admission.");
                                    break;
                                }
                            }
                        }else{
                            Console.WriteLine("Seats are full sorry....you can try another department...");
                        }
                    }else{
                        Console.WriteLine("You are not eligible:-(");
                    }
                }
            }

    }
        public static void CancelAdmission()
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (AdmissionDetails admission in admissionDetailsList)
            {
                if (currentStudentId.StudentID == admission.StudentID)
                {
                    foreach (DepartmentDetails department in departmentDetailsList)
                    {

                        if (admission.DepartmentID == department.DepartmentID&&admission.Status==AdmissionStatus.Booked)
                        {
                            string line = "*******************************************************************************************************";
                            System.Console.WriteLine(line);
                            Console.WriteLine($" {"ADMISSIONID",-15} {"STUDENTID",-15}  {"DEPARTMENTID",-15} {"ADMISSION DATE",-15} {"STATUS",15}");
                            System.Console.WriteLine(line);
                            Console.WriteLine($" {admission.AdmissionID,-15} {admission.StudentID,-15}  {admission.DepartmentID,-15} {admission.AdmissionDate,-15} {admission.Status,7}");
                            System.Console.WriteLine(line);
                            Console.WriteLine("Do you want to cancel the  admission?");
                            string input = Console.ReadLine().ToUpper();
                            if (input == "YES")
                            {
                                department.NumberOfSeats += 1;
                                admission.Status = AdmissionStatus.Cancelled;
                                Console.WriteLine("your Admission cancelled sucessfully.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please give a valid input");
                                break;
                            }
                        }
                    }
                }

            }

        }
        public static void ShowAdmissionDetails()
        {
            string line = "*******************************************************************************************************";
            System.Console.WriteLine(line);
            Console.WriteLine($" {"ADMISSIONID",-15} {"STUDENTID",-15}  {"DEPARTMENTID",-15} {"ADMISSION DATE",-15} {"STATUS",20}");
            System.Console.WriteLine(line);
            foreach(AdmissionDetails admission in admissionDetailsList)
            {
                  if(admission.StudentID==currentStudentId.StudentID){
                    Console.WriteLine($" {admission.AdmissionID,-15} {admission.StudentID,-15}  {admission.DepartmentID,-15} {admission.AdmissionDate,-15} {admission.Status,20}");
                    System.Console.WriteLine(line);
                    break;
                  }
            }
        }

    }
}
