using MediatR;
using vertical_slicing_demo.Common.BaseHandlers;
using vertical_slicing_demo.Common.Data.Enum;
using vertical_slicing_demo.Common.Views;
using vertical_slicing_demo.Models.Entities;

namespace vertical_slicing_demo.Features.DepartmentManagement.AddDepartment.Command
{
    public record AddDepartmentCommand(string Name, string Description) : IRequest<RequestResult<bool>>;

    public class AddDepartmentCommandHandler : BaseRequestHandler<AddDepartmentCommand, RequestResult<bool>, Department>
    {
        public AddDepartmentCommandHandler(BaseRequestHandlerParameter<Department> parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<bool>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var DepartmentExists = _repository.GetAll().Where(d => d.Name.ToLower() == request.Name.ToLower());
                if (DepartmentExists is not null)
                {
                    return RequestResult<bool>.Failure(ErrorCode.AlreadyExists, "The Department already exists");
                }
                Department newDepartment = new Department
                {
                    Name = request.Name,
                    Description = request.Description,
                    IsDeleted = false
                };
                await _repository.AddAsync(newDepartment);
                await _repository.SaveChangesAsync();
                return RequestResult<bool>.Success(true, "Department added successfully.");

            }
            catch (Exception ex)
            {
                return RequestResult<bool>.Failure(ErrorCode.ServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
