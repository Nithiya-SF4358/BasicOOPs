using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll
{
    public class AttendanceDetails
    {
        private static int s_AttendanceId=1000;
        public string AttendanceID{get;}
        public string EmployeeID{get;}
        public DateTime Date { get; set; }
        public TimeOnly CheckIn { get; set; }
        public TimeOnly CheckOut { get; set; }
        public double Hours{get;set;}
        public AttendanceDetails(string employeeId,DateTime date,TimeOnly checkIn,TimeOnly checkOut,double hours){
            s_AttendanceId++;
            AttendanceID="AID"+s_AttendanceId;
            EmployeeID=employeeId;
            Date=date;
            CheckIn=checkIn;
            CheckOut=checkOut;
            Hours=hours;
        }
    }
}