using Microsoft.AspNetCore.Mvc;
using vertical_slicing_demo.Common.BaseEndpoints;
using vertical_slicing_demo.Common.Views;
using vertical_slicing_demo.Features.DepartmentManagement.AddDepartment.Command;

namespace vertical_slicing_demo.Features.DepartmentManagement.AddDepartment
{
    public class AddDepartmentEndPoint : BaseEndpoint<AddDepartmentRequestVM, bool>
    {
        public AddDepartmentEndPoint(BaseEndpointParameters<AddDepartmentRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndpointResponse<bool>> AddDepartment(AddDepartmentRequestVM Request)
        {
            var resultValidate = ValidateRequest(Request);
            if(!resultValidate.IsSuccess)
            {
                return resultValidate;
            }

            var result = await _mediator.Send(new AddDepartmentCommand(Request.Name, Request.Description));
            if (!result.IsSuccess)
            {
                return EndpointResponse<bool>.Failure(result.errorCode, result.message);
            }

            return EndpointResponse<bool>.Success(true, "Department added successfully.");

        }
    }
}
