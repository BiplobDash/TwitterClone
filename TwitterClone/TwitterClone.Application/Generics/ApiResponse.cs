using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Generics
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T? data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
