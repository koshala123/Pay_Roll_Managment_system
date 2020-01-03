using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Dtos
{
    public class PaymentDto
    {
        public int OverTimeAmount { get; set; }
        public int EmployeeId { get; set; }
        public int Salary { get; set; }
        public int Deduction { get; set; }
        public int Payment { get; set; }
        public int WorkHour { get; set; } 
    }
}
