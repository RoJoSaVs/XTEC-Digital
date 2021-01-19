using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XTEC_Digital_SQL.Models;
using ClosedXML.Excel;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Reports
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasEstudianteController : ControllerBase
    {
        // GET: api/<NotasEstudianteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<NotasEstudianteController>/5
        [HttpGet("{grupo_id}/{carnet}")]
        public IActionResult Get(string grupo_id, string carnet)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var estudiantes = db.Set<NotasEstudianteV>().FromSqlRaw("EXEC VerNotasEstudiante {0}, {1}", carnet, grupo_id).ToList();
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add(grupo_id);
                        var currentRow = 1;
                        #region Header
                        worksheet.Cell(currentRow, 1).Value = "Rubro";
                        worksheet.Cell(currentRow, 2).Value = "Porcentaje Del Rubro";
                        worksheet.Cell(currentRow, 3).Value = "Nombre De Evaluacion";
                        worksheet.Cell(currentRow, 4).Value = "Porcentaje De Evaluacion";
                        worksheet.Cell(currentRow, 5).Value = "Nota";
                        #endregion

                        #region Body
                        foreach (var estudiante in estudiantes)
                        {
                            currentRow++;
                            worksheet.Cell(currentRow, 1).Value = estudiante.Rubro;
                            worksheet.Cell(currentRow, 2).Value = estudiante.PorcentajeDelRubro;
                            worksheet.Cell(currentRow, 3).Value = estudiante.NombreDeEvaluacion;
                            worksheet.Cell(currentRow, 4).Value = estudiante.PorcentajeDeEvaluacion;
                            worksheet.Cell(currentRow, 5).Value = estudiante.Nota;
                        }
                        #endregion

                        using (var stream = new MemoryStream())
                        {
                            workbook.SaveAs(stream);
                            var content = stream.ToArray();

                            return File(
                                    content,
                                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                    "EstudianteEvaluacion.xlsx"
                                    );
                        }
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST api/<NotasEstudianteController>
        [HttpPost("{id}")]
        public bool Post(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Grupo curso = db.Grupos.Find(id);
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

        // PUT api/<NotasEstudianteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotasEstudianteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
