using System;
using System.Collections.Generic;

#nullable disable

namespace Api_PersonalGeneral.Domain.Entities
{
    public partial class Profesor
    {
        public Profesor()
        {
            Cursos = new HashSet<Curso>();
        }

        public int IdProfesor { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string RedesSociales { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
}
