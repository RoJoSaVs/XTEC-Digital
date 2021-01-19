using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class EstudianteGrupo
    {
        public string EstudianteId { get; set; }
        public string GrupoId { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
