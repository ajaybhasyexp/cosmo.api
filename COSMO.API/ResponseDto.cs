using COSMO.Models.Models;
using System;
namespace COSMO.API
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }

        public ResponseDto<T> HandleException(ResponseDto<T> response)
        {
            response.IsSuccess = false;
            response.Message = "Unexpected error occured";
            return response;
        }
    }
}