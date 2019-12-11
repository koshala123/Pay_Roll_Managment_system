﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pay_Roll_Managment_System.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Paymentid { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double AmountPaid { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        public Payment()
        {
            Date = DateTime.Today;
        }

    }
}
