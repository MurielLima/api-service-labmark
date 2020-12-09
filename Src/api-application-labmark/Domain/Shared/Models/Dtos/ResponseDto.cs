using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labmark.Domain.Shared.Models.Dtos
{
    public class ResponseDto
    {
        public string status { get; set; }
        public dynamic message { get; set; }
        public ResponseDto(string _status, dynamic _message)
        {
            status = _status;
            message = _message;
        }
    }
}
