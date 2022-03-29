//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.Interfaces
{
    public interface IAlumnoService
    {
        bool AlumnoValidated(Estudiante estudiante);

        
    }
}