using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XTEC_Digital_SQL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estudiantesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Estudiantes
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("Informacion no obtenida");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Estudiante estudiante = db.Estudiantes.Find(id);
                    return Ok(estudiante);
                }
            }
            catch
            {
                return BadRequest("Informacion no encontrada");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Estudiante estudianteModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.Carnet = estudianteModel.Carnet;
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges();
                }
                return Ok("Estudiante agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el estudiante");
            }
        }

        /*[HttpPut("{id}")]
        public void Put(string id, [FromBody] Curso cursoModel)
        {
            using (XTEC_DigitalContext db = new XTEC_DigitalContext())
            {
                Estudiante estudiante= db.Estudiantes.Find(id);
                
                db.Entry(estudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }*/

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Estudiante estudiante = db.Estudiantes.Find(id);
                    db.Estudiantes.Remove(estudiante);
                    db.SaveChanges();
                }
                return Ok("Eliminacion realizada");
            }
            catch
            {
                return BadRequest("Eliminacion no realizada");
            }
        }
    }
}
