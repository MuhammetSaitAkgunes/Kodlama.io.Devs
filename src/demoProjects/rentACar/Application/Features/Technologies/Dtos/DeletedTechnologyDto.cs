﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class DeletedTechnologyDto
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string TechnologyName { get; set; }
    }
}
