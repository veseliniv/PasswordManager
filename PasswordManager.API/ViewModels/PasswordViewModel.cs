﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PasswordManager.API.Models;
using PasswordManager.API.Utils.DataPersisters;
using System.Collections.ObjectModel;

namespace PasswordManager.API.ViewModels
{
    public partial class PasswordViewModel : ObservableObject
    {
        [ObservableProperty]
        private PasswordModel newPassword = new(); 
        
        [ObservableProperty]
        private string genPass;

        [ObservableProperty]
        private ObservableCollection<PasswordModel> passwords = [.. PasswordDataPersister.GetPasswords().Result];

        [RelayCommand]
        async Task GetPasswords() => Passwords =  [.. await PasswordDataPersister.GetPasswords()];

        [RelayCommand]
        async Task  GeneratePassword()
        {
            GenPass = await PasswordDataPersister.GetRandomGeneratedPassword(); 
        }

        [RelayCommand]
        void AddPassword()
        {
            NewPassword.Pass = GenPass;

            if (!string.IsNullOrEmpty(NewPassword.Pass) && !string.IsNullOrEmpty(NewPassword.SiteName))
            {
                PasswordDataPersister.AddPassword(NewPassword);
                GetPasswords();
                Shell.Current.DisplayAlert("Success", "Password added successfully", "OK");
            }
            else
            {
                if (string.IsNullOrEmpty(NewPassword.Pass) && !string.IsNullOrEmpty(NewPassword.SiteName))
                {
                    Shell.Current.DisplayAlert("Password", "Password field isn't filled", "OK");
                }
                else if (string.IsNullOrEmpty(NewPassword.SiteName) && !string.IsNullOrEmpty(NewPassword.Pass))
                {
                    Shell.Current.DisplayAlert("Site Name", "Site Name field isn't filled", "OK");
                }
                else
                {
                    Shell.Current.DisplayAlert("New Password", "Fill the required fields: Password and Site Name", "OK");
                }
            }
        }
       
    }
}
