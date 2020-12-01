using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escuelaPrueba.Models.Request
{
    public class alumnoRequest
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string telefono { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
    }
}
