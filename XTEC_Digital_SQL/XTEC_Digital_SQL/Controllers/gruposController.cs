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
    public class gruposController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Grupos
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
                    Grupo grupo = db.Grupos.Find(id);
                    return Ok(grupo);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Grupo grupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Grupo grupo = new Grupo();
                    grupo.GrupoId = grupoModel.GrupoId;
                    grupo.Matriculados = grupoModel.Matriculados;
                    grupo.NumeroGrupo = grupoModel.NumeroGrupo;
                    grupo.Cupo = grupoModel.Cupo;
                    grupo.Anio = grupoModel.Anio;
                    grupo.Periodo = grupoModel.Periodo;
                    grupo.CursoId = grupoModel.CursoId;
                    grupo.ProfesorId = grupoModel.ProfesorId;
                    db.Grupos.Add(grupo);
                    db.SaveChanges();
                }
                return Ok("Grupo agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Grupo grupoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Grupo grupo = db.Grupos.Find(id);
                    grupo.Matriculados = grupoModel.Matriculados;
                    grupo.NumeroGrupo = grupoModel.NumeroGrupo;
                    grupo.Cupo = grupoModel.Cupo;
                    grupo.Anio = grupoModel.Anio;
                    grupo.Periodo = grupoModel.Periodo;
                    grupo.CursoId = grupoModel.CursoId;
                    grupo.ProfesorId = grupoModel.ProfesorId;
                    db.Entry(grupo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Grupo grupo = db.Grupos.Find(id);
                    db.Grupos.Remove(grupo);
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
