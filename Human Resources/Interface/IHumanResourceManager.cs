using Human_Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources.Interface
{
    interface IHumanResourceManager
    {
        List<Department> GetDepartments();


        List<Employee> GetEmployees(); // employee list

        void AddDepartment();
        void EditDepartaments();
        void AddEmployee();

        void EditEmployee();

        void GetDepartment();

        void RemoveEmployee();

        


    }
}
