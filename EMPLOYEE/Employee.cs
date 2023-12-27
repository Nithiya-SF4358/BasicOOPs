using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace oops2
{
    public enum WorkLocation{
        Office,
        Remote,
        OnSite
    }
    public enum Gender{
        Male,
        Female
    }
    public class Employee
    {
        private static int S_start=1000;
        public string EmployeeId{get;}
        public string EmployeeName{get;set;}
        public string Role{get;set;}
        public WorkLocation WorkLocation{ get; set;}
        public string Team{get;set;}
        public DateTime DateOfJoin{get;set;}
        public int Days{get;set;}
        public int Leave{get;set;}
        public Gender Gender{get;set;}
        //const
        public Employee(string name,string role,WorkLocation location,string team,DateTime joiningDate,int days,int leave,Gender gender){
            S_start++;

            EmployeeId="SF"+S_start;
            EmployeeName=name;
            Role=role;
            WorkLocation=location;
            Team=team;
            DateOfJoin=joiningDate;
            Days=days;
            Leave=leave;
            Gender=gender;

        }
        public double Salary(int days){
            return days*500;
        }
        public void DisplayDetails(){
            Console.WriteLine($"EmployeeId: {EmployeeId}");
            Console.WriteLine($"EmployeeName: {EmployeeName}");
            Console.WriteLine($"Role: {Role}");
            Console.WriteLine($"WorkLocation: {WorkLocation}");
            Console.WriteLine($"TeamName: {Team}");
            Console.WriteLine($"DateOfJoining: {DateOfJoin}");
            Console.WriteLine($"LeavesTaken: {Leave}");
            Console.WriteLine($"Gender: {Gender}");

        }
    }
}