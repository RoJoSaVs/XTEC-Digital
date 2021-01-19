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
    public class entregablesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Entregables
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("Informacion no encontrada");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Entregable entregable = db.Entregables.Find(id);
                    return Ok(entregable);
                }
            }
            catch
            {
                return BadRequest("Informacion no encontrada");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Entregable entregableModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Entregable entregable = new Entregable();
                    entregable.EntregableId = entregableModel.EntregableId;
                    entregable.Nota = entregableModel.Nota;
                    entregable.Observaciones = entregableModel.Observaciones;
                    entregable.ArchivoRetroalimentacion = entregableModel.ArchivoRetroalimentacion;
                    entregable.ArchivoEntregable = entregableModel.ArchivoEntregable;
                    entregable.Publico = entregableModel.Publico;
                    entregable.Evaluado = entregableModel.Evaluado;
                    entregable.EvaluacionId = entregableModel.EvaluacionId;
                    db.Entregables.Add(entregable);
                    db.SaveChanges();
                }
                return Ok("Entregable agregado");
            }
            catch
            {
                return BadRequest("Entregable no agregado");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Entregable entregableModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Entregable entregable = db.Entregables.Find(id);
                    entregable.Nota = entregableModel.Nota;
                    entregable.Observaciones = entregableModel.Observaciones;
                    entregable.ArchivoRetroalimentacion = entregableModel.ArchivoRetroalimentacion;
                    entregable.ArchivoEntregable = entregableModel.ArchivoEntregable;
                    entregable.Publico = entregableModel.Publico;
                    entregable.Evaluado = entregableModel.Evaluado;
                    entregable.EvaluacionId = entregableModel.EvaluacionId;
                    db.Entry(entregable).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Entregable entregable = db.Entregables.Find(id);
                    db.Entregables.Remove(entregable);
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
