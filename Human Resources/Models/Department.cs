using Human_Resources.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources.Models
{
     class Department 
    {
        

        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public List<Employee> employees { get; set; } // Departamentde ishcilerin siyahisi...
        public object Employees { get; internal set; }

        public Department(string name, int workerlimit, double salarylimit)
        {
            Employees = new List<Employee>();
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }


        public double CalcSalaryAvarege() //Departmentdeki Iscilerin maas ortalamasinin hesablanmasi
        {
            double avarage = 0;
            double sum = 0;
            foreach (Employee item in employees)
            {
                sum += item.Salary;
            }
            if (employees.Count != 0)
            {
                avarage = sum / employees.Count;
                return avarage;
            }
            else
            {
                return 0; // departamentde iwci elave olunmadiqda console da Nan deyl 0 gostersin deye 
            }
            

        }


    }
}
