using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaymentControl.Data;
using PaymentControl.Data.Repository;
using PaymentControl.Models;
using PaymentControl.ViewModels;
using SQLite;

namespace PaymentControl
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Ruta donde se guardará el archivo SQLite
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PaymentControl.db3");

            // Crear una sola conexión SQLiteAsyncConnection compartida
            var sqliteConnection = new SQLiteAsyncConnection(dbPath);

            // Repositorios inyectados como Singleton
            builder.Services.AddSingleton(sqliteConnection);
            builder.Services.AddSingleton(s => new BaseRepository<UserEntity>(sqliteConnection));
            builder.Services.AddSingleton(s => new BaseRepository<DueEntity>(sqliteConnection));
            builder.Services.AddSingleton(s => new BaseRepository<PayEntity>(sqliteConnection));

            // Repositorios específicos
            builder.Services.AddSingleton<UserRepository>(s => new UserRepository(sqliteConnection));
            builder.Services.AddSingleton<DueRepository>(s => new DueRepository(sqliteConnection));
            builder.Services.AddSingleton<PayRepository>(s => new PayRepository(sqliteConnection));


            // AppDatabase opcional (si quieres inicializar tablas y datos por defecto)
            builder.Services.AddSingleton(s => new AppDatabase(sqliteConnection));

            // ViewModels
            builder.Services.AddTransient<UsersViewModel>();
            builder.Services.AddTransient<DuesViewModel>();
            builder.Services.AddTransient<PaymentsViewModel>();

            // Páginas
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<Views.UsersPage>();
            builder.Services.AddTransient<Views.DuesPage>();
            builder.Services.AddTransient<Views.PaymentsPage>();

            return builder.Build();
        }
    }   
}
