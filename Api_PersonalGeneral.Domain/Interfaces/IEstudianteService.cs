//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IEstudianteService
    {
        bool ActualizarEstudiante_Validated(Estudiante estudiante);

        bool InscripcionValidated(Inscripcion inscripcion);
    }
}