using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Human_Resources.Models;
using Human_Resources.Services;


namespace Human_Resources
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourcemanager humanResourceManager = new HumanResourcemanager();
            do
            {
                Console.WriteLine("Etmek Isdediyniz Emelliyyati Secin");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1.1 Departamentlerin siyahisini gostermek");
                Console.WriteLine("1.2 Departamenet yaratmaq");
                Console.WriteLine("1.3 Departamentde deyisiklik etmek");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 Isci elave etmek");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 Departamentden isci silinmesi ");
                string answer = Console.ReadLine();

                switch (answer)
                {
                    case "1.1":
                        GetDepartment(humanResourceManager);
                        break;
                    case "1.2":
                        AddDepartment(humanResourceManager);
                        break;
                    case "1.3":
                        EditDepartment(humanResourceManager);
                        break;
                    case "2.1":
                        ShowEmployees(humanResourceManager);
                        break;
                    case "2.2":
                        ShowDepartmentEmployees(humanResourceManager);
                        break;
                    case "2.3":
                        AddEMployee(humanResourceManager);
                        break;
                    case "2.4":
                        EditEmployee(humanResourceManager);
                        break;
                    case "2.5":
                        RemoveEmployee(humanResourceManager);
                        break;
                    default:
                        break;
                }

            } while (true);


        }
        public static void GetDepartment(HumanResourcemanager humanResourceManager)
        {

            foreach (Department item in humanResourceManager.departments)
            {
                Console.WriteLine($"Department name: {item.Name}, Salary limit:{item.SalaryLimit}, Worker limit:{item.WorkerLimit},Avarage Salary:{item.CalcSalaryAvarege()}, Employees Count: {item.employees.Count}");
            }
        }

        public static void AddDepartment(HumanResourcemanager humanResourceManager)
        {
            bool nameloop = true;
            bool workerlimitloop = true;
            bool salarylimitloop = true;
            string departmentname = "";
            int departmentworkerlimit = 0;
            double departmentsalarylimit = 0;
            Console.WriteLine("Departmentin adin daxil edin");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname) == false && departmentname.Length >= 2)
                    {
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun ad daxil et");
                }
            }
            Console.WriteLine("Departmentin Workerlimitin daxil edin");
            while (workerlimitloop)
            {
                try
                {
                    departmentworkerlimit = int.Parse(Console.ReadLine());
                    if (departmentworkerlimit >= 1)
                    {
                        workerlimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun WorkerLimit daxil edin");
                }
            }
            Console.WriteLine("Departmentin Salarylimitin daxil edin");
            while (salarylimitloop)
            {
                try
                {
                    departmentsalarylimit = double.Parse(Console.ReadLine());
                    if (departmentsalarylimit >= 250)
                    {
                        salarylimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun SalaryLimit daxil edin");
                }
            }
            Department department = new Department(departmentname, departmentworkerlimit, departmentsalarylimit);
            humanResourceManager.departments.Add(department);

        }
        public static void EditDepartment(HumanResourcemanager humanresourcemanager)
        {

            string olddepartmentname = "";
            string newdepartmentname = "";
            int newworkerlimit = 0;
            double newsalarylimit = 0;
            bool oldloop = true;
            bool loop1 = true;
            bool loop2 = true;
            bool loop3 = true;
            Console.WriteLine("Deyisdirmek istediyiniz Departmentin adin daxil edin.");
            while (oldloop)
            {
                try
                {
                    olddepartmentname = Console.ReadLine();
                    Department department123 = humanresourcemanager.departments.Find(x => x.Name == olddepartmentname);
                    //bunu yoxla error ola biler!!!
                    if (department123 != null)
                    {
                        Console.WriteLine($"{department123.Name} {department123.WorkerLimit} {department123.SalaryLimit}");
                        Console.WriteLine("Departmentin yeni adin daxil edin.");
                        while (loop1)
                        {
                            try
                            {
                                newdepartmentname = Console.ReadLine();
                                if (string.IsNullOrEmpty(newdepartmentname) == false && newdepartmentname.Length >= 2)
                                {
                                    department123.Name = newdepartmentname;
                                    loop1 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni ad daxil edin.");
                            }

                        }
                        Console.WriteLine("Departmentin yeni workerlimitin daxil edin.");
                        while (loop2)
                        {
                            try
                            {
                                newworkerlimit = int.Parse(Console.ReadLine());
                                if (newworkerlimit >= 2)
                                {
                                    department123.WorkerLimit = newworkerlimit;
                                    loop2 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun yeni workerlimit daxil edin.");
                            }
                        }
                        Console.WriteLine("Yeni SalaryLimit daxil edin.");
                        while (loop3)
                        {
                            try
                            {
                                newsalarylimit = double.Parse(Console.ReadLine());
                                if (newsalarylimit >= 250)
                                {
                                    department123.SalaryLimit = newsalarylimit;
                                    loop3 = false;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("Duzgun Yeni salarylimit daxil edin.");
                            }
                        }
                        oldloop = false;

                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Departmentin adin daxil edin.");
                }

            }


        }

        public static void ShowEmployees(HumanResourcemanager humanResourcemanager)
        {
            foreach(Department item in humanResourcemanager.departments)
            {
                foreach(Employee employee in item.employees)
                {
                    Console.WriteLine(employee.No, employee.FullName, employee.DepartmentName, employee.Salary);
                }
            }
        }

        public static void ShowDepartmentEmployees(HumanResourcemanager humanResourcemanager)
        {
            Console.WriteLine("Isci siyahisi ucun departamentin adini yazin");
            string departmentname = Console.ReadLine();
            Department department = humanResourcemanager.departments.Find(s => s.Name == departmentname);
            foreach(Employee item in department.employees)
            {
                Console.WriteLine(item.No, item.Name, item.Position, item.Salary);
            }
        }

        public static void AddEMployee(HumanResourcemanager humanResourcemanager)
        {
            Console.WriteLine("yeni iscinin adini  elave edin");
            string newemployename = Console.ReadLine();
            Console.WriteLine("Yeni iscinin soyadini daxil edin");
            string newemployeesurname = Console.ReadLine();
            
            string newemployeeposition = "";
            double newemployeesalary = 0;
            string newemployeedepartmentname = "";
            bool positionloop = true;
            bool salaryloop = true;
            bool departmentloop = true;
            bool nameloop = true;
            Console.WriteLine("Yeni iscinin veifesini daxil edin");
            while (positionloop)
            {
                try
                {
                    newemployeeposition = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeeposition)==false && newemployeeposition.Length>=2)
                    {
                        positionloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun yeni isci vezifesini daxil edin.");
                }
            }
            Console.WriteLine("yeni isci maasini daxil edin");
            while (salaryloop)
            {
                try
                {
                    newemployeesalary = double.Parse(Console.ReadLine());
                    if (newemployeesalary>=250)
                    {
                        salaryloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun yeni maasi yazin");
                }
            }

            Console.WriteLine("Duzgun yeni iscinin department adini daxil edin");
            while (departmentloop)
            {
                try
                {
                    newemployeedepartmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeedepartmentname)== false && newemployeedepartmentname.Length>=2)
                    {
                        Department newemployedepartment = humanResourcemanager.departments.Find(n => n.Name == newemployeedepartmentname);
                        departmentloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun yeni department adini daxil edin");
                }
            }

            Department department = humanResourcemanager.departments.Find(n => n.Name == newemployename);
            Employee newemployee = new Employee(newemployename, newemployeesurname, newemployeeposition, newemployeesalary, newemployeedepartmentname);
            department.employees.Add(newemployee);

        }

        public static void EditEmployee (HumanResourcemanager humanResourcemanager)
        {
            bool noloop = true;
            string editno = "";
            bool editsalary = true;
            bool newsalaryloop = true;
            bool newpositionloop = true;
            double newsalary = 0;
            string newposition = "";
            
            Console.WriteLine("Deyismek isteidyini iscinin No-un yazin");

            while (noloop)
            {
                try
                {
                    editno = Console.ReadLine();
                    foreach (var item in humanResourcemanager.departments)
                    {
                        Employee currenemployee = item.employees.Find(s => s.No == editno);
                        if (currenemployee!=null)
                        {
                            Console.WriteLine($"{currenemployee.FullName} {currenemployee.Salary} {currenemployee.Position}");
                            Console.WriteLine("Iscinin yeni maasini daxil edin");
                            while (editsalary)
                            {
                                try
                                {
                                    newsalary = double.Parse(Console.ReadLine());
                                    if (newsalary>=250)
                                    {
                                        currenemployee.Salary = newsalary;
                                        newsalaryloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("Duzgun iscinin maasini daxil edin");
                                }
                            }

                            Console.WriteLine("iscinin yeni vezifesini daxil edin");
                            while (newpositionloop)
                            {
                                try
                                {
                                    newposition = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newposition)== false && newposition.Length>=2)
                                    {
                                        currenemployee.Position = newposition;
                                        newpositionloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {

                                    Console.WriteLine("iscinin duzgun vezifesini daxil edin");
                                }
                            }
                        }
                        else
                        {
                            noloop = false;
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("ishcinin duzgun No=ni daxil edin");
                }

            }
           
        }

        public static void RemoveEmployee(HumanResourcemanager humanResourceManager)
        {
            string departmentname = "";
            string employeeno = "";
            bool nameloop = true;
            bool noloop = true;
            Console.WriteLine("departmentin adin daxil edin");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname) == false && departmentname.Length >= 2)
                    {
                        Department removedepartment = humanResourceManager.departments.Find(x => x.Name == departmentname);
                        while (noloop)
                        {
                            try
                            {
                                employeeno = Console.ReadLine();
                                foreach (Department item in humanResourceManager.departments)
                                {
                                    Employee removeemploye = item.employees.Find(x => x.No == employeeno);
                                    if (removeemploye != null)
                                    {
                                        removedepartment.employees.Remove(removeemploye);
                                        noloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Duzgun nomre daxil edin.");
                            }
                        }
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Department adin duzgun daxil edin.");
                }
            }

        }

    }


    }







