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
    public class archivosController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Archivos
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
                    Archivo archivo = db.Archivos.Find(id);
                    return Ok(archivo);
                }
            }
            catch
            {
                return BadRequest("No se pudo obtener el elemento");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Archivo archivoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Archivo archivo = new Archivo();
                    archivo.ArchivoId = archivoModel.ArchivoId;
                    archivo.Nombre = archivoModel.Nombre;
                    archivo.ArchivoPdf = archivoModel.ArchivoPdf;
                    archivo.Tamanio = archivoModel.Tamanio;
                    archivo.Fecha = archivoModel.Fecha;
                    archivo.CarpetaId = archivoModel.CarpetaId;
                    db.Archivos.Add(archivo);
                    db.SaveChanges();
                }
                return Ok("Archivo agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el archivo");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Archivo archivoModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Archivo archivo = db.Archivos.Find(id);
                    archivo.ArchivoId = archivoModel.ArchivoId;
                    archivo.Nombre = archivoModel.Nombre;
                    archivo.ArchivoPdf = archivoModel.ArchivoPdf;
                    archivo.Tamanio = archivoModel.Tamanio;
                    archivo.Fecha = archivoModel.Fecha;
                    archivo.CarpetaId = archivoModel.CarpetaId;
                    db.Entry(archivo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
                return Ok("Archivo actualizado");
            }
            catch
            {
                return BadRequest("Archivo no actualizado");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Archivo archivo = db.Archivos.Find(id);
                    db.Archivos.Remove(archivo);
                    db.SaveChanges();
                }
                return Ok("Eliminacion realizada");
            }
            catch
            {
                return BadRequest("No se pudo eliminar el archivo");
            }
        }
    }
}
