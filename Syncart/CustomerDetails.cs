using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syncart
{
    public class CustomerDetails
    {
        private static int s_CustomerID=1000;
        public string CustomerID { get;}
        public string Name { get; set; }
        public string City { get; set; }
        public long Mobile { get; set; }
        public double WalletBalance { get; set; }
        public string MailID{get;set;}
        public CustomerDetails(string name,string city,long mobile,double walletBalance,string mailid){
            s_CustomerID++;
            CustomerID="CID"+s_CustomerID;
            Name=name;
            City=city;
            Mobile=mobile;
            WalletBalance=walletBalance;
            MailID=mailid;
        }
    }
}