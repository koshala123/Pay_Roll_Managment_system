using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Dtos
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime Birthdate { get; set; }
        public string ImgUrl { get; set; }
        public string PositionName { get; set; }

        public string PositionId { get; set; }
        public string StringEmployeeId { get; set; }

    }
}
