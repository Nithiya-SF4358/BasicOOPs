using System;
using System.Collections.Generic;
using System.ComponentModel;
using oops2;
namespace oops2;
class Program{
    public static void Main(string[] args)
    {
        List<Employee> employeeslist=new List<Employee>();
        while(true){
            Console.WriteLine("*************************************MAIN MENU**********************************");
            Console.WriteLine("1.Regisstration\n2.Login\n3.Exit");
            Console.WriteLine("Enter your choice: ");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch(choice){
                case 1:{
                    RegisterEmployee();
                    break;
                }
                case 2:{
                    Login();
                    break;
                }
                case 3:{
                    Environment.Exit(0);
                    break;
                }
                default:{
                    Console.WriteLine("Invalid Choice.Please enter a valid option.");
                    break;
                }
            }
        }
         void RegisterEmployee(){
            Console.WriteLine("Enter employee name:");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Role:");
            string role=Console.ReadLine();
            Console.WriteLine("WorkLocation: 0-Office,1-Remote,2-Onsite");
            Console.WriteLine("Enter WorkLocation(0,1 or 2):");
            WorkLocation location=(WorkLocation)Convert.ToInt32(Console.ReadLine());//WorkLocation Location----Enum.TryParse(Console.ReadLine(),out joiningDate)
            Console.WriteLine("Enter Team name:");
            string Team=Console.ReadLine();
            Console.WriteLine("Enter DateOfJoining(dd/MM/yyyy):");
            DateTime joiningDate;
            DateTime.TryParse(Console.ReadLine(),out joiningDate);
            Console.WriteLine("Enter the Working Days in Month:");
            int days=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the LeaveTaken:");
            int Leave=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Gender:");
            Gender gender;
            Enum.TryParse(Console.ReadLine(),out gender);
            Employee newEmployee=new Employee(name,role,location,Team,joiningDate,days,Leave,gender);
            employeeslist.Add(newEmployee);
            Console.WriteLine($"Employee Registered Sucessfully!!!");            
        }
        void Login(){
            Console.WriteLine("Enter your EmployeeId:");
                string loginId=Console.ReadLine();
                bool found=false;
                foreach(Employee E in employeeslist){
                    if(E.EmployeeId==loginId){
                        found=true;
                    }else{
                        Console.WriteLine("Invalid EmployeeId:-(");
                    }
                
                   if(found){
                    while(true){
                        Console.WriteLine("1.Calculate Salary\n 2.Display Details \n3.Exit");
                        Console.WriteLine("Enter your Choice:");
                        int subchoice=Convert.ToInt32(Console.ReadLine());
                        switch(subchoice){
                            case 1:{
                                int money = int.Parse(Console.ReadLine());
                                double salary=E.Salary(money);
                                Console.WriteLine($"Employee'sSalary: {salary}");
                                break;
                            }
                            case 2:{
                                E.DisplayDetails();
                                break;
                            }
                            case 3:{
                                return;
                            }
                            default:{
                                Console.WriteLine("Invalid choice Please Try Again!!!");
                                break;
                            }
                        }
                    }
        }
    
                }
        }
    }
    }

