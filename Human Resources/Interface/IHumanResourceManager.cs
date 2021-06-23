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
        List<Department> department { get; set; }

        

        void AddDepartment(string name, int workerlimit, int salarylimit);
        void EditDepartaments(string name, string newName);
        List<Department> GetDepartments();
        void AddEmployee(string fullname, string position, int salary, string departmentname);

        void EditEmployee(string no, int salary, string position);

        void RemoveEmployee(string no, string departmentname);

        


    }
}
