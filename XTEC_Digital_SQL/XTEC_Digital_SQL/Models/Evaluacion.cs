using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Evaluacion
    {
        public Evaluacion()
        {
            Entregables = new HashSet<Entregable>();
        }

        public string EvaluacionId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public bool? GrupalIndividual { get; set; }
        public string EspecificacionArchivo { get; set; }
        public int? Porcentaje { get; set; }
        public string RubroId { get; set; }

        public virtual Rubro Rubro { get; set; }
        public virtual ICollection<Entregable> Entregables { get; set; }
    }
}
