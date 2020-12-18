using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using XTEC_Digital_SQL.Models;
using Microsoft.AspNetCore.Http;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tableExcelController : ControllerBase
    {
        private readonly XTEC_DigitalContext _context;

        // GET: api/<tableExcelController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<tableExcelController>
        [HttpPost]// ("UploadFile")]
        public ActionResult Post(List<IFormFile> files)
        {
            return Ok();
        }
        [HttpPost("UploadFile")]
        public ActionResult Post([FromBody] IEnumerable<TablaExcel> tablaExcel)
        {
            try
            {
                if (tablaExcel == null)
                    throw new ArgumentNullException(nameof(tablaExcel));

                // se crea una tabla
                var table = new DataTable();

                // se agregan las columnas a la tabla
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("Anio", typeof(string));
                table.Columns.Add("Periodo", typeof(string));
                table.Columns.Add("CodigoCurso", typeof(string));
                table.Columns.Add("NumeroGrupo", typeof(int));
                table.Columns.Add("CarnetEstudiante", typeof(string));
                table.Columns.Add("Profesor1", typeof(string));

                int id = 1;
                // se recorre la lista y se agregan los elementos a la tabla
                foreach (var s in tablaExcel)
                {
                    table.Rows.Add(id, s.Anio, s.Periodo, s.CodigoCurso, s.NumeroGrupo, s.CarnetEstudiante, s.Profesor1);
                    id++;
                }
                // se crea un parámetro de SQL
                var parameter = new SqlParameter("@TablaE", SqlDbType.Structured);
                parameter.Value = table;
                parameter.TypeName = "dbo.SemestreExcel";

                // se ejcuta el stored procedure
                _context.Database.ExecuteSqlRaw("exec spSemestreExcel @TablaE", parameter);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
/*
 public void CreateFromExcel(IEnumerable<SemestreExcel> semestre)
        {
            if (semestre == null)
                throw new ArgumentNullException(nameof(semestre));
            
            // se crea una tabla
            var table = new DataTable();

            // se agregan las columnas a la tabla
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Anio", typeof(string));
            table.Columns.Add("Periodo", typeof(string));
            table.Columns.Add("CodigoCurso", typeof(string));
            table.Columns.Add("NumeroGrupo", typeof(int));
            table.Columns.Add("CarnetEstudiante", typeof(string));
            table.Columns.Add("Profesor1", typeof(string));

            int id = 1;
            // se recorre la lista y se agregan los elementos a la tabla
            foreach(var s in semestre)
            {
                table.Rows.Add(id, s.Anio, s.Periodo, s.CodigoCurso, s.NumeroGrupo, s.CarnetEstudiante, s.Profesor1);
                id++;
            }
            // se crea un parámetro de SQL
            var parameter = new SqlParameter("@TablaE", SqlDbType.Structured);
            parameter.Value = table;
            parameter.TypeName = "dbo.SemestreExcel";

            // se ejcuta el stored procedure
            _context.Database.ExecuteSqlRaw("exec spSemestreExcel @TablaE",
                 parameter); 
        }
 */