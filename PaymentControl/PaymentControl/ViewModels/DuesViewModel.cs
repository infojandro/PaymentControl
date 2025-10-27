using PaymentControl.Data.Repository;
using PaymentControl.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PaymentControl.ViewModels
{
    public class DuesViewModel : INotifyPropertyChanged
    {
        private readonly DueRepository _dueRepository;

        public ObservableCollection<DueEntity> Cuotas { get; set; } = new();

        // Comandos
        public ICommand AddDueCommand { get; }
        public ICommand EditDueCommand { get; }
        public ICommand DeleteDueCommand { get; }

        public DuesViewModel(DueRepository dueRepository)
        {
            _dueRepository = dueRepository;

            AddDueCommand = new Command(async () => await AddDueAsync());
            EditDueCommand = new Command<DueEntity>(async d => await EditDueAsync(d));
            DeleteDueCommand = new Command<DueEntity>(async d => await DeleteDueAsync(d));

            LoadDuesAsync();
        }

        private async Task LoadDuesAsync()
        {
            var cuotas = await _dueRepository.GetAllAsync();
            Cuotas.Clear();
            foreach (var due in cuotas)
                Cuotas.Add(due);
        }

        private async Task AddDueAsync()
        {
            var nuevaCuota = new DueEntity
            {
                Descripcion = "Nueva Cuota",
                ImporteCuota = 0
            };
            await _dueRepository.SaveAsync(nuevaCuota);
            Cuotas.Add(nuevaCuota);
        }

        private async Task EditDueAsync(DueEntity due)
        {
            if (due == null) return;
            due.Descripcion += " (editado)";
            await _dueRepository.SaveAsync(due);
            await LoadDuesAsync();
        }

        private async Task DeleteDueAsync(DueEntity due)
        {
            if (due == null) return;
            await _dueRepository.DeleteAsync(due);
            Cuotas.Remove(due);
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
