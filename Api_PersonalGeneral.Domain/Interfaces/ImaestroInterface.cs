//#cSpell:disable

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface ImaestroInterface
    {
        //*Consultar todos los cursos
        Task<IQueryable<Curso>> TodosLosCursos();

        //*Registrar curso
        Task<int> RegistrarCurso(Curso curso);

        //Busca si existe un curso
        bool Exist(Expression<Func<Curso, bool>> expression);

        //*Buscar curso por Id
        Task<Curso> CursoPorId(int id);

        //*Modificar curso
        Task<bool> Update(int id, Curso curso);

        //*Eliminar curso
        void EliminarCurso(int id);

        //*Buscar profesor por id
        Task<Profesor> ProfesorPorId(int id);

        //*Actuaizar información del profesor
        Task<bool> ActualizarProfesor(int id, Profesor profesor);
    }
}