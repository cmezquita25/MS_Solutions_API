//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PersonalGeneral.Domain.DTOS.responses
{
    public class EstudianteResponses
    {
        public int IdEstudiante {get; set;}
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
    }
}