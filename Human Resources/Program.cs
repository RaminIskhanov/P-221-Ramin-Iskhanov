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
            Console.WriteLine("Departmentin adini daxil edin");
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

                    Console.WriteLine("Duzgun SalaryLimit Daxil Edin");
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
            bool departmentNameLoop = true;
            bool workerLimitLoop = true;
            bool salaryLimitLoop = true;
            Console.WriteLine("Deyisdirmek istediyiniz Departmentin adin daxil edin.");
            while (oldloop)
            {
                try
                {
                    olddepartmentname = Console.ReadLine();
                    Department department1 = humanresourcemanager.departments.Find(x => x.Name == olddepartmentname);
                    
                    if (department1 != null)
                    {
                        Console.WriteLine($"{department1.Name} {department1.WorkerLimit} {department1.SalaryLimit}");
                        Console.WriteLine("Departmentin yeni adini daxil edin.");
                        while (departmentNameLoop)
                        {
                            try
                            {
                                newdepartmentname = Console.ReadLine();
                                if (string.IsNullOrEmpty(newdepartmentname) == false && newdepartmentname.Length >= 2)
                                {
                                    department1.Name = newdepartmentname;
                                    departmentNameLoop = false;
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
                        while (workerLimitLoop)
                        {
                            try
                            {
                                newworkerlimit = int.Parse(Console.ReadLine());
                                if (newworkerlimit >= 2)
                                {
                                    department1.WorkerLimit = newworkerlimit;
                                    workerLimitLoop = false;
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
                        while (salaryLimitLoop)
                        {
                            try
                            {
                                newsalarylimit = double.Parse(Console.ReadLine());
                                if (newsalarylimit >= 250)
                                {
                                    department1.SalaryLimit = newsalarylimit;
                                    salaryLimitLoop = false;
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
                    Console.WriteLine($"{employee.No}, {employee.FullName}, {employee.DepartmentName}, {employee.Salary}");
                }
            }
        }

        public static void ShowDepartmentEmployees(HumanResourcemanager humanResourcemanager)
        {
            Console.WriteLine("Isci siyahisi ucun departamentin adini yazin");
            string departmentname = Console.ReadLine();
            Department department = humanResourcemanager.departments.Find(s => s.Name == departmentname);
            try
            {
                foreach (Employee item in department.employees)
                {
                    Console.WriteLine($"{item.No},{item.Name},{item.SurName},{item.Position},{item.Salary}");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Departmentin adini duz yazin");
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
            bool departmentNameLoop = true;
            Console.WriteLine("Yeni iscinin veifesini daxil edin:");
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

                    Console.WriteLine("Duzgun yeni isci vezifesini daxil edin:");
                }
            }
            Console.WriteLine("yeni isci maasini daxil edin:");
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

            Console.WriteLine("Yeni iscinin department adini daxil edin");

            while (departmentNameLoop)
            {
                try
                {
                    newemployeedepartmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(newemployeedepartmentname) == false && newemployeedepartmentname.Length >= 2)
                    {
                        Department department = humanResourcemanager.departments.Find(x => x.Name == newemployeedepartmentname);
                        if (department != null)
                        {
                            Employee newemployee = new Employee(newemployename, newemployeesurname, newemployeeposition, newemployeesalary, department.Name);
                            department.employees.Add(newemployee);
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                    departmentNameLoop = false;
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun yeni iscinin department adini daxil edin.");
                }
            }
        }

        public static void EditEmployee (HumanResourcemanager humanResourcemanager)
        {
            bool noloop = true;
            string editno = "";
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
                    foreach (Department item in humanResourcemanager.departments)
                    {
                        Employee currentemployee = item.employees.Find(x => x.No == editno);
                        if (currentemployee != null)
                        {
                            Console.WriteLine($"{currentemployee.FullName},{currentemployee.Salary},{currentemployee.Position}");
                            Console.WriteLine("Iscinin yeni maasini daxil edin.");
                            while (newsalaryloop)
                            {
                                try
                                {
                                    newsalary = double.Parse(Console.ReadLine());
                                    if (newsalary >= 250)
                                    {
                                        currentemployee.Salary = newsalary;
                                        newsalaryloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine(" iscinin yeni maasini Duzgun daxil edin.");
                                }
                            }
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin.");
                            while (newpositionloop)
                            {
                                try
                                {
                                    newposition = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newposition) == false && newposition.Length >= 2)
                                    {
                                        currentemployee.Position = newposition;
                                        newpositionloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Iscinin yeni vezifesini Duzgun wdaxil edin.");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Duzgun Nomre daxil edin.");
                }
                noloop = false;
            }

        }

        public static void RemoveEmployee(HumanResourcemanager humanResourceManager)
        {
            string departmentname = "";
            string employeeno = "";
            bool nameloop = true;
            bool noloop = true;
            Console.WriteLine("Departmentin adin daxil edin:");
            while (nameloop)
            {
                try
                {
                    departmentname = Console.ReadLine();
                    if (string.IsNullOrEmpty(departmentname) == false && departmentname.Length >= 2)
                    {
                        Department removedepartment = humanResourceManager.departments.Find(x => x.Name == departmentname);
                        Console.WriteLine("Ishcinin nomresini yazin");
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







