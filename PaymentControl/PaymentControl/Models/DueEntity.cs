using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentControl.Models
{
    public class DueEntity : BaseEntity
    {
        public string Descripcion { get; set; }
        public decimal ImporteCuota { get; set; }
    }
}
