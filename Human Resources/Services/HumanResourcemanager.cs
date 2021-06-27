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
        public List<Department> departments { get; set; }

        public HumanResourcemanager()
        {
            departments = new List<Department>();
        }

        public void AddDepartment()
        {
            throw new NotImplementedException();
        }

        public void AddEmployee()
        {
            throw new NotImplementedException();
        }
       

        public void EditDepartaments()
        {
            throw new NotImplementedException();
        }

        public void EditEmployee()
        {
            throw new NotImplementedException();
        }

        public void GetDepartment()
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee()
        {
            throw new NotImplementedException();
        }

       
    }
}
