

namespace Core.DTOs{

public class EmployeeWithDepartmentDto:EmployeeDto
{
    public DepartmentDto Department { get; set; }
}}