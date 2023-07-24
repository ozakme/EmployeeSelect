using AutoMapper;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;

namespace Service.Services
{
    public class DepartmentService : Service<Department>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IGenericRepository<Department> repository, IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<DepartmentWithEmployeeDto>> GetSingleDepartmentByIdWithEmployeesAsync(int departmentId)
        {
            var department = await _departmentRepository.GetSingleDepartmentByIdWithEmployeeAsync(departmentId);

            var departmentDto = _mapper.Map<DepartmentWithEmployeeDto>(department);
            return CustomResponseDto<DepartmentWithEmployeeDto>.Success(200, departmentDto);
        }

       
    }
}
