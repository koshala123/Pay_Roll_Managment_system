using Pay_Roll_Managment_System.Dtos;
using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IEmployeeRepository
    {
        ICollection<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int EmployeeId);
        bool EmployeeExists(int EmployeeId);
        bool CreateEmployee(EmployeeDto employee);
        bool UpdateEmployee(EmployeeDto employee);
        bool DeleteEmployee(int EmployeeId);
        bool Save();
    }
}
