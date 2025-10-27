using PaymentControl.Models;
using SQLite;

namespace PaymentControl.Data.Repository
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(SQLiteAsyncConnection db) : base(db)
        {
        }
    }
}
