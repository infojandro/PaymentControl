using PaymentControl.Data.Repository;
using PaymentControl.ViewModels;

namespace PaymentControl.Views
{
    public partial class DuesPage : ContentPage
    {
        public DuesPage(DueRepository dueRepository)
        {
            InitializeComponent();
            BindingContext = new DuesViewModel(dueRepository);

        }

    }
}
