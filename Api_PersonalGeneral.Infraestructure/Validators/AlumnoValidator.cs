//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Api_PersonalGeneral.Domain.Interfaces;
using Api_PersonalGeneral.Domain.DTOS.requests;

namespace Api_PersonalGeneral.Infraestructure.Validators
{
    public class AlumnoValidator : AbstractValidator<AlumnoRequest>
    {
        // private readonly IalumnoInterface _Arepository;
        // public AlumnoValidator(IalumnoInterface Arepository)
        // {
        //     this._Arepository = Arepository;

        //     RuleFor(c => c.NombreCompleto).NotNull().NotEmpty().Length(5,40);
        //     RuleFor(c => c.Correo).NotNull().NotEmpty().EmailAddress().WithMessage("Correo electronico incorrecto. Hace falta '@'?");
        //     RuleFor(c => c.Clave).NotNull().NotEmpty();
        // }

        // public bool NotExistEmail(string correo) 
        // {
        //     return !_Arepository.Exist(p => p.Correo == correo);
        // }

    }
}