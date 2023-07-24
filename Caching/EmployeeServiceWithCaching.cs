using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWork;
using Service.Exceptions;

namespace Caching
{
    public class EmployeeServiceWithNoCaching : IEmployeeService
    {
        private const string CacheEmployeeKey = "employeesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmployeeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeServiceWithNoCaching(IMapper mapper, IMemoryCache memoryCache, IEmployeeRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memoryCache.TryGetValue(CacheEmployeeKey, out _))
            {
                _memoryCache.Set(CacheEmployeeKey, _repository.GetEmployeeWithDepartment().Result);
            }

        }

        public Task<Employee> GetByIdAsync(int id)
        {
            var employee = _memoryCache.Get<List<Employee>>(CacheEmployeeKey).FirstOrDefault(x => x.Id == id);

            if (employee == null)
                throw new NotFounException($"{typeof(Employee).Name}({id}) not found");
            return Task.FromResult(employee);
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Employee>>(CacheEmployeeKey));
        }

        public IQueryable<Employee> Where(Expression<Func<Employee, bool>> expression)
        {
            return _memoryCache.Get<List<Employee>>(CacheEmployeeKey).Where(expression.Compile()).AsQueryable();
        }

        public Task<bool> AnyAsync(Expression<Func<Employee, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> AddRangeAsync(IEnumerable<Employee> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllEmployeesAsync();
            return entities;
        }

        public async Task<Employee> AddAsync(Employee entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllEmployeesAsync();
            return entity;
        }

        public async Task UpdateAsync(Employee entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllEmployeesAsync();

        }

        public async Task RemoveAsync(Employee entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllEmployeesAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Employee> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllEmployeesAsync();
        }

        public Task<CustomResponseDto<List<EmployeeWithDepartmentDto>>> GetEmployeesWithDepartment()
        {
            var employees = _memoryCache.Get<IEnumerable<Employee>>(CacheEmployeeKey);
            var employeeWithDepartmentDto = _mapper.Map<List<EmployeeWithDepartmentDto>>(employees);
            return Task.FromResult(CustomResponseDto<List<EmployeeWithDepartmentDto>>.Success(200, employeeWithDepartmentDto));
        }

        public async Task CacheAllEmployeesAsync()
        {
            _memoryCache.Set(CacheEmployeeKey, await _repository.GetAll().ToListAsync());
        }
        
        
    }
}
