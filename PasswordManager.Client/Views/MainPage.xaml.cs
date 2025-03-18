using PasswordManager.API.ViewModels;
using UraniumUI.Pages;

namespace PasswordManager.Client
{
    public partial class MainPage : UraniumContentPage
    {
        public MainPage(SiteViewModel siteViewModel)
        {
            InitializeComponent();
            BindingContext = siteViewModel;
        }
    }

}
