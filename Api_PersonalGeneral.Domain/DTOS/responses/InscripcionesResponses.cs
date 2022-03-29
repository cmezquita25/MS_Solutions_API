//cSpell: disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_PersonalGeneral.Domain.Entities;

namespace Api_PersonalGeneral.Domain.DTOS.responses
{
    public class InscripcionesResponses
    {
        public int IdInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
    }
}