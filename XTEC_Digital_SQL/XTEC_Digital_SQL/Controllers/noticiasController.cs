using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using XTEC_Digital_SQL.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class noticiasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Noticia
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
                    Noticium noticium = db.Noticia.Find(id);
                    return Ok(noticium);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public bool Post([FromBody] Noticium noticiumModel)
        //public IActionResult Post([FromBody] Noticium noticiumModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    /*Noticium noticium = new Noticium();
                    noticium.NoticiaId = noticiumModel.NoticiaId;
                    noticium.Titulo = noticiumModel.Titulo;
                    noticium.Mensaje = noticiumModel.Mensaje;
                    noticium.Fecha = noticiumModel.Fecha;
                    noticium.GrupoId = noticiumModel.GrupoId;
                    db.Noticia.Add(noticium);*/
                    db.Database.ExecuteSqlRaw("EXEC CrearNoticia {0}, {1}, {2}, {3}", 
                                        noticiumModel.GrupoId, noticiumModel.Titulo, 
                                        noticiumModel.Mensaje,noticiumModel.Autor);
                    db.SaveChanges();
                }
                    
                    return true;
                //return Ok("Noticia agregada");
            }
            catch
            {
                return false;
                //return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public bool Put(string id, [FromBody] Noticium noticiumModel)
        //public ActionResult Put(string id, [FromBody] Noticium noticiumModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Noticium noticium = db.Noticia.Find(id);
                    noticium.Titulo = noticiumModel.Titulo;
                    noticium.Mensaje = noticiumModel.Mensaje;
                    noticium.Fecha = DateTime.Now;
                    noticium.GrupoId = noticiumModel.GrupoId;
                    db.Entry(noticium).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return true;
                //return Ok("Actualizacion realizada");
            }
            catch
            {
                return false;
                //return BadRequest("No se pudo realizar la actualizacion");
            }

        }

        [HttpDelete("{id}")]
        public bool Delete(string id)
        //public ActionResult Delete(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Noticium noticium = db.Noticia.Find(id);
                    db.Noticia.Remove(noticium);
                    db.SaveChanges();
                }
                return true;
                //return Ok("Eliminacion realizada");
            }
            catch
            {
                return false;
                //return BadRequest("No se pudo eliminar el elemento");
            }
        }
    }
}
