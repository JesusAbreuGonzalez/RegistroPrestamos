using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamos.Models
{
    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        public int PrestamosId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la cédula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir la dirección")]
        public string Direccion { get; set; }

        public DateTime FechaNacimiento { get; set; }


        public Personas()
        {
            PersonaId = 0;
            PrestamosId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
        }
    }
}
