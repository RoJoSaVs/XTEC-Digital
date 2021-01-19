using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XTEC_Digital_SQL.Models;
using ClosedXML.Excel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Reports.ReportControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculadosCursoController : ControllerBase
    {
        // GET: api/<MatriculadosCurso>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MatriculadosCurso>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var estudiantes = db.Set<MatriculadosV>().FromSqlRaw("EXEC VerMatriculados {0}", id).ToList();
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(id);
                        var currentRow = 1;
                        #region Header
                        worksheet.Cell(currentRow, 1).Value = "Carnet";
                        worksheet.Cell(currentRow, 2).Value = "Nombre";
                        worksheet.Cell(currentRow, 3).Value = "Email";
                        worksheet.Cell(currentRow, 4).Value = "Numero";
                        #endregion

                        #region Body
                        foreach (var estudiante in estudiantes)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = estudiante.EstudianteId;
                        }
                        #endregion

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return File(
                                    content,
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                    "Estudiantes.xlsx"
                                    );
                        }
                    }
                    //return Ok(x);
                }
                //return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<MatriculadosCurso>
        [HttpPost("{id}")]
        public bool Post(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Curso curso = db.Cursos.Find(id);
                    if (curso == null)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT api/<MatriculadosCurso>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MatriculadosCurso>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
