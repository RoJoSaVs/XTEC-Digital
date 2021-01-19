using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
            EstudianteGrupos = new HashSet<EstudianteGrupo>();
            SubGrupos = new HashSet<SubGrupo>();
        }

        public string Carnet { get; set; }

        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual ICollection<EstudianteGrupo> EstudianteGrupos { get; set; }
        public virtual ICollection<SubGrupo> SubGrupos { get; set; }
    }
}
