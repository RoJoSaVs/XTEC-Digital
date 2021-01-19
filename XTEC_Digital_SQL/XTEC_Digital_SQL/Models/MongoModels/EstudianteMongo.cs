using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XTEC_Digital_SQL.Models.MongoModels
{
    public class EstudianteMongo
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Carnet { get; set; }
        public string Email { get; set; }
        /*public string NombreGrupo { get; set; }
        public string CodigoCurso { get; set; }*/
    }
}
