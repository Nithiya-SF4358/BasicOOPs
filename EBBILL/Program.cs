using  System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Serialization;
namespace oops3;
class Program{
    public static void Main(string[] args)
    {
        List<EBbill>eBbills=new List<EBbill>();
        string input="Y";
        while(input=="Y"||input=="y"){
            Console.WriteLine("*****MAIN MENU*****");
            Console.WriteLine("\n 1.Registration\n 2.Login\n 3.Exit");
            Console.WriteLine("Enter your choice to proceed:");
            int choice=int.Parse(Console.ReadLine());
            if(choice==1){
                Console.WriteLine("Enter USERID: ");
                string meterId=Console.ReadLine();
                Console.WriteLine("Enter USERNAME: ");
                string userName=Console.ReadLine();
                Console.WriteLine("Enter your phone number:");
                long userPhone=long.Parse(Console.ReadLine());
                Console.WriteLine("Enter your MailId:");
                string userMailId=Console.ReadLine();
                int unit=0;
                EBbill ebill=new EBbill(userName,userPhone,userMailId,unit);
                eBbills.Add(ebill);
                Console.WriteLine($"Registration Successfull and your meterId is{meterId}");
            }
            else if(choice==2){
                Console.WriteLine("Enter your MeterId:");
                string mId=Console.ReadLine();
                bool found=false;
                foreach(EBbill e in eBbills){
                    if(e.MeterId==mId){
                        found=true;
                    }else{
                        Console.WriteLine("Invalid MeterId:-(");
                    }
                    if(found){
                        string input1="true";
                        while(input1=="true"){
                            Console.WriteLine("1.CALCULATE AMOUNTt\n 2.DISPLAY USER DETAILS \n3.Exit");
                            Console.WriteLine("Enter your Choice:");
                            int subchoice=Convert.ToInt32(Console.ReadLine());
                            switch(subchoice){
                                case 1:{
                                    Console.Write("ENTER UNITS DETAILS:");
                                    double unit=Convert.ToDouble(Console.ReadLine());
                                    double amount=unit*5;
                                    Console.WriteLine($"AMOUNT YOU NEED TO PAY: {amount}");
                                    break;
                                }
                                case 2:{
                                    e.Details();
                                    break;
                                }
                                case 3:{
                                    Console.Write("Logged Out Returning to Main menu!!");
                                    input1="false";
                                    break;
                                }
                                default:{
                                    Console.WriteLine("InvalidChoice.Please try again:-(");
                                    break;
                                }
                            }

                        break;}
                    }
                }
            }else if(choice==3){
                Console.WriteLine("Do you need another transactions:[Y/N]: ");
                input=Console.ReadLine().ToUpper();
            }
            else{
                Console.WriteLine("InvalidId.Attempts left:5");
                continue;
            }
        }

    }
}