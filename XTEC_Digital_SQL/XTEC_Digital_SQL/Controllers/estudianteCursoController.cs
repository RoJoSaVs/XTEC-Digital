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
    public class estudianteCursoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.EstudianteCursos
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
                    EstudianteCurso estudianteCurso= db.EstudianteCursos.Find(id);
                    return Ok(estudianteCurso);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] EstudianteCurso estudianteCursoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    EstudianteCurso estudianteCurso = new EstudianteCurso();
                    estudianteCurso.EstudianteId = estudianteCursoModel.EstudianteId;
                    estudianteCurso.CursoId = estudianteCursoModel.CursoId;
                    db.EstudianteCursos.Add(estudianteCurso);
                    db.SaveChanges();
                }
                return Ok("Mtricula agregada");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] EstudianteCurso estudianteCursoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    EstudianteCurso estudianteCurso = db.EstudianteCursos.Find(id);
                    estudianteCurso.EstudianteId = estudianteCursoModel.EstudianteId;
                    estudianteCurso.CursoId = estudianteCursoModel.CursoId;
                    db.Entry(estudianteCurso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    EstudianteCurso estudianteCurso = db.EstudianteCursos.Find(id);
                    db.EstudianteCursos.Remove(estudianteCurso);
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
