using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
        public int LanguageId { get; set; }
        public string TechnologyName { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {

        }
        public Technology(int id,int languageId,string technologyName):this()
        {
            Id = id;
            LanguageId = languageId;
            TechnologyName = technologyName;
        }
    }
}
