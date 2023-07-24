using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Repository.UnitOfWorks;

namespace Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository

    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Employee>> GetEmployeeWithDepartment()
        {
            //eager loading
            return await _context.Employees.Include(x => x.Department).ToListAsync();
        }

    }
}
