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
    public class subgruposController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.SubGrupos
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
                    SubGrupo subGrupo = db.SubGrupos.Find(id);
                    return Ok(subGrupo);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] SubGrupo subGrupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    SubGrupo subGrupo = new SubGrupo();
                    subGrupo.SubGrupoId = subGrupoModel.SubGrupoId;
                    subGrupo.EstudianteId = subGrupoModel.EstudianteId;
                    subGrupo.GrupoId = subGrupoModel.GrupoId;
                    subGrupo.EntregableId = subGrupoModel.EntregableId;
                    db.SubGrupos.Add(subGrupo);
                    db.SaveChanges();
                }
                return Ok("SubGrupo agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] SubGrupo subGrupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    SubGrupo subGrupo = db.SubGrupos.Find(id);
                    subGrupo.EstudianteId = subGrupoModel.EstudianteId;
                    subGrupo.GrupoId = subGrupoModel.GrupoId;
                    subGrupo.EntregableId = subGrupoModel.EntregableId;
                    db.Entry(subGrupo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    SubGrupo subGrupo = db.SubGrupos.Find(id);
                    db.SubGrupos.Remove(subGrupo);
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
