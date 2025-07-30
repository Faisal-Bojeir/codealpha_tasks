using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Registration_System.Application.Common
{
    public class ApiResponse
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public int StatudCode { get; }
        public object? Data { get; }
        public Dictionary<string, List<string>>? Errors { get; }

        private ApiResponse(bool isSuccess, string message, int statudCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatudCode = statudCode;
        }

        private ApiResponse(bool isSuccess, string message, int statudCode, object? data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            StatudCode = statudCode;
        }

        private ApiResponse(bool isSuccess, string message, int statudCode, Dictionary<string, List<string>> errors)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatudCode = statudCode;
            Errors = errors;
        }

        public static ApiResponse Fail(string message)
        {
            return new ApiResponse(false, message, 400);
        }
        public static ApiResponse Confilct(string message)
        {
            return new ApiResponse(false, message, 409);
        }

        public static ApiResponse Unauthorized(string message)
        {
            return new ApiResponse(false, message, 401);
        }

        public static ApiResponse Create(string message = "Resource created successfully.")
        {
            return new ApiResponse(true, message, 201);
        }

        public static ApiResponse Success(object? data, string message = "Request completed successfully.")
        {
            return new ApiResponse(true, message, 200, data);
        }
    }

}
