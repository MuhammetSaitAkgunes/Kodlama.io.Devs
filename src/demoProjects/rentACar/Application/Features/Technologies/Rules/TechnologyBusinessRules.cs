using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyCannotBeDuplicatedWhenInserted(string technologyName)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.TechnologyName == technologyName);
            if (result.Items.Any()) throw new BusinessException("Technology already exists.");
        }

        public void TechnologyShouldExistsWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Technology does not exists.");
        }

        public async Task TechnologyCanNotBeDuplicatedWhenUpdated(string technologyName)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.TechnologyName == technologyName);
            if (result.Items.Any()) throw new BusinessException("Technology already exists.");
        }
    }
}
