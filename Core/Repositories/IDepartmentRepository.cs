using Core.Models;

namespace Core.Repositories{

public interface IDepartmentRepository:IGenericRepository<Department>
{
    Task<Department> GetSingleDepartmentByIdWithEmployeeAsync(int DepartmentId);
}}