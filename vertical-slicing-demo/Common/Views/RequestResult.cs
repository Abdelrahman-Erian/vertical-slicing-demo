using vertical_slicing_demo.Common.Data.Enum;

namespace vertical_slicing_demo.Common.Views
{
    public record RequestResult<T>(T data, bool IsSuccess, string message, ErrorCode errorCode)
    {

        public static RequestResult<T> Success(T data, string message = "")
        {
            return new RequestResult<T>(data, true, message, ErrorCode.None);
        }

        public static RequestResult<T> Failure(ErrorCode errorCode, string message = "")
        {
            return new RequestResult<T>(default, false, message, errorCode);
        }
    }
}
