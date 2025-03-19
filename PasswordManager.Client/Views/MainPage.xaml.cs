using PasswordManager.API.ViewModels;
using UraniumUI.Pages;

namespace PasswordManager.Client
{
    public partial class MainPage : UraniumContentPage
    {
        public MainPage(PasswordViewModel passwordViewModel)
        {
            InitializeComponent();
            BindingContext = passwordViewModel;
        }
    }

}
