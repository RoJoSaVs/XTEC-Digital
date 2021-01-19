using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Carpetum
    {
        public Carpetum()
        {
            Archivos = new HashSet<Archivo>();
        }

        public string CarpetaId { get; set; }
        public string Nombre { get; set; }
        public string RutaUrl { get; set; }
        public string GrupoId { get; set; }

        public virtual Grupo Grupo { get; set; }
        public virtual ICollection<Archivo> Archivos { get; set; }
    }
}
