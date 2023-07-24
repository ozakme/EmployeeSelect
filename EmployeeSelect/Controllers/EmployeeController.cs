using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Services;
using EmployeeSelect.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSelect.Controllers
{
    public class EmployeeController : CustomBaseController
    {
        private readonly IMapper _mapper;

        private readonly IEmployeeService _service;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService)
        {

            _mapper = mapper;
            _service = employeeService;
        }
        [HttpGet("GetEmployeesWithDepartment")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            return CreateActionResult(await _service.GetEmployeesWithDepartment());
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var employees = await _service.GetAllAsync();
            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees.ToList());

            return CreateActionResult(CustomResponseDto<List<EmployeeDto>>.Success(200, employeesDtos));
        }
        [ServiceFilter(typeof(NotFoundFilter<Employee>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            var employeesDto = _mapper.Map<EmployeeDto>(employee);

            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(200, employeesDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(EmployeeDto employeeDto)
        {
            var employee = await _service.AddAsync(_mapper.Map<Employee>(employeeDto));
            employeeDto = _mapper.Map<EmployeeDto>(employeeDto);

            return CreateActionResult(CustomResponseDto<EmployeeDto>.Success(201, employeeDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeDto)
        {
            await _service.UpdateAsync(_mapper.Map<Employee>(employeeDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(employee);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
