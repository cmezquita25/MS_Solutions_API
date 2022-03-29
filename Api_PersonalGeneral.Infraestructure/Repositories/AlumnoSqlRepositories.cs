//cSpell:disable

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
    public class AlumnoSqlRepositories : IalumnoInterface
    {
        private readonly PersonalGeneralContext _Econtext;

        public AlumnoSqlRepositories(PersonalGeneralContext econtext)
        {
            _Econtext = econtext;
        }

        //Todos los Estudiantes
        public async Task<IQueryable<Estudiante>> TodosLosEstudiantes()
        {
            var Es = await _Econtext.Estudiantes.AsQueryable<Estudiante>().AsNoTracking().ToListAsync();

            return Es.AsQueryable();
        }
        public bool Exist(Expression<Func<Estudiante, bool>> expression)
        {
            return _Econtext.Estudiantes.Any(expression);
        }

        /*public async Task<Estudiante> Login(string correo, string clave)
        {
            var estudiante = await _Econtext.Estudiantes.FirstOrDefaultAsync(e => e.Correo == correo);
            
        }*/
        public async Task<int> RegistrarEstudiante(Estudiante estudiante)
        {
            var entity = estudiante;

            await _Econtext.Estudiantes.AddAsync(entity);

            var rows = await _Econtext.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo registrar su cuenta...Verifique su información.");
            
            return entity.IdEstudiante;
        }

        public void EliminarCuentaEstudiante(int id)
        {
            var student = _Econtext.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id); 

            var inscripcion = _Econtext.Inscripcions.AsQueryable().Where(i => i.IdEstudiante == id);


            
            if(inscripcion!=null)
            {
                _Econtext.Inscripcions.RemoveRange(inscripcion);

                if(student!=null)
                {
                    _Econtext.Estudiantes.Remove(student);

                    _Econtext.SaveChanges();
                }

            }
        }

        /*public bool existStudent(string correo, string clave)
        {
            return _Econtext.Estudiantes.FirstOrDefault(p => p.Correo == correo && p => p.Clave == clave);
        }
        */
        
    }
}