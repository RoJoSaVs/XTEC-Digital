using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Archivo
    {
        public string ArchivoId { get; set; }
        public string Nombre { get; set; }
        public string ArchivoPdf { get; set; }
        public int? Tamanio { get; set; }
        public DateTime? Fecha { get; set; }
        public string CarpetaId { get; set; }

        public virtual Carpetum Carpeta { get; set; }
    }
}
