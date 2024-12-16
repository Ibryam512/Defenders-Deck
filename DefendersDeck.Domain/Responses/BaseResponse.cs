using System.Net;

namespace DefendersDeck.Domain.Responses
{
    public class BaseResponse<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static BaseResponse<T> FailedValidation(string validationResult)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = HttpStatusCode.BadRequest,
                Message = validationResult
            };
        }

        public static BaseResponse<T> NotFound(string message)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = HttpStatusCode.NotFound,
                Message = message
            };
        }

        public static BaseResponse<T> Failed(string message)
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = HttpStatusCode.InternalServerError,
                Message = message
            };
        }

        public static BaseResponse<T> Unauthorized()
        {
            return new BaseResponse<T>
            {
                Success = false,
                StatusCode = HttpStatusCode.Unauthorized,
                Message = "The email/password is wrong"
            };
        }

        public static BaseResponse<T> Successful(T data, string message = "")
        {
            return new BaseResponse<T>
            {
                Data = data,
                Success = true,
                StatusCode = HttpStatusCode.OK,
                Message = message
            };
        }
    }
}
