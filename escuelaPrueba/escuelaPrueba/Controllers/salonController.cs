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
        /*[HttpPut]
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
        }*/
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Salon salon)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    salon.Id = id;
                    db.Entry(salon).State = EntityState.Modified;
                    db.Update(salon);
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
                    //return Ok(id);
                    var borradoLogico = (from cambioActivo in db.Alumnosalon where cambioActivo.SalonId == id select cambioActivo).FirstOrDefault<Alumnosalon>();
                    //return Ok(borradoLogico);
                    if (borradoLogico != null)
                    {
                        Alumnosalon borrarSalon = db.Alumnosalon.Find(borradoLogico.Id);
                        borrarSalon.Activo = default(bool);
                        db.Entry(borrarSalon).State = EntityState.Modified;
                        db.Update(borrarSalon);
                        db.SaveChanges();
                        orespuesta.Exito = 1;
                    }
                    else
                    {
                        var salon = db.Salon.Find(id);
                        if (salon != null)
                        {
                            db.Remove(salon);
                            db.SaveChanges();
                            orespuesta.Exito = 1;
                        }

                    }


                    /*Salon oSalon = db.Salon.Find(id);
                    db.Remove(oSalon);
                    db.SaveChanges();
                    orespuesta.Exito = 1;*/
                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }

        [HttpGet("{id}")]
        public ActionResult<Salon> Get(int id)
        {
            Respuesta orespuesta = new Respuesta();
      
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    //var datos= from salon in db.Salon.Include("Alumno").Include("Alumnosalon").Where salon
                   var lst = db.Salon.Find(id);
                    var listadoAlumno = (from alumno in db.Alumno
                                         join relacionAlumno in db.Alumnosalon on alumno.Id equals relacionAlumno.AlumnoId
                                         where relacionAlumno.SalonId == lst.Id
                                         select new
                                         {
                                             IdSalon = lst.Id,
                                             NombreSalon = lst.Nombre,
                                             DescripcionSalon = lst.Descripcion,
                                             NombreCompletoAlumno = alumno.Nombre.ToString() + " " + alumno.ApellidoPaterno.ToString() + " " + alumno.ApellidoMaterno.ToString(),
                                             NumeroTelefono = alumno.Telefono,
                                             Edad = alumno.Edad,
                                             Genero = alumno.Genero,
                                             StatusAlumno = relacionAlumno.Activo
                                         }).ToList();
                    /*foreach ( var dato in listadoAlumno) 
                    {
                        var datos = dato.NombreCompletoAlumno + " " + dato.NombreSalon;
                    }*/
                    orespuesta.Exito = 1;
                    orespuesta.Data = listadoAlumno;

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
