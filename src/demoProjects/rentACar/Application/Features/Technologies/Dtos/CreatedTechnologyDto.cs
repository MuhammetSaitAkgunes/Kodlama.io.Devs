using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class CreatedTechnologyDto
    {
        public int id { get; set; }
        public int languageId { get; set; }
        public string technologyName { get; set; }
    }
}
