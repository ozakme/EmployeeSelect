using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using FluentValidation;

namespace Service.Validations
{
    public class EmployeeDtoValidator:AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.Age).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be graeter 0");

            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be graeter 0");

        }
    }
}
