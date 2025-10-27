using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentControl.Models
{
    public class UserEntity : BaseEntity
    {
        public string Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Alias { get; set; }
        public string? Email { get; set; }
        public int? CuotaId { get; set; }
        public DateTime? PagoMesActual { get; set; }

    }
}
