using Core.DTOs;
using Core.Models;

namespace Core.Services { 

public interface IDepartmentService:IService<Department>
{
    public Task<CustomResponseDto<DepartmentWithEmployeeDto>> GetSingleDepartmentByIdWithEmployeesAsync(int departmentId);
}}