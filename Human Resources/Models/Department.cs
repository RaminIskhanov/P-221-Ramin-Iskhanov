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
            this.Name = name;
            this.WorkerLimit = workerlimit;
            this.SalaryLimit =salarylimit;
        }

      

        public double CalcSalaryAvarage(List<Employee> employees)
        {
            double avarage;
            double sum=0;
            foreach (Employee item in employees)
            {
                sum += item.Salary;
            }
            avarage = sum / employees.Count;
            return avarage;

            // Departamentdeki ishcilerin maash ortalamaasinin hesablanmasi !!!
        }

        public static implicit operator Department(HumanResourcemanager v)
        {
            throw new NotImplementedException();
        }
    }
}
