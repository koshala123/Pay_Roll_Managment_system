using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Dtos
{
    public class OverTimeDto
    {
        public int OverTimeId { get; set; }
        public int AdditionalHours { get; set; }
        public int Amount { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int EmployeeId { get; set; }
    }
}
