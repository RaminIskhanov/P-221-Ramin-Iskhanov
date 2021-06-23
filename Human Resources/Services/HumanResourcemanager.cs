using Human_Resources.Interface;
using Human_Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources.Services
{
    class HumanResourcemanager : IHumanResourceManager
    {
        private Department _department;

       
        public List<Department> department { get ; set; }

        public HumanResourcemanager()
        {
            department = new List<Department>();
        }
        public void AddDepartment(string name, int workerlimit, int salarylimit)
        {
            department = new List<Department>();

            if (department.Any(n=> n.Name==name && n.WorkerLimit == workerlimit && n.SalaryLimit == salarylimit))
            {
                department.Add(_department);
            }
           
        }
        
        // Ashagidaki metodlarda Departament yaratmaq ucun lazim olan melumatlar eks olunmushdur
        public void AddEmployee(string fullname, string position, int salary, string departmentname)
        
        {
            throw new NotImplementedException();
        }

        public void EditDepartaments(string name, string newName)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee(string no, int salary, string position)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee(string no, string departmentname)
        {
            throw new NotImplementedException();
        }

       
    }
}
