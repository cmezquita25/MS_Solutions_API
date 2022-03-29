//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PersonalGeneral.Domain.DTOS.requests
{
    public class EstudianteRequest
    {
        public int IdEstudiante { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}