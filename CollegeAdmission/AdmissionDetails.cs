using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum AdmissionStatus{Booked,Admitted,Cancelled}
    public class AdmissionDetails
    {
        private static int s_admissionId=1000;
        public string AdmissionID { get; }
        public string StudentID { get;}
        public string DepartmentID { get; }
        public AdmissionStatus Status{get;set;}
        public DateTime AdmissionDate { get; set; }
        public AdmissionDetails(string studentID,string departmentId,DateTime dateofAdmission,AdmissionStatus status){
            s_admissionId++;
            AdmissionID="AID"+s_admissionId;
            StudentID=studentID;
            DepartmentID=departmentId;
            Status=status;
            AdmissionDate=dateofAdmission;
        }

    }
}