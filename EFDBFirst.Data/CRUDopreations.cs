using EFDBFirst.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDBFirst.Data
{
    public class CRUDoperations
    {
        DBFirstContext DbFirst;
        public CRUDoperations()
        {
            DbFirst = new DBFirstContext();
        }

        public void InsertEmployeeAndItsEducation(Employee employee, List<EmployeeEducation> EduList)
        {
            var addemp = new Employee
            {
                EmpId = employee.EmpId,
                EmpName = employee.EmpName,
                EmpAddress = employee.EmpAddress,
                EmployeeEducations = EduList
            };
            DbFirst.Employees.Add(addemp);
            DbFirst.SaveChanges();
            Console.WriteLine("Employee Successfully Added...");
        }
        public void DeleteEmployeeById(int Id)
        {
            var employee = DbFirst.Employees.Where(emp => emp.EmpId == Id).Include(edu => edu.EmployeeEducations).FirstOrDefault();
            if (employee != null)
            {
                employee.EmployeeEducations.Clear();
                DbFirst.Employees.Remove(employee);
                DbFirst.SaveChanges();
            }
            else
            {
                Console.WriteLine("record not found...");
            }
        }

        public void UpdateEmpEdueById(int Id, string eduName,int Empid)
        {
            var edu = DbFirst.EmployeeEducations.Where(emp => emp.EduId == Id).AsNoTracking().FirstOrDefault();
            if (edu != null)
            {
                edu.EducationName = eduName;
                edu.EmpId = Empid;
                DbFirst.EmployeeEducations.Remove(edu);
                DbFirst.SaveChanges();
            }
            else
            {
                Console.WriteLine("record not found...");
            }
        }
        public void UpdateEmployee(int id, string empname, string empaddress, List<EmployeeEducation> updateEducation)
        {
            var updateemp = DbFirst.Employees.Where(emp => emp.EmpId == id).Include(e => e.EmployeeEducations).AsNoTracking().FirstOrDefault();
            if (updateemp != null)
            {
                updateemp.EmpName = empname;
                updateemp.EmpAddress = empaddress;
                updateemp.EmployeeEducations = updateEducation;
                DbFirst.Employees.Update(updateemp);
                DbFirst.SaveChanges();
                Console.WriteLine("Updated...");
            }
            else
            {
                Console.WriteLine("No Record Available For The ID " + id);
            }
        }
        public void ShowAllEmployee()
        {
            var getAllEmp = DbFirst.Employees.Include(e => e.EmployeeEducations).ToList();
            if (getAllEmp != null)
            {
                foreach (var emp in getAllEmp)
                {
                    Console.WriteLine("Employee Name :" + emp.EmpName);
                    Console.WriteLine("Employee Address : " + emp.EmpAddress);
                    Console.WriteLine();
                    Console.WriteLine("Employee Education :");
                    foreach (var edu in emp.EmployeeEducations)
                    {
                        Console.WriteLine("     Employee Educations :" + edu.EducationName);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------");
                }

            }
            else
            {
                Console.WriteLine("No Record Found...");
            }
        }
    }
}