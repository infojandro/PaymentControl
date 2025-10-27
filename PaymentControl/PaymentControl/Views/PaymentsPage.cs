using PaymentControl.ViewModels;
using PaymentControl.Data.Repository;

namespace PaymentControl.Views;

public partial class PaymentsPage : ContentPage
{
    public PaymentsPage(PayRepository payRepository)
    {
        InitializeComponent();
        BindingContext = new PaymentsViewModel(payRepository);
    }
}
