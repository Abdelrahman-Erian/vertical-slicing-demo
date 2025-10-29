using MediatR;
using vertical_slicing_demo.Common.BaseHandlers;
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
    }
}
