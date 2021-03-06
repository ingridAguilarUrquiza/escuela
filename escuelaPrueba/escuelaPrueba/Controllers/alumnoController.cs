﻿using escuelaPrueba.DTO;
using escuelaPrueba.Models;
using escuelaPrueba.Models.Reponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace escuelaPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        /*private readonly escuelaContext _context;

        public AlumnoController(escuelaContext context)
        {
            _context = context;

        }
        [HttpGet]//listado de alumnos 2da forma 
        public ActionResult<List<Alumno>> Get()
        {
            try
            {
                var listAlumno = _context.Alumno.Select(alu =>
                new AlumnoInfo() { 
                Id=alu.Id,
                NombreCompleto=alu.Nombre+" "+alu.ApellidoPaterno+" "+alu.ApellidoMaterno,
                ListSalon=new List<int>()
                }).ToList();

                foreach (var alumno in listAlumno )
                {
                    var relacionSalon= _context.Alumnosalon.FirstOrDefault(f =>f.AlumnoId == alumno.Id);
                    if (relacionSalon != null)
                    {
                        alumno.ListSalon.Add((int)relacionSalon.SalonId);
                    }
                   
                }
                return Ok(listAlumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            try
            {
                var alumno = _context.Alumno.Find(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Alumno alumno)
        {
            try
            {
                _context.Add(alumno);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(int id,[FromBody] Alumno alumno)
        {
            try
            {
                if (id==0)
                {
                    return BadRequest();
                }
                alumno.Id = id;
                _context.Entry(alumno).State=EntityState.Modified;
                _context.Update(alumno);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var alumno = _context.Alumno.Find(id);
                if (alumno == null)
                {
                    return NotFound();
                }
                _context.Remove(alumno);
                _context.SaveChanges();
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        
       /* public async Task<List<Alumno>> Get()
     {
         try
         {
             var listAlumno =await _context.Alumno.Include(x => x.Alumnosalon).ToListAsync();
             return listAlumno;
         }
         catch (Exception ex)
         {
             return null;

         }
     }*/
        [HttpGet]//listado de datos
        public IActionResult Get()
        {
            Respuesta orespuesta = new Respuesta();
            orespuesta.Exito = 0;
            try
            {
                using (escuelaContext db = new escuelaContext())
                {

                    var datos = (from alumno in db.Alumno
                                 join status in db.Alumnosalon on alumno.Id equals status.AlumnoId
                                 where status.Activo == true
                                 select alumno).ToList().Select(alu =>
                                 new AlumnoInfo()
                                 {
                                     Id = alu.Id,
                                     Nombre = alu.Nombre,
                                     ApellidoPaterno = alu.ApellidoPaterno,
                                     ApellidoMaterno = alu.ApellidoMaterno,
                                     ListSalon = new List<SalonDto>()
                                 }).ToList();
                    foreach (var alumno in datos)
                    {
                        var relacionSalon = db.Alumnosalon.Include("Salon").FirstOrDefault(f => f.AlumnoId == alumno.Id);
                        if (relacionSalon != null)
                        {
                            alumno.ListSalon.Add(new SalonDto()
                            {
                                Id = relacionSalon.Salon.Id,
                                Nombre = relacionSalon.Salon.Nombre
                            });
                        }
                    }
                    orespuesta.Exito = 1;
                    orespuesta.Data = datos;
                }
            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
        [HttpGet("{id}")]
        public ActionResult<RelacionAlumnoSalon> Get(int id)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    var alumno = db.Alumnosalon.Include(x => x.Alumno).Include(x => x.Salon).FirstOrDefault(f => f.AlumnoId == id);
                    RelacionAlumnoSalon response = new RelacionAlumnoSalon();
                    response.id = alumno.Alumno.Id;
                    response.nombre = alumno.Alumno.Nombre;
                    response.apellidoPaterno = alumno.Alumno.ApellidoPaterno;
                    response.apellidoMaterno = alumno.Alumno.ApellidoMaterno;
                    response.telefono = alumno.Alumno.Telefono;
                    response.edad = (int)alumno.Alumno.Edad;
                    response.genero = alumno.Alumno.Genero;
                    response.idSalon = alumno.Salon.Id;
                    response.nombreSalon = alumno.Salon.Nombre;

                    orespuesta.Exito = 1;
                    orespuesta.Data = response;
                    

                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;

            }
            return Ok(orespuesta);

        }
        [HttpPost]//insersion de datos a la base Escuela
        public IActionResult Add([FromBody] RelacionAlumnoSalon alumno)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    
                    var nuevoAlumno = new Alumno();
                    nuevoAlumno.Nombre = alumno.nombre;
                    nuevoAlumno.ApellidoPaterno = alumno.apellidoPaterno;
                    nuevoAlumno.ApellidoMaterno = alumno.apellidoMaterno;
                    nuevoAlumno.Telefono = alumno.telefono;
                    nuevoAlumno.Edad = alumno.edad;
                    nuevoAlumno.Genero = alumno.genero;

                    db.Alumno.Add(nuevoAlumno);
                    db.SaveChanges();
                    var salon = (from sa in db.Salon where sa.Nombre == alumno.nombreSalon select sa).FirstOrDefault<Salon>();

                    var nuevoAlumnoSalon = new Alumnosalon();
                    nuevoAlumnoSalon.AlumnoId = nuevoAlumno.Id;
                    nuevoAlumnoSalon.SalonId = salon.Id;
                    nuevoAlumnoSalon.Activo = true;
                    db.Alumnosalon.Add(nuevoAlumnoSalon);
                    db.SaveChanges();
                    orespuesta.Exito = 1;
                    orespuesta.Data = nuevoAlumno;
                }

            }
            catch (Exception ex)
            {
                orespuesta.Mensaje = ex.Message;
            }
            return Ok(orespuesta);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] RelacionAlumnoSalon alumno)
        {
            Respuesta orespuesta = new Respuesta();
            try
            {
                using (escuelaContext db = new escuelaContext())
                {
                    Alumno editarAlumno = db.Alumno.Find(id);
                    editarAlumno.Nombre = alumno.nombre;
                    editarAlumno.ApellidoPaterno = alumno.apellidoPaterno;
                    editarAlumno.ApellidoMaterno = alumno.apellidoMaterno;
                    editarAlumno.Telefono = alumno.telefono;
                    editarAlumno.Edad = alumno.edad;
                    editarAlumno.Genero = alumno.genero;
                    db.Entry(editarAlumno).State = EntityState.Modified;
                    db.Update(editarAlumno);
                    db.SaveChanges();

                    var salon = (from sa in db.Salon where sa.Nombre == alumno.nombreSalon select sa).FirstOrDefault<Salon>();

                    Alumnosalon editarSalonAlumno = db.Alumnosalon.Find(salon.Id);
                    editarSalonAlumno.SalonId = salon.Id;
                    db.Entry(editarSalonAlumno).State = EntityState.Modified;
                    db.Update(editarSalonAlumno);
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
                        var borradoLogico = (from cambioActivo in db.Alumnosalon where cambioActivo.AlumnoId == id select cambioActivo).FirstOrDefault<Alumnosalon>();
                        //return Ok(borradoLogico);
                        if (borradoLogico != null)
                        {
                            Alumnosalon borrarAlumno = db.Alumnosalon.Find(borradoLogico.Id);
                            borrarAlumno.Activo = default(bool);
                            db.Entry(borrarAlumno).State = EntityState.Modified;
                            db.Update(borrarAlumno);
                            db.SaveChanges();
                            orespuesta.Exito = 1;
                        }
                        else
                        {
                            var alumno = db.Alumno.Find(id);
                            if (alumno != null)
                            {
                                db.Remove(alumno);
                                db.SaveChanges();
                                orespuesta.Exito = 1;
                            }

                        }

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
