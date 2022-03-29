//cSpell:disable

using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface ICursoService
    {
        bool CursoValidated(Curso curso);
        bool ActualizarCurso_Validated(Curso curso);
    }
}