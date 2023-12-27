using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public enum Department{ECE, EEE, CSE}
    public enum Gender{Male,Female,Transgender}
    public class UserDetails
    {
        private static int s_userId=3000;
        public string UserID { get;}
        public string UserName { get; set;}
        public  Gender GetGender { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }
        public Department GetDepartment { get; set; }
        public UserDetails(string username,Gender gender,Department department,long mobileNumber,string mailid,double walletBalance){
            s_userId++;
            UserID="SF"+s_userId;
            UserName=username;
            GetGender=gender;
            GetDepartment=department;
            MobileNumber=mobileNumber;
            MailID=mailid;
            WalletBalance=walletBalance;
        }
        public double DeductBalance(double fineAmount){
            return WalletBalance-=fineAmount;
        }
        public double WalletRechargeFunction(double amount){
            return WalletBalance+=amount;
        }
    }
}