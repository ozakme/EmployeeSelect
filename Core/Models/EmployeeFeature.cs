using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{ 
    public class EmployeeFeature
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? Feature { get; set; }
        public string? Feature1 { get; set; }
        public string? Feature2 { get; set; }
        public Employee Employee { get; set; }
    }
}
