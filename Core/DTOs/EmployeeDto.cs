using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class EmployeeDto:BaseDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }

    }
}
