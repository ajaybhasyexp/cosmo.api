using COSMO.API.Resources;
using COSMO.Models.Models;
using System;
namespace COSMO.API
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; }

        private ICommonResource _commonResource { get; set; }

        public ResponseDto(ICommonResource commonResource)
        {
            _commonResource = commonResource;
        }

        public ResponseDto<T> HandleException(ResponseDto<T> response)
        {
            response.IsSuccess = false;
            response.Message = _commonResource.UnExpectedError;
            return response;
        }
    }
}