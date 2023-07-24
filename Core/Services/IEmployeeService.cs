using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IEmployeeService:IService<Employee>
    {
        Task<CustomResponseDto<List<EmployeeWithDepartmentDto>>> GetEmployeesWithDepartment();
    }
}
