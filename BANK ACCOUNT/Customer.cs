using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oops1
{
     public enum Gender{
            Male,
            Female,
            Transgender
        }
    public class Customer
    {
        private int CustomerId=1000;
        public int customerGender{get;set;}
        public long customerPhone{get;set;}
        public string customerMailId{get;set;}
        public DateTime Dob{get;set;}
        public string cusid{get;}
        public string CustomerName{get; set;}
        public double Balance{get; set;}
       public Gender Gender{get;set;}
       public Customer(string name,long phone, string mailId, Gender gender,DateTime dob){
        CustomerId++;
        cusid="HDFC"+CustomerId;
        CustomerName=name;
        customerPhone=phone;
        customerMailId=mailId;
        Dob=dob;
        Gender=gender;
        Balance=0;
       }

        public void Deposit(double amount){
        Balance+=amount;
        Console.WriteLine($"Deposited{amount:C}.Current balance:{Balance:C}");
       }
       public void withdraw(double amount){
        if(amount>Balance){
            Console.WriteLine("Insufficient Funds!");
        }else{
            Balance-=amount;
            Console.WriteLine($"withdrawn {amount:C}.Current balance:{Balance:C}");
        }
       }
       public void checkBalance(){
           Console.WriteLine($"current balance: {Balance:C}");
       }
       
    }
}