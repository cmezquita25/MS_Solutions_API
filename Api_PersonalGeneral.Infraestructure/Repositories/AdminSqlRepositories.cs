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
    public class AdminSqlRepositories : IadminInterface
    {
        private readonly PersonalGeneralContext _adcontext;

        public AdminSqlRepositories(PersonalGeneralContext adcontext)
        {
            _adcontext = adcontext;
        }

        #region Gestion de las cuentas de profesores
        //Todos los profesores 
        public async Task<IQueryable<Profesor>> TodosLosProfesores()
        {
            var profes = await _adcontext.Profesors.AsQueryable<Profesor>().AsNoTracking().ToListAsync();

            return profes.AsQueryable();
        }

        //Este método realiza la función de comprobar la existencia de un profesor en la BD
        public bool ExistProfe(Expression<Func<Profesor, bool>> expression)
        {
            return _adcontext.Profesors.Any(expression);
        }

        //registrar profesor
        public async Task<int> RegistrarProfesor(Profesor profesor)
        {
            var entity = profesor;

            await _adcontext.Profesors.AddAsync(entity);

            var rows = await _adcontext.SaveChangesAsync();

            if(rows <= 0)
            {
                throw new Exception("¡ERROR!: No se pudo registrar al profesor...Verifique la información.");
            
            }

            return entity.IdProfesor;
        }

        //Eliminar profesor
        public void EliminarProfesor(int id)
        {
            var profes = _adcontext.Profesors.FirstOrDefault(p => p.IdProfesor == id);

            var cursos = _adcontext.Cursos.AsQueryable().Where(c => c.IdProfesor == id);

            if(cursos!=null)
            {
                _adcontext.Cursos.RemoveRange(cursos);

                if(profes!=null)
                {
                    _adcontext.Profesors.Remove(profes);

                    _adcontext.SaveChanges();
                }
            }
        }

        //Actualizar profesor
        public async Task<bool> ActualizarProfesor(int id, Profesor profesor)
        {
            if(id <= 0 || profesor == null)
                throw new ArgumentException("Falta informacion para poder actualizar la información del profesor");

            var entity = await ProfesorPorId(id);

            entity.NombreCompleto = profesor.NombreCompleto;
            entity.Correo = profesor.Correo;
            entity.Clave = profesor.Clave;
            entity.RedesSociales = profesor.RedesSociales;
            entity.Descripcion = profesor.Descripcion;

            _adcontext.Update(entity);

            var rows = await _adcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //profesor por ID
        public async Task<Profesor> ProfesorPorId(int id)
        {
            var profe = await _adcontext.Profesors.FirstOrDefaultAsync(c => c.IdProfesor == id);
            return profe;
        }

        #endregion

        #region Gestion de las cuentas de estudiantes

        //Todos los estudiantes
        public async Task<IQueryable<Estudiante>> TodosLosEstudiante()
        {
            var student = await _adcontext.Estudiantes.AsQueryable<Estudiante>().AsNoTracking().ToListAsync();

            return student.AsQueryable();
        }

        //este método comprueba la existencia de un estudiante ne la BD
        public bool ExistEstudiante(Expression<Func<Estudiante, bool>> expression)
        {
            return _adcontext.Estudiantes.Any(expression);
        }

        //Registrar estudiante
        public async Task<int> RegistrarEstudiante(Estudiante estudiante)
        {
            var entity = estudiante;

            await _adcontext.Estudiantes.AddAsync(entity);

            var rows = await _adcontext.SaveChangesAsync();

            if(rows <= 0)
            {
                throw new Exception("¡ERROR!: No se pudo registrar al estudiante...Verifique la información.");
            }
            return entity.IdEstudiante;
        }

        //Eliminar estudiante
        public void EliminarEstudiante(int id)
        {
            var student = _adcontext.Estudiantes.FirstOrDefault(e => e.IdEstudiante == id); 

            var inscripcion = _adcontext.Inscripcions.AsQueryable().Where(i => i.IdEstudiante == id);


            
            if(inscripcion!=null)
            {
                _adcontext.Inscripcions.RemoveRange(inscripcion);

                if(student!=null)
                {
                    _adcontext.Estudiantes.Remove(student);

                    _adcontext.SaveChanges();
                }

            }
        }

        //Actualizar estudiante
        public async Task<bool> Update(int id, Estudiante estudiante)
        {
            if(id <= 0 || estudiante == null)
                throw new ArgumentException("Falta informacion para poder actualizar la información del estudiante");

            var entity = await EstudiantePorId(id);

            entity.NombreCompleto = estudiante.NombreCompleto;
            entity.Correo = estudiante.Correo;
            entity.Clave = estudiante.Clave;

            _adcontext.Update(entity);

            var rows = await _adcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //Estudiante por ID
        public async Task<Estudiante> EstudiantePorId(int id)
        {
            var estudiante = await _adcontext.Estudiantes.FirstOrDefaultAsync(c => c.IdEstudiante == id);

            return estudiante;
        }

        #endregion

        #region Gestion de Cursos
        
        //Todos los cursos
        public async Task<IQueryable<Curso>> TodosLosCursos()
        {
            var cursos = await _adcontext.Cursos.AsQueryable<Curso>().AsNoTracking().ToListAsync();

            return cursos.AsQueryable();
        }

        //Este método comprueba la existencia de un curso en la BD
        public bool ExistCurso(Expression<Func<Curso, bool>> expression)
        {
            return _adcontext.Cursos.Any(expression);
        }

        //registrar curso
        public async Task<int> RegistrarCurso(Curso curso)
        {
            var entity = curso;

            await _adcontext.Cursos.AddAsync(entity);

            var rows = await _adcontext.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo registrar el curso...Verifique la información.");
            
            return entity.IdCurso;
        }

        //Eliminar curso
        public void EliminarCurso(int id)
        {
            var cursos = _adcontext.Cursos.FirstOrDefault(c => c.IdCurso == id);

            var inscripcion = _adcontext.Inscripcions.AsQueryable().Where(i => i.IdCurso == id);

            if(inscripcion!=null)
            {
                _adcontext.Inscripcions.RemoveRange(inscripcion);

                if(cursos!=null)
                {
                    _adcontext.Cursos.Remove(cursos);

                    _adcontext.SaveChanges();
                }
            }
        }

        //Actualizar curso
        public async Task<bool> UpdateCurso(int id, Curso curso)
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

            _adcontext.Update(entity);

            var rows = await _adcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //Curso por ID
        public async Task<Curso> CursoPorId(int id)
        {
            var curso = await _adcontext.Cursos.FirstOrDefaultAsync(c => c.IdCurso == id);
            return curso;
        }

        #endregion
    
        #region Gestion de Inscripciones
        //Todas las inscripciones de los estudiantes a los cursos
        public async Task<IQueryable<Inscripcion>> TodasLasInscripciones()
        {
            var inscrip = await _adcontext.Inscripcions.AsQueryable<Inscripcion>().AsNoTracking().ToListAsync();

            return inscrip.AsQueryable();
        }

        //Registrar inscripcion a un curso
        public async Task<int> InscripcionAcurso(Inscripcion inscripcion)
        {
            var entity = inscripcion;

            await _adcontext.Inscripcions.AddAsync(entity);

            var rows = await _adcontext.SaveChangesAsync();

            if(rows <= 0)
            
                throw new Exception("¡ERROR!: No se pudo inscribir al estudiante al curso...");
            
            return entity.IdInscripcion;
        }

        //Actualizar inscripcion
        public async Task<bool> UpdateInscripcion(int id, Inscripcion inscripcion)
        {
            if(id <= 0 || inscripcion == null)
                throw new ArgumentException("Falta informacion para poder actualizar la inscripcion");

            var entity = await InscripcionPorId(id);

            entity.IdEstudiante = inscripcion.IdEstudiante;
            entity.IdCurso = inscripcion.IdCurso;

            _adcontext.Update(entity);

            var rows = await _adcontext.SaveChangesAsync();
            
            return rows > 0;
        }

        //inscripción por ID
        public async Task<Inscripcion> InscripcionPorId(int id)
        {
            var inscrip = await _adcontext.Inscripcions.FirstOrDefaultAsync(c => c.IdInscripcion == id);

            return inscrip;
        }

        //Eliminar inscripcion
        public void EliminarInscripcion(int id)
        {
            var BajaInscripcion = _adcontext.Inscripcions.FirstOrDefault(i => i.IdInscripcion == id);

            if(BajaInscripcion!=null)
            {
                _adcontext.Inscripcions.Remove(BajaInscripcion);

                _adcontext.SaveChanges();
            }
        }

        public bool ExistInscrip(Expression<Func<Inscripcion, bool>> expression)
        {
            return _adcontext.Inscripcions.Any(expression);
        }
        #endregion

        public async Task<Admin> LoginAdmin(string username, string clave)
        {
            var admin = await _adcontext.Admins.Where(adm => adm.UserName == username && adm.Clave == clave).FirstOrDefaultAsync();

            return admin;
        }
    }
}