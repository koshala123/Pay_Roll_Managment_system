using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Models
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string description { get; set; }
    }
}
