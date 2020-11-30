using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Labmark.Domain.Shared.Services
{
    public interface IService<T>
    {
        public Task<T> Execute(T any);
    }
}
