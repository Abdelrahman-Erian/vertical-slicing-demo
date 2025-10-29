using Microsoft.AspNetCore.Mvc;
using vertical_slicing_demo.Common.BaseEndpoints;
using vertical_slicing_demo.Common.Views;
using vertical_slicing_demo.Features.DepartmentManagement.GetDepartment.Query;

namespace vertical_slicing_demo.Features.DepartmentManagement.GetDepartment
{
    public class GetDepartmentEndPoint : BaseEndpoint<GetDepartmentRequestVM, GetDepartmentResponseDTO>
    {
        public GetDepartmentEndPoint(BaseEndpointParameters<GetDepartmentRequestVM> parameters) : base(parameters)
        {
        }

        [HttpGet]
        public async Task<EndpointResponse<GetDepartmentResponseDTO>> GetDepartment([FromQuery]GetDepartmentRequestVM request)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            var result = await _mediator.Send(new GetDepartmentQuery(request.Id));

            if (!result.IsSuccess)
            {
                return EndpointResponse<GetDepartmentResponseDTO>.Failure(result.errorCode, result.message);
            }

            return EndpointResponse<GetDepartmentResponseDTO>.Success(result.data, result.message);
        }
    }
}
