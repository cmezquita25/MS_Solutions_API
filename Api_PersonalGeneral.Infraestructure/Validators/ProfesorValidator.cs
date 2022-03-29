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
    public class ProfesorValidator : AbstractValidator<ProfesorRequest>
    {
        // private readonly IprofesorInterface _repository;
        // public ProfesorValidator(IprofesorInterface repository)
        // {
        //     this._repository = repository;

        //     RuleFor(c => c.NombreCompleto).NotNull().NotEmpty().Length(5,40);
        //     RuleFor(c => c.Correo).NotNull().NotEmpty().EmailAddress().WithMessage("Correo electronico incorrecto. Hace falta '@'?");
        //     RuleFor(c => c.Clave).NotNull().NotEmpty();
        //     RuleFor(c => c.RedesSociales).NotNull().NotEmpty().Length(1, 100);
        //     RuleFor(c => c.Descripcion).NotNull().NotEmpty().Length(1, 500);
        // }
        // public bool NotExistEmail(string correo) 
        // {
        //     return !_repository.Exist(p => p.Correo == correo);
        // }
    }
}