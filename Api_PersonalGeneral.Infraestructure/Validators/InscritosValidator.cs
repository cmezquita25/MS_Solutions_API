using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Api_PersonalGeneral.Domain.DTOS.requests;

namespace Api_PersonalGeneral.Infraestructure.Validators
{
    public class InscritosValidator : AbstractValidator<InscripcionRequest>
    {
        // public InscritosValidator()
        // {
        //     RuleFor(c => c.IdInscripcion).NotNull();
        //     RuleFor(c => c.IdEstudiante).NotNull().NotEmpty();
        //     RuleFor(c => c.IdCurso).NotNull().NotEmpty();
        // }
    }
}