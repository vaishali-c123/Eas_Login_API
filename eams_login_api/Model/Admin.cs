using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; }

        public string AdminUsername { get; set; }

        public string AdminPassword { get; set; }
    }
}
