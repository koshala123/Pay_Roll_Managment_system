using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IEmployeeRepository
    {
        ICollection<Employee> GetEmployees();
        Employee GetEmployee(int EmployeeId);
        bool EmployeeExists(int EmployeeId);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(Employee employee);
        bool Save();
    }
}
