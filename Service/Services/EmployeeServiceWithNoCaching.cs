using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Service.Services
{
    public class EmployeeServiceWithNoCaching: Service<Employee>,IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeServiceWithNoCaching(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork, IEmployeeRepository employeeRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<EmployeeWithDepartmentDto>>> GetEmployeesWithDepartment()
        {
            var employees = await _employeeRepository.GetEmployeeWithDepartment();

            var employeesDto = _mapper.Map<List<EmployeeWithDepartmentDto>>(employees);
            return CustomResponseDto<List<EmployeeWithDepartmentDto>>.Success(200, employeesDto);
        }

    }
}
