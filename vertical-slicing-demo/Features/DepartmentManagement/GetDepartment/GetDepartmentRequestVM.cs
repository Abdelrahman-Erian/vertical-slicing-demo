using FluentValidation;
using MediatR;
using vertical_slicing_demo.Common.Views;

namespace vertical_slicing_demo.Features.DepartmentManagement.GetDepartment
{
    public record GetDepartmentRequestVM(Guid Id);

    public class GetDepartmentRequestVMValidator : AbstractValidator<GetDepartmentRequestVM>
    {
        public GetDepartmentRequestVMValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Department Id is required.");
        }
    }
}
