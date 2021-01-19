using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class NotasProfesorV
    {
        public string Carnet { get; set; }
        public string Rubro { get; set; }
        public int? PorcentajeDelRubro { get; set; }
        public int? Nota { get; set; }
        public string NombreDeEvaluacion { get; set; }
        public int? PorcentajeDeEvaluacion { get; set; }
    }
}
