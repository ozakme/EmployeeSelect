using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWorks;

namespace Repository.Repositories{

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Department> GetSingleDepartmentByIdWithEmployeeAsync(int departmentId)
    {
        return await _context.Departments.Include(x => x.Employees).Where(x => x.Id == departmentId)
            .SingleOrDefaultAsync();
    }
}

}    