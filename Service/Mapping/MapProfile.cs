using AutoMapper;
using Core.DTOs;
using Core.Models;

namespace Service.Mapping{

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<EmployeeFeature, EmployeeFeatureDto>().ReverseMap();
        CreateMap<EmployeeUpdateDto, Employee>();
        CreateMap<Employee, EmployeeWithDepartmentDto>();
        CreateMap<Department, DepartmentWithEmployeeDto>();

    }
}}