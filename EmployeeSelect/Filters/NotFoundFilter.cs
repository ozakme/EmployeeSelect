using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSelect.Filters
{

    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntitiy = await _service.AnyAsync(x => x.Id == id);
            if (anyEntitiy)
            {
                await next.Invoke();
                return;
            }

            context.Result =
                new NotFoundObjectResult(
                    CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));


        }
    }
}