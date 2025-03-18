using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.API.Models;
using PasswordManager.API.Utils.DataPersisters;
using System.Collections.ObjectModel;

namespace PasswordManager.API.ViewModels
{
    public partial class SiteViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<SiteModel> sites = [.. SiteDataPersister.GetSites()];

        [RelayCommand]
        void SignInUser(object obj)
        {
            Sites = [.. SiteDataPersister.GetSites()];
        }

        [RelayCommand]
        static void AddSite(object obj)
        {
            SiteDataPersister.AddSite();
        }
    }
}
