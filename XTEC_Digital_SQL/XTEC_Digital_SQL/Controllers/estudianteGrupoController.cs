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
    public class estudianteGrupoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.EstudianteGrupos
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
                    EstudianteGrupo estudianteGrupo = db.EstudianteGrupos.Find(id);
                    return Ok(estudianteGrupo);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] EstudianteGrupo estudianteGrupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    EstudianteGrupo estudianteGrupo = new EstudianteGrupo();
                    estudianteGrupo.EstudianteId = estudianteGrupoModel.EstudianteId;
                    estudianteGrupo.GrupoId = estudianteGrupoModel.GrupoId;
                    db.EstudianteGrupos.Add(estudianteGrupo);
                    db.SaveChanges();
                }
                return Ok("Grupo matriculado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] EstudianteGrupo estudianteGrupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    EstudianteGrupo estudianteGrupo = db.EstudianteGrupos.Find(id);
                    estudianteGrupo.EstudianteId = estudianteGrupoModel.EstudianteId;
                    estudianteGrupo.GrupoId = estudianteGrupoModel.GrupoId;
                    db.Entry(estudianteGrupo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    EstudianteGrupo estudianteGrupo = db.EstudianteGrupos.Find(id);
                    db.EstudianteGrupos.Remove(estudianteGrupo);
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
