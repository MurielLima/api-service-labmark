using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Shared.Models.Dtos
{
    public class ResponseDto
    {
        public string statusCode { get; set; }
        public dynamic message { get; set; }
        public ResponseDto(string _statusCode, dynamic _message)
        {
            statusCode = _statusCode;
            message = _message;
        }
    }
}
