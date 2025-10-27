using PaymentControl.Data.Repository;
using PaymentControl.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace PaymentControl.ViewModels
{
    public class PaymentsViewModel : INotifyPropertyChanged
    {
        private readonly PayRepository _payRepository;

        public ObservableCollection<PayEntity> Pagos { get; set; } = new();

        // Comandos
        public ICommand EditPayCommand { get; }
        public ICommand DeletePayCommand { get; }

        public PaymentsViewModel(PayRepository payRepository)
        {
            _payRepository = payRepository;

            EditPayCommand = new Command<PayEntity>(async p => await EditPayAsync(p));
            DeletePayCommand = new Command<PayEntity>(async p => await DeletePayAsync(p));

            LoadPaymentsAsync();
        }

        private async Task LoadPaymentsAsync()
        {
            var pagos = await _payRepository.GetAllAsync();
            Pagos.Clear();
            foreach (var pago in pagos)
                Pagos.Add(pago);
        }

        private async Task EditPayAsync(PayEntity pago)
        {
            if (pago == null) return;
            // Lógica de edición, por ejemplo abrir modal o editar en línea
            pago.Importe += 1; // Ejemplo temporal
            await _payRepository.SaveAsync(pago);
            await LoadPaymentsAsync();
        }

        private async Task DeletePayAsync(PayEntity pago)
        {
            if (pago == null) return;
            await _payRepository.DeleteAsync(pago);
            Pagos.Remove(pago);
        }

        // INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
