using EFDBFirst.Data;
using EFDBFirst.Data.Models;

namespace EFDBFirstConsole
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Employee employee = new Employee {EmpId = 2, EmpName = "Yuvraj Singh", EmpAddress = "Gurgaon" };
            List<EmployeeEducation> Educationlist = new List<EmployeeEducation>();
            Educationlist.Add(new EmployeeEducation { EducationName = "BTECH" });
            CRUDoperations CRUDObj = new CRUDoperations();
            //CRUDObj.InsertEmployeeAndItsEducation(employee, Educationlist);
            //CRUDObj.DeleteEmployeeById(1);
            //CRUDObj.ShowAllEmployee();
            CRUDObj.UpdateEmployee(2, "Yuvraj Singh", "Haryana", new List<EmployeeEducation> { new EmployeeEducation { EducationName = "MTECH" } });
            //CRUDObj.UpdateEmpEdueById(1, "BSC");
            Console.ReadLine();



        }
    }
}