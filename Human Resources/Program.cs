using Human_Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human_Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee("Ramin", "Iskhanov", "DishHekimi", 15000, "Hekim");
            
            Employee employee2 = new Employee("Pervin", "Iskhanov", "DishHekimi", 15000, "Hekim");
            Console.WriteLine(employee1.ToString());
            Console.WriteLine(employee2.ToString());

        }
    }
}
