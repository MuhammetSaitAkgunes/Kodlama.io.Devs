using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeletedTechnologyDto>
    {
        public int LanguageId { get; set; }
        public string TechnologyName { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology tech = await _technologyRepository.GetAsync(tech => tech.TechnologyName == request.TechnologyName);
                Technology deletedTech = await _technologyRepository.DeleteAsync(tech);

                DeletedTechnologyDto deletedTechnologyDto = _mapper.Map<DeletedTechnologyDto>(deletedTech);
                return deletedTechnologyDto;
            }
        }
    }
}
