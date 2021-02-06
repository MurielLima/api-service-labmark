using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Labmark.Domain.Modules.Exam.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Exam.Infrastructure.Mappers;
using Labmark.Domain.Modules.Exam.Infrastructure.Models.Dtos;
using Labmark.Domain.Modules.Exam.Repositories;
using Labmark.Domain.Modules.Exam.Services.CountMBLB;
using Labmark.Domain.Modules.Sample.Infrastructure.EFCore.Entities;
using Labmark.Domain.Modules.Sample.Repositories;
using Labmark.Domain.Shared.Infrastructure.Exceptions;

namespace Labmark.Domain.Modules.Exam.Infrastructure.Services.CountMBLB
{
    public class CreateCountMBLBService : ICreateCountMBLBService
    {
        private readonly IContagemMBLBRepository _contagemMBLBRepository;
        private readonly IAmostraRepository _amostraRepository;

        public CreateCountMBLBService(IContagemMBLBRepository contagemMBLBRepository, IAmostraRepository amostraRepository)
        {
            _contagemMBLBRepository = contagemMBLBRepository;
            _amostraRepository = amostraRepository;
        }

        public async Task<CountMBLBDto> Execute(CountMBLBDto countMBLBDto, int? sampleId)
        {
            if (sampleId <= 0 || sampleId == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }
           Amostra amostra = await _amostraRepository.GetByID((int)sampleId);
            if (amostra == null)
            {
                throw new AppError("Informe uma diluição válida.");
            }
            
            ContagemMBLB contagemMBLB = CountMBLBDtoMapToContagemMBLB.Map(new ContagemMBLB(), countMBLBDto);
            contagemMBLB.fkEnsaiosPorAmostra = amostra.EnsaiosPorAmostras.Where(x => x.fkEnsaio.Id == countMBLBDto.AssayId).First();
            contagemMBLB.fkEnsaiosPorAmostraId = amostra.EnsaiosPorAmostras.Where(x => x.fkEnsaio.Id == countMBLBDto.AssayId).First().Id;
       
            _contagemMBLBRepository.Insert(contagemMBLB);

            await _contagemMBLBRepository.Commit();
            return countMBLBDto;
        }
    }
}
