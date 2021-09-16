using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamos.Models
{
    public class Prestamos
    {
        [Key]
        public int PrestamoId { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el concepto")]
        public string Concepto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el monto")]
        public double Monto { get; set; }

        [Required(ErrorMessage = "Es obligatorio introducir el balance")]
        public double Balance { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Prestamos()
        {
            PrestamoId = 0;
            Concepto = string.Empty;
            Monto = 0;
            Balance = 0;
            FechaCreacion = DateTime.Now;
            PersonaId = new List<Personas>();
        }

        [ForeignKey("PrestamosId")]
        public virtual List<Personas> PersonaId { get; set; }

    }
}
