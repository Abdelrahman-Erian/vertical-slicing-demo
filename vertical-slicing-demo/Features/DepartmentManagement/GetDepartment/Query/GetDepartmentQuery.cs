using MediatR;
using vertical_slicing_demo.Common.BaseHandlers;
using vertical_slicing_demo.Common.Data.Enum;
using vertical_slicing_demo.Common.Views;
using vertical_slicing_demo.Models.Entities;
using vertical_slicing_demo.Features.DepartmentManagement.GetDepartment;

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
            var department = await _repository.GetByIDAsync(request.Id);
            if (department == null || department.IsDeleted)
            {
                return RequestResult<GetDepartmentResponseDTO>.Failure(ErrorCode.NotFound, "Department not found.");
            }
            var responseDto = new GetDepartmentResponseDTO
            (
                Name : department.Name,
                Description : department.Description
            );
            return RequestResult<GetDepartmentResponseDTO>.Success(responseDto, "The Department was successfully found");
        }
    }
}
