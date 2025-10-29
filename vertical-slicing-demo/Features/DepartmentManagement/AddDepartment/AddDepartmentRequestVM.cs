using Azure.Core;
using FluentValidation;

namespace vertical_slicing_demo.Features.DepartmentManagement.AddDepartment
{
    public record AddDepartmentRequestVM(string Name, string Description);

    public class AddDepartmentRequestVMValidator : AbstractValidator<AddDepartmentRequestVM>
    {
        public AddDepartmentRequestVMValidator()
        {
            RuleFor(Request => Request.Name)
                .NotEmpty().WithMessage("Department Name is required.")
                .MinimumLength(2).WithMessage("Department Name must not exceed 20 characters.")
                .MaximumLength(20).WithMessage("The department name must be at least 2 characters long.");

            RuleFor(Request => Request.Description)
                .NotEmpty().WithMessage("Department Description is required.")
                .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");
        }
    }
}
