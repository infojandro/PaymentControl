using PaymentControl.Models;
using SQLite;

namespace PaymentControl.Data.Repository
{
    public class DueRepository : BaseRepository<DueEntity>
    {
        public DueRepository(SQLiteAsyncConnection db) : base(db)
        {
        }

    }
}
