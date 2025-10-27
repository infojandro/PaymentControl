using PaymentControl.Models;
using SQLite;

namespace PaymentControl.Data.Repository
{
    public class PayRepository : BaseRepository<PayEntity>
    {
        public PayRepository(SQLiteAsyncConnection db) : base(db)
        {
        }

    }
}
