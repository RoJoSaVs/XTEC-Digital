using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Grupos = new HashSet<Grupo>();
            ProfesorCursos = new HashSet<ProfesorCurso>();
        }

        public string Cedula { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<ProfesorCurso> ProfesorCursos { get; set; }
    }
}
