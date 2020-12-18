using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTEC_Digital_SQL.Models
{
    //Modelo para obtener los datos del archivo excel
    public partial class TablaExcel
    {
        public int Id { get; set; }
        public string Anio { get; set; }
        public string Periodo { get; set; }
        public string CodigoCurso { get; set; }
        public int NumeroGrupo { get; set; }
        public string CarnetEstudiante { get; set; }
        public string Profesor1 { get; set; }
    }
}
    /*{
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string IdCurso { get; set; }
        public string NombreCurso { get; set; }
        public int Ano { get; set; }
        public string Semestre { get; set; }
        public int Grupo { get; set; }
        public string IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public string Apellido1Profesor { get; set; }
        public string Apellido2Profesor { get; set; }
    }*/