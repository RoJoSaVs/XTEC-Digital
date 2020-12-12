﻿using System;
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
    public class rubrosController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    var list = (from d in db.Rubros
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
                    Rubro rubro = db.Rubros.Find(id);
                    return Ok(rubro);
                }
            }
            catch
            {
                return BadRequest("Elemento no encontrado");
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] Rubro rubroModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Rubro rubro = new Rubro();
                    rubro.RubroId = rubroModel.RubroId;
                    rubro.Nombre = rubroModel.Nombre;
                    rubro.Porcentaje = rubroModel.Porcentaje;
                    rubro.GrupoId = rubroModel.GrupoId;
                    db.Rubros.Add(rubro);
                    db.SaveChanges();
                }
                return Ok("Rubro agregado");
            }
            catch
            {
                return BadRequest("No se pudo agregar el elemento");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Rubro rubroModel)
        {
            try
            {
                using (XTEC_DigitalContext db = new XTEC_DigitalContext())
                {
                    Rubro rubro = db.Rubros.Find(id);
                    rubro.Nombre = rubroModel.Nombre;
                    rubro.Porcentaje = rubroModel.Porcentaje;
                    rubro.GrupoId = rubroModel.GrupoId;
                    db.Entry(rubro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
                    Rubro rubro = db.Rubros.Find(id);
                    db.Rubros.Remove(rubro);
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
