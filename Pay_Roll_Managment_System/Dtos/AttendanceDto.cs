using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Dtos
{
    public class AttendanceDto
    {
        public string EmployeeId { get; set; }
        public DateTime inTime { get; set; }
        public DateTime outTime { get; set; }
        public string AttendanceId { get; set; }
    }
}
