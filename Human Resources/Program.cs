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
                Console.WriteLine("Emeliyyat nomresini daxil edin:");
                Console.WriteLine("------------------------------------");
                Console.WriteLine("1.1 Departamentlerin siyahisini gostermek");
                Console.WriteLine("1.2 Departament yaratmaq");
                Console.WriteLine("1.3 Departamentde deyisiklik etmek");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermek");
                Console.WriteLine("2.3 Isci elave etmek");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 Departamentden isci silinmesi ");
                Console.WriteLine("---------------------------------------------");
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
                Console.WriteLine($"\n Department Name: {item.Name} \n Salary Limit:{item.SalaryLimit} \n Worker Limit:{item.WorkerLimit} \n Avarage Salary:{item.CalcSalaryAvarege()} \n Employees Count: {item.employees.Count}");
            }
            // '\n' istifade ederek kodun alt-alta seliqeli yazilishi temin edilmishdir..
        }

        public static void AddDepartment(HumanResourcemanager humanResourceManager)
        {
            bool nameloop = true;
            bool workerlimitLoop = true;
            bool salarylimitLoop = true;
            string departmentname = "";
            int departmentworkerlimit = 0;
            double departsalarylimit = 0;
            Console.WriteLine("Yeni departmentin adini daxil edin:");
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
                    Console.WriteLine("Yeniden cehd edin (Department adi minimum 2 herf olmalidir.)");
                }
            }
            Console.WriteLine("Departmentin WorkerLimitin daxil edin:");
            while (workerlimitLoop)
            {
                try
                {
                    departmentworkerlimit = int.Parse(Console.ReadLine());
                    if (departmentworkerlimit >= 1)
                    {
                        workerlimitLoop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Yeniden cehd edin (minimum 1 ishci daxil edilmelidir)");
                }
            }
            Console.WriteLine("Departmentin SalaryLimitin daxil edin:");
            while (salarylimitLoop)
            {
                try
                {
                    departsalarylimit = double.Parse(Console.ReadLine());
                    if (departsalarylimit >= 250)
                    {
                        salarylimitLoop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Yeniden cehd edin ( Minimum 250 daxil edilmelidir)");
                }
            }
            Department department = new Department(departmentname, departmentworkerlimit, departsalarylimit);
            humanResourceManager.departments.Add(department);
            //istifadeci terefinden verilen deyerlerin yeni yaratdigimiz departmentde assign etmek ucun 
        }
        public static void EditDepartment(HumanResourcemanager humanresourcemanager)
        {
            // Loop-lar istifadeci terefinden verilen deyerlerin yoxlanilmasi ucun qeyd edilmishdir!!!

            string olddepartmentname = "";
            string newdepartmentname = "";
            int newworkerlimit = 0;
            double newsalarylimit = 0;
            bool oldloop = true;
            bool departmentNameLoop = true;
            bool workerLimitLoop = true;
            bool salaryLimitLoop = true;
            Console.WriteLine("Redakte edilecek Departmentin adini daxil edin:");
            while (oldloop)
            {
                try
                {
                    olddepartmentname = Console.ReadLine();
                    Department department1 = humanresourcemanager.departments.Find(x => x.Name == olddepartmentname);
                    //istifadeci terefinden verilen department adin sistemde olub olmadigini yoxlayir 
                    
                    if (department1 != null)
                    {
                        Console.WriteLine($"\n Department adi:{department1.Name} \n Department WorkerLimit: {department1.WorkerLimit} \n Department SalaryLimit: {department1.SalaryLimit}");
                        Console.WriteLine("Departmentin yeni adini daxil edin:");
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

                                Console.WriteLine("Yeniden cehd edin (Duzgun yeni ad daxil edin)");
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

                                Console.WriteLine("Yeniden cehd edin (Duzgun yeni workerlimit daxil edin)");
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

                                Console.WriteLine("Yeniden cehd edin (Duzgun Yeni salarylimit daxil edin)");
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

                    Console.WriteLine("Yeniden cehd edin (Duzgun Departmentin adin daxil edin)");
                }

            }


        }

        public static void ShowEmployees(HumanResourcemanager humanResourcemanager)
        {
            foreach(Department item in humanResourcemanager.departments)
            {
                foreach(Employee employee in item.employees)
                {
                    Console.WriteLine($"\n Iscinin Nomresi: {employee.No} \n Iscinin ad soyadi: {employee.FullName} \n Islediyi departmentin adi: {employee.DepartmentName} \n Emek haqqi: {employee.Salary}");
                }
            }
        }

        public static void ShowDepartmentEmployees(HumanResourcemanager humanResourcemanager)
        {
            Console.WriteLine("Department adini daxil edin:");
            string departmentname = Console.ReadLine();
            Department department = humanResourcemanager.departments.Find(s => s.Name == departmentname);
            try
            {
                foreach (Employee item in department.employees)
                {
                    Console.WriteLine($"\n Iscinin nomresi: {item.No} \n Iscinin ad soyadi: {item.FullName} \n Iscinin vezifesi: {item.Position} \n Emek haqqi: {item.Salary}");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Departmentin adini duz yazin");
            }
        }

        public static void AddEMployee(HumanResourcemanager humanResourcemanager)   
        {
            Console.WriteLine("Yeni iscinin adini  daxil edin:");
            string newemployename = Console.ReadLine();
            Console.WriteLine("Yeni iscinin soyadini daxil edin:");
            string newemployeesurname = Console.ReadLine();
            
            string newemployeeposition = "";
            double newemployeesalary = 0;
            string newemployeedepartmentname = "";
            bool positionloop = true;
            bool salaryloop = true;
            bool departmentNameLoop = true;
            Console.WriteLine("Yeni iscinin vezifesini daxil edin:");
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

                    Console.WriteLine("Yeniden cehd edin (Vezife adi minimum 2 herfden ibaret olmalidir)");
                }
            }
            Console.WriteLine("Yeni isci ucun emek haqqi daxil edin:");
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

                    Console.WriteLine("Yeniden cehd edin (Minimum emek haqqi 250 daxil edilmelidir)");
                }
            }

            Console.WriteLine("Yeni iscinin department adini daxil edin:");

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
                    Console.WriteLine("Yeniden cehd edin (Department adi minimum 2 herfden ibaret olmalidir)");
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
            
            Console.WriteLine("Redakte edeceyiniz iscinin 'Nomresi'ni daxil edin");

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
                            Console.WriteLine($"\n Ischinin ad ve soyadi:{currentemployee.FullName} \n Ishcinin emek haqqisi:{currentemployee.Salary} \n  Ishcinin vezifesi: {currentemployee.Position}");
                            Console.WriteLine("Iscinin yeni maasini daxil edin:");
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
                                    Console.WriteLine("Yeniden cehd edin (minimum emek haqqi 250 daxil edilmelidir)");
                                }
                            }
                            Console.WriteLine("Iscinin yeni vezifesini daxil edin:");
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
                                    Console.WriteLine("Yeniden cehd edin (Vezife adi minimum 2 herfden ibaret olmalidir)");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Yeniden cehd edin (Duzgun nomreni daxil edin)");
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
                    Department removedepartment = humanResourceManager.departments.Find(x => x.Name == departmentname);
                    if (string.IsNullOrEmpty(departmentname) == false && departmentname.Length >= 2 && removedepartment!=null)
                    {
                       
                        Console.WriteLine("Ishcinin nomresini daxil edin:");
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
                                Console.WriteLine("Yeniden cehd edin (Duzgun nomre daxil edin)");
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
                    Console.WriteLine("Yeniden cehd edin (Department adin duzgun daxil edin)");
                }
            }

        }

    }


    }







