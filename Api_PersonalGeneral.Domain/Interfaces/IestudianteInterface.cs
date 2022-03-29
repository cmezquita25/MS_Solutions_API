//cSpell: disable

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;


namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IestudianteInterface
    {
        Task<IQueryable<Curso>> ATodosLosCursos();
        Task<Curso> ACursoPorId(int id);
        Task<Estudiante> EstudiantePorId(int id);
        Task<Estudiante> Login(string correo, string clave);

        Task<bool> Update(int id, Estudiante estudiante);
        Task<int> Inscribirse(Inscripcion inscripcion);
        void EliminarInscripcion(int id);
    }
}