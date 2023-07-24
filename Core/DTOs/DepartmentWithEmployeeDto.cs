namespace Core.DTOs{

public class DepartmentWithEmployeeDto:DepartmentDto
{
    public List<EmployeeDto> Employee { get; set; }
}}