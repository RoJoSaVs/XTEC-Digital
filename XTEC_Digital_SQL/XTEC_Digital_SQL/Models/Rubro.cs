using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Rubro
    {
        public Rubro()
        {
            Evaluacions = new HashSet<Evaluacion>();
        }

        public string RubroId { get; set; }
        public string Nombre { get; set; }
        public int? Porcentaje { get; set; }
        public string GrupoId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual ICollection<Evaluacion> Evaluacions { get; set; }
    }
}
