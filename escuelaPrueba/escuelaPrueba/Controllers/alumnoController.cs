﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using escuelaPrueba.Models;
using escuelaPrueba.Models.Reponse;
using escuelaPrueba.Models.Request;
using Microsoft.EntityFrameworkCore;
using escuelaPrueba.DTO;

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
                            var listAlumno = db.Alumno.Select(alu =>
                            new AlumnoInfo()
                            {
                                Id = alu.Id,
                                Nombre =alu.Nombre,
                                ApellidoPaterno=alu.ApellidoPaterno,
                                ApellidoMaterno=alu.ApellidoMaterno,
                                ListSalon = new List<int>()
                            }).ToList();

                            foreach (var alumno in listAlumno)
                            {
                                var relacionSalon =db.Alumnosalon.FirstOrDefault(f => f.AlumnoId == alumno.Id);
                                if (relacionSalon != null)
                                {
                                    alumno.ListSalon.Add((int)relacionSalon.SalonId);
                                }

                            }
                        orespuesta.Exito = 1;
                        orespuesta.Data = listAlumno;
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
            try
            {
                using (escuelaContext db=new escuelaContext())
                {
                    var alumno = db.Alumno.Find(id);
                    orespuesta.Exito = 1;
                    orespuesta.Data = alumno;

                }
                   
            }
            catch (Exception ex)
            {
                orespuesta.Mensaje=ex.Message;

            }
            return Ok(orespuesta);

        }
        [HttpPost]//insersion de datos a la base Escuela
            public IActionResult Add([FromBody] Alumno alumno) 
            {
                Respuesta orespuesta = new Respuesta();
                try
                {
                    using (escuelaContext db = new escuelaContext())
                    {
                        
                        db.Alumno.Add(alumno);
                        db.SaveChanges();
                        orespuesta.Exito = 1;
                    }

                }
                catch(Exception ex)
                {
                    orespuesta.Mensaje = ex.Message;
                }
                return Ok(orespuesta);
            }
            [HttpPut("{id}")]
            public IActionResult Edit(int id, [FromBody] Alumno alumno)
            {
                Respuesta orespuesta = new Respuesta();
                try
                {
                    using (escuelaContext db = new escuelaContext())
                    {
                        alumno.Id = id;
                        db.Entry(alumno).State = EntityState.Modified;
                        db.Update(alumno);
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
                        Alumno oAlumno = db.Alumno.Find(id);
                        db.Remove(oAlumno);
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


    }
}
