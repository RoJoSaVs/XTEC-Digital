using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class ProfesorCurso
    {
        public string ProfesorId { get; set; }
        public string CursoId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
