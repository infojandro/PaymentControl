using SQLite;

namespace PaymentControl.Models
{
    public class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime FechaAlta { get; set; } = DateTime.Now;
        public DateTime FechaActualizacion { get; set; } = DateTime.Now;
    }
}
