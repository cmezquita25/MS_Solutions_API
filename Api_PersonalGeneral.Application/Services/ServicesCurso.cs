//cSpell: disable

using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.Interfaces;

namespace Api_PersonalGeneral.Application.Services
{
    public class ServicesCurso : ICursoService
    {
        public bool CursoValidated(Curso curso)
        {
            if(string.IsNullOrEmpty(curso.Titulo))
                return false;
            if(string.IsNullOrEmpty(curso.LinkReunion))
                return false;
            if(string.IsNullOrEmpty(curso.Material))
                return false;
            if(string.IsNullOrEmpty(curso.Descripcion))
                return false;

            if(curso.IdCurso <= 0)
                return false;

            return true;
        }

        public bool ActualizarCurso_Validated(Curso curso)
        {
            if(string.IsNullOrEmpty(curso.Titulo))
                return false;
            if(string.IsNullOrEmpty(curso.LinkReunion))
                return false;
            if(string.IsNullOrEmpty(curso.Material))
                return false;
            if(string.IsNullOrEmpty(curso.Descripcion))
                return false;

            if(curso.IdCurso <= 0)
                return false;

            return true;
        }
    }
}