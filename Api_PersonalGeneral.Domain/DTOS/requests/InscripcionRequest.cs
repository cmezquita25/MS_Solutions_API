//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_PersonalGeneral.Domain.DTOS.requests
{
    public class InscripcionRequest
    {
        public int IdInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
    }
}