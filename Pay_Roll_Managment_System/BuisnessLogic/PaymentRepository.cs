using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ICollection<Payment> GetPayments()
        {
            return _PayRollManagmentContext.Payments.OrderBy(a => a.Paymentid).ToList();
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
