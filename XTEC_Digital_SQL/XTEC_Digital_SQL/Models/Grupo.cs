using System;
using System.Collections.Generic;

#nullable disable

namespace XTEC_Digital_SQL.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Carpeta = new HashSet<Carpetum>();
            EstudianteGrupos = new HashSet<EstudianteGrupo>();
            Noticia = new HashSet<Noticium>();
            Rubros = new HashSet<Rubro>();
            SubGrupos = new HashSet<SubGrupo>();
        }

        public string GrupoId { get; set; }
        public int? Matriculados { get; set; }
        public int? NumeroGrupo { get; set; }
        public int? Cupo { get; set; }
        public int? Anio { get; set; }
        public string Periodo { get; set; }
        public string CursoId { get; set; }
        public string ProfesorId { get; set; }

        public virtual Curso Curso { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<Carpetum> Carpeta { get; set; }
        public virtual ICollection<EstudianteGrupo> EstudianteGrupos { get; set; }
        public virtual ICollection<Noticium> Noticia { get; set; }
        public virtual ICollection<Rubro> Rubros { get; set; }
        public virtual ICollection<SubGrupo> SubGrupos { get; set; }
    }
}
