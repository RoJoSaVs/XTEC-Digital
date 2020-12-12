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
    public class carpetasController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Carpeta
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("No se pueden mostrar los elementos");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Carpetum carpetum = db.Carpeta.Find(id);
                    return Ok(carpetum);
                }
            }
            catch
            {
                return BadRequest("Item no encontrado");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Carpetum carpetumModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Carpetum carpetum = new Carpetum();
                    carpetum.CarpetaId = carpetumModel.CarpetaId;
                    carpetumModel.Nombre = carpetumModel.Nombre;
                    carpetumModel.RutaUrl = carpetumModel.RutaUrl;
                    carpetumModel.GrupoId = carpetumModel.GrupoId;
                    db.Carpeta.Add(carpetum);
                    db.SaveChanges();
                }
                return Ok("Carpeta agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar la carpeta");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Carpetum carpetumModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Carpetum carpetum = db.Carpeta.Find(id);
                    carpetumModel.Nombre = carpetumModel.Nombre;
                    carpetumModel.RutaUrl = carpetumModel.RutaUrl;
                    carpetumModel.GrupoId = carpetumModel.GrupoId;
                    db.Entry(carpetum).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Carpetum carpetum = db.Carpeta.Find(id);
                    db.Carpeta.Remove(carpetum);
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
