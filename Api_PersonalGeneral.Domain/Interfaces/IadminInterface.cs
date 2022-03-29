//cSpell: disable

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IadminInterface
    {
        Task<IQueryable<Profesor>> TodosLosProfesores();
        bool ExistProfe(Expression<Func<Profesor, bool>> expression);
        Task<int> RegistrarProfesor(Profesor profesor);
        void EliminarProfesor(int id);
        Task<bool> ActualizarProfesor(int id, Profesor profesor);
        Task<Profesor> ProfesorPorId(int id);
        Task<IQueryable<Estudiante>> TodosLosEstudiante();
        bool ExistEstudiante(Expression<Func<Estudiante, bool>> expression);
        Task<int> RegistrarEstudiante(Estudiante estudiante);
        void EliminarEstudiante(int id);
        Task<bool> Update(int id, Estudiante estudiante);
        Task<Estudiante> EstudiantePorId(int id);
        Task<IQueryable<Curso>> TodosLosCursos();
        bool ExistCurso(Expression<Func<Curso, bool>> expression);
        Task<int> RegistrarCurso(Curso curso);
        void EliminarCurso(int id);
        Task<bool> UpdateCurso(int id, Curso curso);
        Task<Curso> CursoPorId(int id);
        Task<IQueryable<Inscripcion>> TodasLasInscripciones();
        Task<int> InscripcionAcurso(Inscripcion inscripcion);
        Task<bool> UpdateInscripcion(int id, Inscripcion inscripcion);
        Task<Inscripcion> InscripcionPorId(int id);
        void EliminarInscripcion(int id);
        bool ExistInscrip(Expression<Func<Inscripcion, bool>> expression);
        Task<Admin> LoginAdmin(string username, string clave);
    }
}