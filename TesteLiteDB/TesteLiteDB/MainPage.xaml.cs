using TesteLiteDB.ViewModels;
using Xamarin.Forms;

namespace TesteLiteDB
{
    public partial class MainPage : ContentPage
    {
        readonly Class1ViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new Class1ViewModel();
        }
    }
}
