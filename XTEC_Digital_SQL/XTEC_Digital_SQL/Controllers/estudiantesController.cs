using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XTEC_Digital_SQL.Models;
using XTEC_Digital_SQL.Models.MongoModels;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XTEC_Digital_SQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class estudiantesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Estudiantes
                                select d).ToList();
                    return Ok(list);
                }
            }
            catch
            {
                return BadRequest("Informacion no obtenida");
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Estudiante estudiante = db.Estudiantes.Find(id);
                    return Ok(estudiante);
                }
            }
            catch
            {
                return BadRequest("Informacion no encontrada");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Estudiante estudianteModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Estudiante estudiante = new Estudiante();
                    estudiante.Carnet = estudianteModel.Carnet;
                    db.Estudiantes.Add(estudiante);
                    db.SaveChanges();
                }
                return Ok("Estudiante agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el estudiante");
            }
        }

        /*[HttpPut("{id}")]
        public void Put(string id, [FromBody] Curso cursoModel)
        {
            using (XTEC_DigitalContext db = new XTEC_DigitalContext())
            {
                Estudiante estudiante= db.Estudiantes.Find(id);
                
                db.Entry(estudiante).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Estudiante estudiante = db.Estudiantes.Find(id);
                    db.Estudiantes.Remove(estudiante);
                    db.SaveChanges();
                }
                return Ok("Eliminacion realizada");
            }
            catch
            {
                return BadRequest("Eliminacion no realizada");
            }
        }

        [HttpGet("test")]
        public ActionResult TestSync()
        {
            try
            {
                List<EstudianteMongo> estudianteMongos = new List<EstudianteMongo>();
                List<Estudiante> estudiantes = new List<Estudiante>();
                
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    estudiantes = (from d in db.Estudiantes
                                select d).ToList();
                    var response = GetAsync("http://xtecmongodb.azurewebsites.net/api/estudiante/info/all");
                    var result = response.Result;
                    if (result != null)
                    {
                        estudianteMongos = JsonConvert.DeserializeObject<List<EstudianteMongo>>(result);
                    }
                    foreach (var estudianteMongo in estudianteMongos)
                    {
                        Estudiante estudiante = db.Estudiantes.Find(estudianteMongo.Carnet);
                        if (estudiante == null)
                        {
                            Estudiante estudianteInsert = new Estudiante();
                            estudianteInsert.Carnet = estudianteMongo.Carnet;
                            db.Estudiantes.Add(estudianteInsert);
                            db.SaveChanges();
                        }
                    }
                return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        public async Task<string> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var content = await httpClient.GetStringAsync(uri);
            return content;
        }
    }
}
