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
    public class EstudianteSqlRepositories : IestudianteInterface
    {
        private readonly PersonalGeneralContext _Acontext;

        public EstudianteSqlRepositories(PersonalGeneralContext acontext)
        {
            _Acontext = acontext;
        }

        //*El estudiante podra consultar todos los cursos registrados en la plataforma
        public async Task<IQueryable<Curso>> ATodosLosCursos()
        {
            var Acurso = await _Acontext.Cursos.AsQueryable<Curso>().AsNoTracking().ToListAsync();

            return Acurso.AsQueryable();
        }

        //*Buscar curso por Id
        public async Task<Curso> ACursoPorId(int id)
        {
            var Acurso = await _Acontext.Cursos.FirstOrDefaultAsync(c => c.IdCurso == id);

            return Acurso;
        }

        //*Buscar estudiante por Id
        public async Task<Estudiante> EstudiantePorId(int id)
        {
            var alumno = await _Acontext.Estudiantes.FirstOrDefaultAsync(c => c.IdEstudiante == id);

            return alumno;
        }

        //*El estudiante podra modificar su información
        public async Task<bool> Update(int id, Estudiante estudiante)
        {
            if(id <= 0 || estudiante == null)
                throw new ArgumentException("Falta informacion para poder actualizar su información");

            var entity = await EstudiantePorId(id);

            entity.NombreCompleto = estudiante.NombreCompleto;
            entity.Correo = estudiante.Correo;
            entity.Clave = estudiante.Clave;

            _Acontext.Update(entity);

            var rows = await _Acontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //*El estudiante podrá inscribirse a un curso (POST)
        public async Task<int> Inscribirse(Inscripcion inscripcion)
        {
            var entity = inscripcion;

            await _Acontext.Inscripcions.AddAsync(entity);

            var rows = await _Acontext.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo inscribir al curso...");
            
            return entity.IdInscripcion;
        }
        

        //*El estudiante podra darse de baja del curso (DELETE)
        public void EliminarInscripcion(int id)
        {
            var BajaInscripcion = _Acontext.Inscripcions.FirstOrDefault(i => i.IdInscripcion == id);

            if(BajaInscripcion!=null)
            {
                _Acontext.Inscripcions.Remove(BajaInscripcion);
                _Acontext.SaveChanges();
            }
        }

        public async Task<Estudiante> Login(string correo, string clave)
        {
            var alumno = await _Acontext.Estudiantes.Where(est => est.Correo == correo && est.Clave == clave).FirstOrDefaultAsync();

            return alumno;
        }
    }
}