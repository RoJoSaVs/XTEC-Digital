using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class SubGrupo
    {
        public string SubGrupoId { get; set; }
        public string EstudianteId { get; set; }
        public string GrupoId { get; set; }
        public string EntregableId { get; set; }

        public virtual Entregable Entregable { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
