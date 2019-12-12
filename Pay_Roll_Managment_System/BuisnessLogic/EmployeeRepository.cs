using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Dtos;
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

        public bool DeleteEmployee(int EmployeeId)
        {
            var employee = _PayRollManagmentContext.Employees.Where(a => a.EmployeeId == EmployeeId).FirstOrDefault();
            _PayRollManagmentContext.Remove(employee);
            //_PayRollManagmentContext.Remove(employee);
            return Save();
        }

        public bool EmployeeExists(int EmployeeId)
        {
            return _PayRollManagmentContext.Employees.Any(a => a.EmployeeId == EmployeeId);
        }

        public EmployeeDto GetEmployee(int EmployeeId)
        {
            var innerJoinQuery = (from employee in _PayRollManagmentContext.Employees
                                 join position in _PayRollManagmentContext.Positions
                                 on employee.PoistionId equals position.PositionId
                                 where employee.EmployeeId == EmployeeId
                                 select new EmployeeDto
                                 {
                                     EmployeeId = employee.EmployeeId,
                                     FirstName = employee.FirstName,
                                     LastName = employee.LastName,
                                     RegistrationNo = employee.RegistrationNo,
                                     Address = employee.Address,
                                     ContactInfo = employee.ContactInfo,
                                     CreatedOn = employee.CreatedOn,
                                     PositionName = position.Name

                                 }).FirstOrDefault();

            return innerJoinQuery;
            // return _PayRollManagmentContext.Employees.Where(a => a.EmployeeId == EmployeeId).FirstOrDefault();
        }

        public ICollection<EmployeeDto> GetEmployees()
        {
            var innerJoinQuery = (from employee in _PayRollManagmentContext.Employees
                                  join position in _PayRollManagmentContext.Positions
                                  on employee.PoistionId equals position.PositionId
                                  select new EmployeeDto
                                  {
                                      EmployeeId = employee.EmployeeId,
                                      FirstName = employee.FirstName,
                                      LastName = employee.LastName,
                                      RegistrationNo = employee.RegistrationNo,
                                      Address = employee.Address,
                                      ContactInfo = employee.ContactInfo,
                                      CreatedOn = employee.CreatedOn,
                                      PositionName = position.Name

                                  }).ToList();

            return innerJoinQuery;
                
            //return _PayRollManagmentContext.Employees.OrderBy(a => a.EmployeeId).ToList();
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
