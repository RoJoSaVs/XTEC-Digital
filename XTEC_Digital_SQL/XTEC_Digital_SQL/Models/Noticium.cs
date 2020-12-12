using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Noticium
    {
        public string NoticiaId { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
        public string GrupoId { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
