//cSpell: disable

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IalumnoInterface
    {
        Task<IQueryable<Estudiante>> TodosLosEstudiantes ();
        Task<int> RegistrarEstudiante(Estudiante estudiante);
        bool Exist(Expression<Func<Estudiante, bool>> expression);
        //Task<Estudiante> Login(string correo, string clave);
        void EliminarCuentaEstudiante(int id);
        //bool existStudent(string correo, string clave);
    }
}