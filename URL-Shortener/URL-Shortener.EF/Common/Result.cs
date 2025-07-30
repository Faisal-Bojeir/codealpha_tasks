using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URL_Shortener.EF.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public int StatudCode { get; }
        public object? Data { get; }
        public Result(bool isSuccess, string message, int statudCode)
        {
            IsSuccess = isSuccess;
            Message = message;
            StatudCode = statudCode;
        }

        public Result(bool isSuccess, string message, int statudCode, object data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            StatudCode = statudCode;
        }
    }
}
