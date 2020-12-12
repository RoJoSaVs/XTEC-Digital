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
    public class profesoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Profesors
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("No se pudo mostrar la informacion");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Profesor profesor = db.Profesors.Find(id);
                    return Ok(profesor);

                }
            }
            catch
            {
                return BadRequest("Informacion no encontrada");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Profesor profesorModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Profesor profesor = new Profesor();
                    profesor.Cedula = profesorModel.Cedula;
                    db.Profesors.Add(profesor);
                    db.SaveChanges();
                }
                return Ok("Profesor agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar al profesor");
            }
        }

        [HttpPut("{id}")]
        /*public void Put(string id, [FromBody] Curso cursoModel)
        {
            using (XTEC_DigitalContext db = new XTEC_DigitalContext())
            {
                Curso curso = db.Cursos.Find(id);
                curso.Nombre = cursoModel.Nombre;
                curso.Creditos = cursoModel.Creditos;
                curso.Carrera = cursoModel.Carrera;
                db.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Profesor profesor = db.Profesors.Find(id);
                    db.Profesors.Remove(profesor);
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
