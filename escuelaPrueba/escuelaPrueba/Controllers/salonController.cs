using escuelaPrueba.Models;
using escuelaPrueba.Models.Reponse;
using escuelaPrueba.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escuelaPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        [HttpGet]//listado de datos
        public IActionResult Get()
        {
            Respuesta orespuesta = new Respuesta();
            orespuesta.Exito = 0;
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    var lst = db.Salon.ToList();
                    orespuesta.Exito = 1;
                    orespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
        [HttpPost]//insersion de datos a la base Escuela
        public IActionResult Add(salonRequest omodel)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    Salon oSalon = new Salon();
                    oSalon.Nombre = omodel.nombre;
                    oSalon.Descripcion = omodel.descripcion;
                    db.Salon.Add(oSalon);
                    db.SaveChanges();
                    orespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
        [HttpPut]
        public IActionResult Edit(salonRequest omodel)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    Salon oSalon = db.Salon.Find(omodel.id);
                    oSalon.Nombre = omodel.nombre;
                    oSalon.Descripcion = omodel.descripcion;
                    db.Entry(oSalon).State = EntityState.Modified;
                    db.SaveChanges();
                    orespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    Salon oSalon = db.Salon.Find(id);
                    db.Remove(oSalon);
                    db.SaveChanges();
                    orespuesta.Exito = 1;
                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            Respuesta orespuesta = new Respuesta();
            orespuesta.Exito = 0;
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    var lst = db.Salon.Find(id);
                    orespuesta.Exito = 1;
                    orespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
    }
}
