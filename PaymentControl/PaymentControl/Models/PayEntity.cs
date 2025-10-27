using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentControl.Models
{
    public class PayEntity : BaseEntity
    {
        public int UserId { get; set; }
        public int? DueId { get; set; }
        public TipoDePago TipoDePago { get; set; }
        public decimal Importe { get; set; }

    }
    public enum TipoDePago
    {
        Bizum,
        Efectivo,
        Transferencia
    }

}
