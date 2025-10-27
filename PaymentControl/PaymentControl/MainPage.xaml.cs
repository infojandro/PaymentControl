using PaymentControl.Data;
using PaymentControl.Models;

namespace PaymentControl
{
    public partial class MainPage : ContentPage
    {
        private readonly BaseRepository<UserEntity> _userRepo;
        private readonly Views.UsersPage _usersPage;
        private readonly Views.DuesPage _duesPage;
        private readonly Views.PaymentsPage _paymentsPage;

        public MainPage(
            BaseRepository<UserEntity> userRepo,
            Views.UsersPage usersPage,
            Views.DuesPage duesPage,
            Views.PaymentsPage paymentsPage)
        {
            InitializeComponent();

            _userRepo = userRepo;
            _usersPage = usersPage;
            _duesPage = duesPage;
            _paymentsPage = paymentsPage;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var usuarios = await _userRepo.GetAllAsync();
            listaUsuarios.ItemsSource = usuarios;
        }

        private async void OnUsuariosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_usersPage);
        }

        private async void OnCuotasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_duesPage);
        }

        private async void OnPagosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(_paymentsPage);
        }
    }
}
