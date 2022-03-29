//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;
using Api_PersonalGeneral.Domain.Interfaces;

namespace Api_PersonalGeneral.Application.Services
{
    public class ServiceEstudiante : IEstudianteService
    {
        public bool ActualizarEstudiante_Validated(Estudiante estudiante)
        {
            if(string.IsNullOrEmpty(estudiante.NombreCompleto))
                return false;
            if(string.IsNullOrEmpty(estudiante.Correo))
                return false;
            if(string.IsNullOrEmpty(estudiante.Clave))
                return false;

            if(estudiante.IdEstudiante <= 0)
                return false;

            return true;
        }

        public bool InscripcionValidated(Inscripcion inscripcion)
        {
            return true;
        }

    }
}