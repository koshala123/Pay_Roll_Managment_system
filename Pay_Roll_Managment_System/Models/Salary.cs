﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Models
{
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Id auto-generated by the database
        public int SalaryId { get; set; }
        public string SalaryName { get; set; }
        public int BasicSalary { get; set; }
        public int Bonus { get; set; }
        public int Commission { get; set; }
        public int OverTime { get; set; }

         
        [ForeignKey("PoistionId")]
        public Position Position { get; set; }
        public int PoistionId { get; set; }
    }
}
