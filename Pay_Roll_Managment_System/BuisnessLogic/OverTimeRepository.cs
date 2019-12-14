using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Dtos;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class OverTimeRepository : IOverTimeRepository
    {
        private PayRollManagmentContext _PayRollManagmentContext;
        public OverTimeRepository(PayRollManagmentContext payRollManagmentContext)
        {
            _PayRollManagmentContext = payRollManagmentContext;
        }
        public bool CreateOverTime(OverTime OverTime)
        {
            _PayRollManagmentContext.Add(OverTime);
            return Save();
        }

        public OverTimeDto GetOverTime(int OverTimeId)
        {
            var InnerJoinQuery = (from overtime in _PayRollManagmentContext.OverTimes
                                  join employee in _PayRollManagmentContext.Employees
                                  on overtime.EmployeeId equals employee.EmployeeId
                                  where overtime.OverTimeId == OverTimeId
                                  select new OverTimeDto
                                  {
                                      OverTimeId = overtime.OverTimeId,
                                      EmployeeId = overtime.EmployeeId,
                                      Amount = overtime.Amount,
                                      AdditionalHours = overtime.AdditionalHours,
                                      EmployeeFirstName = employee.FirstName,
                                      EmployeeLastName = employee.LastName
                                  }
                                  ).FirstOrDefault();
            return InnerJoinQuery;
        }

        public ICollection<OverTimeDto> GetOverTimes()
        {
            var InnerJoinQuery = (from overtime in _PayRollManagmentContext.OverTimes
                                  join employee in _PayRollManagmentContext.Employees
                                  on overtime.EmployeeId equals employee.EmployeeId
                                  select new OverTimeDto
                                  {
                                      OverTimeId = overtime.OverTimeId,
                                      EmployeeId = overtime.EmployeeId,
                                      Amount = overtime.Amount,
                                      AdditionalHours = overtime.AdditionalHours,
                                      EmployeeFirstName = employee.FirstName,
                                      EmployeeLastName = employee.LastName
                                  }
                                  ).ToList();
            return InnerJoinQuery;
        }

        public bool OverTimeExsist(int OverTimeId)
        {
            return _PayRollManagmentContext.OverTimes.Any(a => a.OverTimeId == OverTimeId);
        }

        public bool Save()
        {
            var saved = _PayRollManagmentContext.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateOverTime(OverTime OverTime)
        {
            _PayRollManagmentContext.Update(OverTime);
            return Save();
        }
    }
}
