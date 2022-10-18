using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPISerilog.Models
{
    public partial class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        [Required]
        [StringLength(50)]
        public string LName { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
    }
}
