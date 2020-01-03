using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pay_Roll_Managment_System.Dtos;
using Pay_Roll_Managment_System.Models;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public class PaymentRepository : IPaymentRepository
    {
        PayRollManagmentContext _PayRollManagmentContext;

        public PaymentRepository(PayRollManagmentContext PayRollManagmentContext)
        {
            _PayRollManagmentContext = PayRollManagmentContext;
        }
        public bool CreatePayment(Payment Payment)
        {
            _PayRollManagmentContext.Add(Payment);
            return Save();
        }

        public Payment GetPayment(int PaymentId)
        {
            return _PayRollManagmentContext.Payments.Where(a => a.Paymentid == PaymentId).FirstOrDefault();
        }

        public ICollection<PaymentDto> GetPayments()
        {
            int date = 3;
            if (DateTime.Today.Day == date)
            {
                var InnerJoinQuery = (from salary in _PayRollManagmentContext.Salaries
                                      join employee in _PayRollManagmentContext.Employees
                                      on salary.PoistionId equals employee.PoistionId
                                      join attendance in _PayRollManagmentContext.Attendances
                                      on employee.EmployeeId equals attendance.EmployeeId
                                      select new PaymentDto
                                      {
                                          EmployeeId = employee.EmployeeId,
                                          Payment = salary.BasicSalary + salary.Bonus + salary.Commission,
                                          WorkHour = Convert.ToInt32((attendance.outTime - attendance.inTime).TotalHours)
                                      }
                                      ).ToList();
                foreach (PaymentDto item in InnerJoinQuery)
                {
                    if (item.WorkHour > 8)
                    {                       
                        item.Payment = (item.WorkHour - 8) * 1000;
                    }
                    _PayRollManagmentContext.Payments.Add(new Payment {Date = DateTime.Now,AmountPaid = item.Payment,EmployeeId=item.EmployeeId});
                    Save();
                }
                
                return InnerJoinQuery;
            }
            else
            {
                // return _PayRollManagmentContext.Payments.OrderBy(a => a.Paymentid).ToList();
                return null;
            }

            
           // return _PayRollManagmentContext.Payments.OrderBy(a => a.Paymentid).ToList();
        }

        public bool PaymentExsists(int PaymentId)
        {
            return _PayRollManagmentContext.Payments.Any(a => a.Paymentid == PaymentId);
        }

        public bool Save()
        {
            var save = _PayRollManagmentContext.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdatePayment(Payment Payment)
        {
            _PayRollManagmentContext.Update(Payment);
            return Save();
        }

        public bool DeletePayment(Payment payment)
        {
            _PayRollManagmentContext.Payments.Remove(payment);
            return Save();
        }
    }
}
