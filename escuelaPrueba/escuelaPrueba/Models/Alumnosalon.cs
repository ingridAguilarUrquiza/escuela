using System;
using System.Collections.Generic;

namespace escuelaPrueba.Models
{
    public partial class Alumnosalon
    {
        public int Id { get; set; }
        public int? AlumnoId { get; set; }
        public int? SalonId { get; set; }
        public bool? Activo { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Salon Salon { get; set; }
    }
}
