using vertical_slicing_demo.Common.Data.Enum;

namespace vertical_slicing_demo.Common.Views
{
    public record EndpointResponse<T>(T Data, bool IsSuccess, string message, ErrorCode ErrorCode)
    {
        public static EndpointResponse<T> Success(T data, string message = "")
        {
            return new EndpointResponse<T>(data, true, message, ErrorCode.None);
        }

        public static EndpointResponse<T> Failure(ErrorCode errorCode, string message = "")
        {
            return new EndpointResponse<T>(default, false, message, errorCode);
        }
    }
}
