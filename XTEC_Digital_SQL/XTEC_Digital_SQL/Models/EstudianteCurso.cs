using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class EstudianteCurso
    {
        public string EstudianteId { get; set; }
        public string CursoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
