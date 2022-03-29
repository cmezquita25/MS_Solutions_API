//cSpell: disable

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
    public class MaestroSqlRepositories : ImaestroInterface
    {
        private readonly PersonalGeneralContext _Mcontext;

        public MaestroSqlRepositories(PersonalGeneralContext mcontext)
        {
            _Mcontext = mcontext;
        }

        //*El profesor podra consultar todos los cursos registrados en la plataforma
        public async Task<IQueryable<Curso>> TodosLosCursos()
        {
            var Mcurso = await _Mcontext.Cursos.AsQueryable<Curso>().AsNoTracking().ToListAsync();

            return Mcurso.AsQueryable();
        }

        public bool Exist(Expression<Func<Curso, bool>> expression)
        {
            return _Mcontext.Cursos.Any(expression);
        }

        //*El profesor podra registrar cursos
        public async Task<int> RegistrarCurso(Curso curso)
        {
            var entity = curso;

            await _Mcontext.Cursos.AddAsync(entity);

            var rows = await _Mcontext.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo registrar el curso...Verifique su información.");
            
            return entity.IdCurso;
        }

        //*Buscar curso por Id
        public async Task<Curso> CursoPorId(int id)
        {
            var Mcurso = await _Mcontext.Cursos.FirstOrDefaultAsync(c => c.IdCurso == id);
            return Mcurso;
        }

        //*El profesor podra modificar cursos
        
        public async Task<bool> Update(int id, Curso curso)
        {
            if(id <= 0 || curso == null)
                throw new ArgumentException("Falta informacion para poder actualizar el curso");

            var entity = await CursoPorId(id);

            entity.Titulo = curso.Titulo;
            entity.FechaInicio = curso.FechaInicio;
            entity.FechaCierre = curso.FechaCierre;
            entity.LinkReunion = curso.LinkReunion;
            entity.Material = curso.Material;
            entity.Descripcion = curso.Descripcion;
            entity.Estatus = curso.Estatus; 

            _Mcontext.Update(entity);

            var rows = await _Mcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //*El profesor podra consultar su información
        public async Task<Profesor> ProfesorPorId(int id)
        {
            var profe = await _Mcontext.Profesors.FirstOrDefaultAsync(c => c.IdProfesor == id);
            return profe;
        }

        //*El profesor podra modificar su información
        public async Task<bool> ActualizarProfesor(int id, Profesor profesor)
        {
            if(id <= 0 || profesor == null)
                throw new ArgumentException("Falta informacion para poder actualizar su información");

            var entity = await ProfesorPorId(id);

            entity.NombreCompleto = profesor.NombreCompleto;
            entity.Correo = profesor.Correo;
            entity.Clave = profesor.Clave;
            entity.RedesSociales = profesor.RedesSociales;
            entity.Descripcion = profesor.Descripcion;

            _Mcontext.Update(entity);

            var rows = await _Mcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //*El profesor podra eliminar sus cursos
        public void EliminarCurso(int id)
        {
            var Mcurso = _Mcontext.Cursos.FirstOrDefault(c => c.IdCurso == id);

            var inscripcion = _Mcontext.Inscripcions.AsQueryable().Where(i => i.IdCurso == id);

            if(inscripcion!=null)
            {
                _Mcontext.Inscripcions.RemoveRange(inscripcion);

                if(Mcurso!=null)
                {
                    _Mcontext.Cursos.Remove(Mcurso);

                    _Mcontext.SaveChanges();
                }
            }
        }
    }
}