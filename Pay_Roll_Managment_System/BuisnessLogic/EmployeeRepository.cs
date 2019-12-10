using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private PayRollManagmentContext _PayRollManagmentContext;
        public EmployeeRepository(PayRollManagmentContext PayRollManagmentContext)
        {
            _PayRollManagmentContext = PayRollManagmentContext;
        }
        public bool CreateEmployee(Employee employee)
        {
            _PayRollManagmentContext.Add(employee);
            return Save();
        }

        public bool DeleteEmployee(Employee employee)
        {
            _PayRollManagmentContext.Remove(employee);
            return Save();
        }

        public bool EmployeeExists(int EmployeeId)
        {
            return _PayRollManagmentContext.Employees.Any(a => a.EmployeeId == EmployeeId);
        }

        public Employee GetEmployee(int EmployeeId)
        {
            return _PayRollManagmentContext.Employees.Where(a => a.EmployeeId == EmployeeId).FirstOrDefault();
        }

        public ICollection<Employee> GetEmployees()
        {
            return _PayRollManagmentContext.Employees.OrderBy(a => a.EmployeeId).ToList();
        }

        public bool Save()
        {
            var saved = _PayRollManagmentContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _PayRollManagmentContext.Update(employee);
            return Save();
        }
    }
}
