using MediatR;
using Microsoft.EntityFrameworkCore;
using vertical_slicing_demo.Common.BaseHandlers;
using vertical_slicing_demo.Common.Data.Enum;
using vertical_slicing_demo.Common.Views;
using vertical_slicing_demo.Features.DepartmentManagement.GetDepartment;
using vertical_slicing_demo.Models.Entities;

namespace vertical_slicing_demo.Features.DepartmentManagement.GetDepartment.Query
{
    public record GetDepartmentQuery(Guid Id) : IRequest<RequestResult<GetDepartmentResponseDTO>>;

    public class GetDepartmentQueryHandler : BaseRequestHandler<GetDepartmentQuery, RequestResult<GetDepartmentResponseDTO>, Department>
    {
        public GetDepartmentQueryHandler(BaseRequestHandlerParameter<Department> parameters) : base(parameters)
        {
        }
        public override async Task<RequestResult<GetDepartmentResponseDTO>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetAll()
                .Where(d => d.ID == request.Id)
                .Select(d => new GetDepartmentResponseDTO(d.Name, d.Description))
                .FirstOrDefaultAsync();

            if (department is null)
            {
                return RequestResult<GetDepartmentResponseDTO>.Failure(ErrorCode.NotFound, "Department not found.");
            }

            return RequestResult<GetDepartmentResponseDTO>.Success(department, "The Department was successfully found");
        }
    }
}
