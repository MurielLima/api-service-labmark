﻿using System.Threading.Tasks;
using Labmark.Domain.Modules.Client.Infrastructure.Models.Dtos;

namespace Labmark.Domain.Modules.Client.Services
{
    public interface ICreateClientService
    {
        Task<ClientDto> Execute(ClientDto clientDto);
    }
}
