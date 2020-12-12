using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Entregable
    {
        public Entregable()
        {
            SubGrupos = new HashSet<SubGrupo>();
        }

        public string EntregableId { get; set; }
        public int? Nota { get; set; }
        public string Observaciones { get; set; }
        public string ArchivoRetroalimentacion { get; set; }
        public string ArchivoEntregable { get; set; }
        public bool? Publico { get; set; }
        public bool? Evaluado { get; set; }
        public string EvaluacionId { get; set; }

        public virtual Evaluacion Evaluacion { get; set; }
        public virtual ICollection<SubGrupo> SubGrupos { get; set; }
    }
}
