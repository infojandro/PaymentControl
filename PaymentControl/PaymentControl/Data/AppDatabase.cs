using PaymentControl.Models;
using SQLite;

namespace PaymentControl.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _db;

        public AppDatabase(SQLiteAsyncConnection connection)
        {
            _db = connection;
        }

        // Inicialización de tablas
        public async Task InitializeAsync()
        {
            await _db.CreateTableAsync<UserEntity>();
            await _db.CreateTableAsync<DueEntity>();
            await _db.CreateTableAsync<PayEntity>();
        }

        public Task<List<T>> GetAllAsync<T>() where T : new()
            => _db.Table<T>().ToListAsync();

        public Task<int> SaveAsync<T>(T item) where T : BaseEntity, new()
        {
            item.FechaActualizacion = DateTime.Now;
            return _db.InsertOrReplaceAsync(item);
        }

        public Task<int> DeleteAsync<T>(T item) where T : new()
            => _db.DeleteAsync(item);

        public async Task SeedDataAsync()
        {
            // Solo insertar si no existen datos
            var usuarios = await GetAllAsync<UserEntity>();
            if (usuarios.Count == 0)
            {
                await SaveAsync(new UserEntity { Nombre = "Pilar", Alias = "Pili", CuotaId = 1 });
                await SaveAsync(new UserEntity { Nombre = "Pilar", Alias = "Pilar", CuotaId = 1 });
            }

            var cuotas = await GetAllAsync<DueEntity>();
            if (cuotas.Count == 0)
            {
                await SaveAsync(new DueEntity { Descripcion = "1 Actividad", ImporteCuota = 30 });
                await SaveAsync(new DueEntity { Descripcion = "2 Actividades", ImporteCuota = 50 });
                await SaveAsync(new DueEntity { Descripcion = "Clase Suelta", ImporteCuota = 14 });
                await SaveAsync(new DueEntity { Descripcion = "Clase Prueba", ImporteCuota = 8 });
            }
        }

    }
}
