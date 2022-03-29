//cSpell:disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PersonalGeneral.Domain.DTOS.responses
{
    public class CursoResponses
    {
        public int IdCurso {get; set;}
        public string Titulo { get; set; }
        public DateTime FechaDeInicio { get; set; }
        public DateTime FechaDeCierre { get; set; }

        public string LinkReunion { get; set; }
        public string Material { get; set; }
        public string Descripcion { get; set; }
        public string Estatus {get; set;}
        public int IdProfesor {get; set;}
        
    }
}