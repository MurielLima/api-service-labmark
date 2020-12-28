using System;

namespace Labmark.Domain.Shared.Infrastructure.Exceptions
{
    public class AppError : Exception
    {
        public readonly dynamic _message;
        public readonly int _statusCode;
        public AppError(dynamic message, int statusCode = 400)
        {
            _message = message;
            _statusCode = statusCode;
        }
    }
}
