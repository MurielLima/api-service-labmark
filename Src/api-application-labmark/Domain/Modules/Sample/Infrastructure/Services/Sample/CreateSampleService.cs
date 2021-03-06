﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Infrastructure.Mappers;
using Labmark.Domain.Modules.Sample.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Modules.Sample.Services.Sample;
using Labmark.Domain.Modules.Solicitation.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Solicitation.Repositories;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Sample.Infrastructure.Services.Sample
{
    public class CreateSampleService : ICreateSampleService
    {
        private readonly IAmostraRepository _amostraRepository;
        private readonly ISolicitacaoRepository _solicitacaoRepository;

        public CreateSampleService(IAmostraRepository amostraRepository, ISolicitacaoRepository solicitacaoRepository)
        {
            _amostraRepository = amostraRepository;
            _solicitacaoRepository = solicitacaoRepository;
        }

        public async Task<SampleDto> Execute(SampleDto sampleDto, int? solicitationId)
        {
            if(solicitationId <= 0)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            Solicitacao solicitacao = await _solicitacaoRepository.GetByID((int)solicitationId);
            if(solicitacao == null)
            {
                throw new AppError("Informe uma solicitação válida.");
            }
            if (sampleDto.CollectionDate > DateTime.Now)
            {
                throw new AppError("Data de coleta não pode ser uma data futura");
            }
            if (sampleDto.FabricationDate > DateTime.Now)
            {
                throw new AppError("Data de fabricação não pode ser uma data futura");
            }
            if (sampleDto.FabricationDate > sampleDto.ExpirationDate)
            {
                throw new AppError("Data de fabricação não pode ser maior que a data de validade");
            }
            if (sampleDto.FabricationDate > sampleDto.CollectionDate)
            {
                throw new AppError("Data de fabricação não pode ser maior que a data de coleta");
            }
            Amostra amostra = SampleDtoMapToAmostra.Map(new Amostra(), sampleDto);
            amostra.fkSolicitacao = solicitacao;
            amostra.fkSolicitacaoId = solicitacao.Id;
            _amostraRepository.Insert(amostra);
            await _amostraRepository.Commit();
            foreach (var x in sampleDto.Assays)
            {
                var ensaiosPorAmostra = new EnsaiosPorAmostra();
                ensaiosPorAmostra.fkAmostraId = amostra.Id;
                ensaiosPorAmostra.fkEnsaioId = (int)x.Id;
                amostra.EnsaiosPorAmostras.Add(ensaiosPorAmostra);
            }
            sampleDto.Id = amostra.Id;
            _amostraRepository.Save(amostra);
            await _amostraRepository.Commit();
            return sampleDto;
        }
    }
}
