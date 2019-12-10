using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
    }
}
