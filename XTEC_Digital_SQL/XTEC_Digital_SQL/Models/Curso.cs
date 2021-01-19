using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Curso
    {
        public Curso()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
            Grupos = new HashSet<Grupo>();
            ProfesorCursos = new HashSet<ProfesorCurso>();
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
        public string Carrera { get; set; }

        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<ProfesorCurso> ProfesorCursos { get; set; }
    }
}
