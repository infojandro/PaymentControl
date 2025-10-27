using PaymentControl.Models;
using SQLite;

namespace PaymentControl.Data;

public class BaseRepository<T> where T : BaseEntity, new()
{
    private readonly SQLiteAsyncConnection _db;

    public BaseRepository(SQLiteAsyncConnection db)
    {
        _db = db;
        _db.CreateTableAsync<T>().Wait();
    }

    public Task<List<T>> GetAllAsync() => _db.Table<T>().ToListAsync();

    public Task<T> GetByIdAsync(int id) => _db.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();

    public Task<int> SaveAsync(T entity)
    {
        entity.FechaActualizacion = DateTime.Now;
        return _db.InsertOrReplaceAsync(entity);
    }

    public Task<int> DeleteAsync(T entity) => _db.DeleteAsync(entity);
}
