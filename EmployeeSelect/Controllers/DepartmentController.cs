using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSelect.Controllers
{
    public class DepartmentController : CustomBaseController
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("[action]/{departmentId}")]
        public async Task<IActionResult> GetSingleDepartmentByIdWithEmployees(int departmentId)
        {
            return CreateActionResult(await _departmentService.GetSingleDepartmentByIdWithEmployeesAsync(departmentId));
        }
    }
}
