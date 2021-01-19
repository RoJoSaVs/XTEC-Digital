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
    public class profesorCursoController : ControllerBase
    {
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.ProfesorCursos
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
                    ProfesorCurso profesorCurso = db.ProfesorCursos.Find(id);
                    return Ok(profesorCurso);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] ProfesorCurso profesorCursoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    ProfesorCurso profesorCurso = new ProfesorCurso();
                    profesorCurso.ProfesorId = profesorCursoModel.ProfesorId;
                    profesorCurso.CursoId = profesorCursoModel.CursoId;
                    db.ProfesorCursos.Add(profesorCurso);
                    db.SaveChanges();
                }
                return Ok("Profesor asignado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] ProfesorCurso profesorCursoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    ProfesorCurso profesorCurso = db.ProfesorCursos.Find(id);
                    profesorCurso.ProfesorId = profesorCursoModel.ProfesorId;
                    profesorCurso.CursoId = profesorCursoModel.CursoId;
                    db.Entry(profesorCurso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return Ok("Actualizacion realizada");
            }
            catch
            {
                return BadRequest("No se pudo realizar la actualizacion");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    ProfesorCurso profesorCurso = db.ProfesorCursos.Find(id);
                    db.ProfesorCursos.Remove(profesorCurso);
                    db.SaveChanges();
                }
                return Ok("Eliminacion realizada");
            }
            catch
            {
                return BadRequest("No se pudo eliminar el elemento");
            }
        }
    }
}
