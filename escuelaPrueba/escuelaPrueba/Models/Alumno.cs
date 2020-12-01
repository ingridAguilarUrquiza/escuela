using System;
using System.Collections.Generic;

namespace escuelaPrueba.Models
{
    public partial class Alumno
    {
        public Alumno()
        {
            Alumnosalon = new HashSet<Alumnosalon>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public int? Edad { get; set; }
        public string Genero { get; set; }

        public virtual ICollection<Alumnosalon> Alumnosalon { get; set; }
    }
}
