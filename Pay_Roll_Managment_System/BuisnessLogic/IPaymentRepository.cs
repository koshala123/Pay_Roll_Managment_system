using Pay_Roll_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.BuisnessLogic
{
    public interface IPaymentRepository
    {
        ICollection<Payment> GetPayments();
        Payment GetPayment(int PaymentId);
        bool PaymentExsists(int PaymentId);
        bool CreatePayment(Payment Payment);
        bool UpdatePayment(Payment Payment);
        bool Save();
    }
}
