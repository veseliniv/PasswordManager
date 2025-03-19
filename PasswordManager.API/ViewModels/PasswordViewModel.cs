using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.API.Models;
using PasswordManager.API.Utils.DataPersisters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.API.ViewModels
{
    public partial class PasswordViewModel : ObservableObject
    {
        [ObservableProperty]
        string sitename;

        [ObservableProperty]
        string pass;

        [ObservableProperty]
        ObservableCollection<PasswordModel> passwords = [.. PasswordDataPersister.GetPasswords()];

        [RelayCommand]
        void GetPasswords() => Passwords = [.. PasswordDataPersister.GetPasswords()];

        [RelayCommand]
        void AddPassword()
        {
            PasswordDataPersister.AddPassword(Pass, Sitename);
            GetPasswords();
        }
       
    }
}
