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
            var InnerJoinQuery = (from employee in _PayRollManagmentContext.Employees
                                  join attendance in _PayRollManagmentContext.Attendances
                                  on employee.EmployeeId equals attendance.EmployeeId
                                  where attendance.EmployeeId == OverTimeId
                                  select new OverTimeDto
                                  {
                                      OverTimeId = attendance.AttendanceId,
                                      EmployeeId = attendance.EmployeeId,
                                      
                                      WorkHour = Convert.ToInt32((attendance.outTime - attendance.inTime).TotalHours),
                                      EmployeeFirstName = employee.FirstName,
                                      EmployeeLastName = employee.LastName
                                  }
                                  ).FirstOrDefault();
            
            return InnerJoinQuery;
        }

        public ICollection<OverTimeDto> GetOverTimes()
        {
            var InnerJoinQuery = (from employee in _PayRollManagmentContext.Employees
                                  join attendance in _PayRollManagmentContext.Attendances
                                  on employee.EmployeeId equals attendance.EmployeeId
                                  select new OverTimeDto
                                  {
                                      OverTimeId = attendance.AttendanceId,
                                      EmployeeId = attendance.EmployeeId,
                                      
                                     WorkHour = Convert.ToInt32((attendance.outTime - attendance.inTime).TotalHours),
                                      EmployeeFirstName = employee.FirstName,
                                      EmployeeLastName = employee.LastName,
                                      

                                  }
                                  ).ToList();

            //Console.WriteLine(InnerJoinQuery);

            foreach(OverTimeDto OT in InnerJoinQuery)
            {
                if(OT.WorkHour > 8)
                {
                    int difference = OT.WorkHour - 8;
                    int payment = difference * 1000;
                    OT.Amount = payment;
                }
            }
            
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
