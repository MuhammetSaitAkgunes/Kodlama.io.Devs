using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdatedTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology t = await _technologyRepository.GetAsync(x => x.Id == request.Id);
                _technologyBusinessRules.TechnologyShouldExistsWhenRequested(t);
                t.TechnologyName = request.TechnologyName;
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(t);
                UpdatedTechnologyDto updatedTechnologyDto = _mapper.Map<UpdatedTechnologyDto>(updatedTechnology);
                return updatedTechnologyDto;
            }
        }
    }
}
