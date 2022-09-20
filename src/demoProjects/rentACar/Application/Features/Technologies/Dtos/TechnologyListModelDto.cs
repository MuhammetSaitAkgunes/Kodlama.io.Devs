using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class TechnologyListModelDto
    {
        public int Id { get; set; }
        public string TechnologyName { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
