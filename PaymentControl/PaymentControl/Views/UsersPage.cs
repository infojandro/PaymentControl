using PaymentControl.Data.Repository;
using PaymentControl.ViewModels;
namespace PaymentControl.Views
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage(UserRepository userRepository, PayRepository payRepository)
        {
            InitializeComponent();
            BindingContext = new UsersViewModel(userRepository, payRepository);
        }
    }

}
