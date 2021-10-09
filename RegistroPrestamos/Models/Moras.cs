using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroPrestamos.Models
{
    public class Moras
    {
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }

        public virtual ICollection<MorasDetalle> MorasDetalle { get; set; }

        Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            Total = 0;
            MorasDetalle = new HashSet<MorasDetalle>();
        }
    }
}
