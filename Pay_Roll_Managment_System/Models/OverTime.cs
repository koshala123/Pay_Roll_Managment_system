using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Models
{
    public class OverTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OverTimeId { get; set; }
        public int AdditionalHours { get; set; }
        public int Amount { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
}
