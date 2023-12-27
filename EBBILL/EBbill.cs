using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace oops3
{
    public class EBbill
    {
        private int eb_start=1000;
        public string MeterId{get; set;}
        public string UserName{get; set;}
        public long Phone{get;set;}
        public string MailId{get; set;}
        public double Units{get; set;}
        public EBbill(string name, long phoneno, string mailid,double unit){
        eb_start++;
        MeterId="EB"+eb_start;
        UserName=name;
        Phone=phoneno;
        MailId=mailid;
        Units=unit;
        }
        public void Details(){
            Console.WriteLine($"USERId: {MeterId}");
            Console.WriteLine($"USERName: {UserName}");
            Console.WriteLine($"USERPHONE: {Phone}");
            Console.WriteLine($"USERMAILID: {MailId}");
        }
    }
}
