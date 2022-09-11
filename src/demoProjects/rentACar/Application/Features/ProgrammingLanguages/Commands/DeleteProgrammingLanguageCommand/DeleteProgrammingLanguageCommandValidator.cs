using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand
{
    public class DeleteProgrammingLanguageCommandValidator:AbstractValidator<DeleteProgrammingLanguageCommand>
    {
        public DeleteProgrammingLanguageCommandValidator()
        {
            RuleFor(pl => pl.LanguageName).NotNull().NotEmpty().WithMessage("Language name cannot be null or empty.");
        }
    }
}
