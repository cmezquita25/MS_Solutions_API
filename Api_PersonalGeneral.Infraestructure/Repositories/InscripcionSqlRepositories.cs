using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.Interfaces;
using Api_PersonalGeneral.Infraestructure.Data;

namespace Api_PersonalGeneral.Infraestructure.Repositories
{
    public class InscripcionSqlRepositories : IInscripcionesIntefaces
    {
        private readonly PersonalGeneralContext _Icontext;

        public InscripcionSqlRepositories(PersonalGeneralContext icontext)
        {
            _Icontext = icontext;
        }

        //Todos los Estudiantes
        public async Task<IQueryable<Inscripcion>> TodosLosInscritos()
        {
            var Is = await _Icontext.Inscripcions.AsQueryable<Inscripcion>().AsNoTracking().ToListAsync();

            return Is.AsQueryable();
        }
    }
}