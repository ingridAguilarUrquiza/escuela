using Microsoft.AspNetCore.Http;
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
        private readonly escuelaContext _context;

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
     }
        [HttpGet]//listado de datos
            public IActionResult Get()
            {
                Respuesta orespuesta = new Respuesta();
                orespuesta.Exito = 0;
                try
                {
                    using (escuelaContext db = new escuelaContext())
                    {
                        var lst = db.Alumno.ToList();
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
            public IActionResult Add(alumnoRequest omodel) 
            {
                Respuesta orespuesta = new Respuesta();
                try
                {
                    using (escuelaContext db = new escuelaContext())
                    {
                        Alumno oAlumno = new Alumno();
                        oAlumno.Nombre = omodel.nombre;
                        oAlumno.ApellidoPaterno = omodel.apellidoPaterno;
                        oAlumno.ApellidoMaterno = omodel.apellidoMaterno;
                        oAlumno.Telefono = omodel.telefono;
                        oAlumno.Edad = omodel.edad;
                        oAlumno.Genero = omodel.genero;
                        db.Alumno.Add(oAlumno);
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
            [HttpPut]
            public IActionResult Edit(alumnoRequest omodel)
            {
                Respuesta orespuesta = new Respuesta();
                try
                {
                    using (escuelaContext db = new escuelaContext())
                    {
                        Alumno oAlumno = db.Alumno.Find(omodel.id);
                        oAlumno.Nombre = omodel.nombre;
                        oAlumno.ApellidoPaterno = omodel.apellidoPaterno;
                        oAlumno.ApellidoMaterno = omodel.apellidoMaterno;
                        oAlumno.Telefono = omodel.telefono;
                        oAlumno.Edad = omodel.edad;
                        oAlumno.Genero = omodel.genero;
                        db.Entry(oAlumno).State = EntityState.Modified;
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
            }*/


    }
}
