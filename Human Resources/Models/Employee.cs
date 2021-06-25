using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources.Models
{
    class Employee
    {
        public string No;
        public static int Count { get; set; } = 1000;

        public string FullName;
        private string newemployename;
        private string newemployeesurname;
        private string newemployeeposition;
        private double newemployeesalary;

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Position { get; set; }

        public string DepartmentName { get; set; }

        public double Salary { get; set; }

        

        public Employee(string name, string surname, string position, double salary, string departmentname )
        {
            Name = name;
            SurName = surname;

            Position = position;
            Salary = salary;
            DepartmentName = departmentname;

            FullName = Name + " " + SurName;
            Count++;


            No = departmentname.ToString().Trim().ToUpper().Substring(0, 2) + Count.ToString(); //ilk 2 herfi gostermesi ucun !!!


            //FullName-i Name ve Surname bolmesini assign etmesi ucun verilmishdir!!!

        }

        public Employee(string newemployename, string newemployeesurname, string newemployeeposition, double newemployeesalary)
        {
            this.newemployename = newemployename;
            this.newemployeesurname = newemployeesurname;
            this.newemployeeposition = newemployeeposition;
            this.newemployeesalary = newemployeesalary;
        }

        public override string ToString()
        {
            return $"{No} {FullName} {Position} {Salary} {DepartmentName}";
        }

    }
}
