using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll
{
    public enum Branch{Eymard, Karuna, Madhura}
    public enum Team{Network, Hardware, Developer, Facility}
    public class EmployeeDetails
    {
        private static int s_EmployeeId=3000;
        public string EmployeeID { get;}
        public string FullName { get; set; }
        public DateTime DOB { get; set; }
        public long Mobile { get; set; }
        public string Gender { get; set; }
        public Branch branch { get; set; }
        public Team team{get;set;}
        public EmployeeDetails(string fullname,DateTime dob,long mobile,string gender,Branch branch1,Team team1){
            s_EmployeeId++;
            EmployeeID="SF"+s_EmployeeId;
            FullName=fullname;
            DOB=dob;
            Mobile=mobile;
            Gender=gender;
            branch=branch1;
            team=team1;
        }
    }
}