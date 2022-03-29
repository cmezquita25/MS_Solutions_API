//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PersonalGeneral.Domain.DTOS.responses
{
    public class ProfesorResponses
    {
        public int IdProfesor {get; set;}
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string RedesSociales { get; set; }
        public string Descripcion { get; set; }
    }
}