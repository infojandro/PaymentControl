using PaymentControl.Data.Repository;
using PaymentControl.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace PaymentControl.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private readonly UserRepository _userRepository;
        private readonly PayRepository _payRepository;


        public ObservableCollection<UserEntity> Usuarios { get; set; } = new();

        // Comandos
        public ICommand AddUserCommand { get; }
        public ICommand EditUserCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public UsersViewModel(UserRepository userRepository, PayRepository payRepository)
        {
            _userRepository = userRepository;
            _payRepository = payRepository;

            AddUserCommand = new Command(async () => await AddUserAsync());
            EditUserCommand = new Command<UserEntity>(async u => await EditUserAsync(u));
            DeleteUserCommand = new Command<UserEntity>(async u => await DeleteUserAsync(u));

            LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            var usuarios = await _userRepository.GetAllAsync();
            var pagos = await _payRepository.GetAllAsync();
            var inicioMes = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Usuarios.Clear();
            foreach (var user in usuarios)
            {
                // Buscar pago del usuario en el mes actual
                var pagoMes = pagos.FirstOrDefault(p => p.UserId == user.Id && p.FechaAlta >= inicioMes);
                user.PagoMesActual = pagoMes?.FechaAlta;
                Usuarios.Add(user);
            }
        }


        private async Task AddUserAsync()
        {
            // Abrir modal o página para crear usuario
            var newUser = new UserEntity { Nombre = "Nuevo Usuario", Alias = "nombre" };
            await _userRepository.SaveAsync(newUser);
            Usuarios.Add(newUser);
        }

        private async Task EditUserAsync(UserEntity user)
        {
            if (user == null) return;
            // Abrir modal o página para editar usuario
            user.Nombre += " (editado)";
            await _userRepository.SaveAsync(user);
            await LoadUsersAsync();
        }

        private async Task DeleteUserAsync(UserEntity user)
        {
            if (user == null) return;
            await _userRepository.DeleteAsync(user);
            Usuarios.Remove(user);
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
