using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public enum Status{Default, Borrowed, Returned}
    public class BorrowDetails
    {
        private static int s_borrowId=2000;
        public string BorrowID { get; }
        public string BookID { get; }
        public string UserID { get; }
        public DateTime BorrowDate { get; set; }
        public int BorrowBookCount { get; set; }
        public Status GetStatus { get; set; }
        public double PaidFineAmount { get; set; }

        public BorrowDetails(string bookId,string userID,DateTime borrowDate,int borrowBookCount,Status status,double paidFineAmount){
            s_borrowId++;
            BorrowID="LB"+s_borrowId;
            BookID=bookId;
            UserID=userID;
            BorrowDate=borrowDate;
            BorrowBookCount=borrowBookCount;
            GetStatus=status;
            PaidFineAmount=paidFineAmount;
        }

    }
}