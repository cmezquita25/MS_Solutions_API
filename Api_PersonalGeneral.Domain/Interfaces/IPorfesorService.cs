//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IPorfesorService
    {
        bool ProfesorValidated(Profesor profesor);

        bool ActualizarProfesor_Validated(Profesor profesor);
    }
}