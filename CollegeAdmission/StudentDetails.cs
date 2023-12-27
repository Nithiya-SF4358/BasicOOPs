using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender{Male,Female,Transgender}
    public class StudentDetails
    {
        private static int s_studentID=3000;
        public string StudentID { get; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender GetGender{get;set;}
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }
        public StudentDetails(string name,string fathername,DateTime dob,Gender gender,int physics,int chemistry,int maths){
            s_studentID++;
            StudentID="SF"+s_studentID;
            Name=name;
            FatherName=fathername;
            DOB=dob;
            GetGender=gender;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }
        public bool CheckEligibility(int average){
            if(average>=75){
                return true;
            }else{
                return false;
            } 

        }
    }
}