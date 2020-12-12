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
    public class evaluacionesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Evaluacions
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("Elementos no encontrados");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Evaluacion evaluacion = db.Evaluacions.Find(id);
                    return Ok(evaluacion);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Evaluacion evaluacionModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Evaluacion evaluacion = new Evaluacion();
                    evaluacion.EvaluacionId = evaluacionModel.EvaluacionId;
                    evaluacion.Nombre = evaluacionModel.Nombre;
                    evaluacion.FechaEntrega = evaluacionModel.FechaEntrega;
                    evaluacion.GrupalIndividual = evaluacionModel.GrupalIndividual;
                    evaluacion.EspecificacionArchivo = evaluacionModel.EspecificacionArchivo;
                    evaluacion.Porcentaje = evaluacionModel.Porcentaje;
                    evaluacion.RubroId = evaluacionModel.RubroId;
                    db.Evaluacions.Add(evaluacion);
                    db.SaveChanges();
                }
                return Ok("Evaluacion agregada");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Evaluacion evaluacionModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Evaluacion evaluacion= db.Evaluacions.Find(id);
                    evaluacion.Nombre = evaluacionModel.Nombre;
                    evaluacion.FechaEntrega = evaluacionModel.FechaEntrega;
                    evaluacion.GrupalIndividual = evaluacionModel.GrupalIndividual;
                    evaluacion.EspecificacionArchivo = evaluacionModel.EspecificacionArchivo;
                    evaluacion.Porcentaje = evaluacionModel.Porcentaje;
                    evaluacion.RubroId = evaluacionModel.RubroId;
                    db.Entry(evaluacion).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return Ok("Actualizacion realizada");
            }
            catch
            {
                return BadRequest("Actualizacion no realizada");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Evaluacion evaluacion = db.Evaluacions.Find(id);
                    db.Evaluacions.Remove(evaluacion);
                    db.SaveChanges();
                }
                return Ok("Eliminacion realizada");
            }
            catch
            {
                return BadRequest("No se pudo eliminar");
            }
        }
    }
}
