using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escuelaPrueba.DTO
{
    public class AlumnoInfo
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public List<int> ListSalon { get; set; }
    }
}
