using System;
using System.Collections.Generic;

namespace escuelaPrueba.Models
{
    public partial class Salon
    {
        public Salon()
        {
            Alumnosalon = new HashSet<Alumnosalon>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Alumnosalon> Alumnosalon { get; set; }
    }
}
