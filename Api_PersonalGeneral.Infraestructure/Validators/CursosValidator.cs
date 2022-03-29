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
    public class CursosValidator : AbstractValidator<CursoRequests>
    {
        // private readonly ImaestroInterface _repository;

        // public CursosValidator(ImaestroInterface repository)
        // {
        //     this._repository = repository;
        //     RuleFor(c => c.Titulo).NotNull().NotEmpty().Length(5,50);
        //     RuleFor(c => c.FechaInicio).NotNull().NotEmpty();
        //     RuleFor(c => c.FechaCierre).NotNull().NotEmpty();
        //     RuleFor(c => c.LinkReunion).NotNull().NotEmpty().Length(10, 500);
        //     RuleFor(c => c.Material).NotNull().NotEmpty().Length(2, 100);
        //     RuleFor(c => c.Descripcion).NotNull().NotEmpty().Length(10, 500);
        //     RuleFor(c => c.IdProfesor).NotNull().NotEmpty();
        //     RuleFor(c => c.Estatus).NotNull().NotEmpty().Length(6, 11);
        // }
        // public bool NotExistTitulo(string titulo) 
        // {
        //     return !_repository.Exist(p => p.Titulo == titulo);
        // }
    }
}