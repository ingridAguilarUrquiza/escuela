using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace escuelaPrueba.DTO
{
    public class AlumnoInfo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public List<SalonDto> ListSalon { get; set; }
        //public List<AlumnoSalon> alumnoSalon { get; set; }
    }
    public class SalonDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

    }
    public class AlumnoSalon{
    public int Id { get; set; }
    public bool Activo { get; set; }
    }
    public class DatosGeneral
    {
        public int Id { get; set; }
        public string NombreSalon { get; set; }
        public string DescripcionSalon { get; set; }
        public string NombreCompletoAlumno { get; set; }
        public string NumeroTelefono { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public bool Activo { get; set; } 

    }
}
