using System;
using System.Collections.Generic;

#nullable disable

namespace Api_PersonalGeneral.Domain.Entities
{
    public partial class Inscripcion
    {
        public Inscripcion()
        {

        }
        
        public int IdInscripcion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Estudiante IdEstudianteNavigation { get; set; }
    }
}
