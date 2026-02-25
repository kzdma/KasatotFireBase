using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KasatotFireBase.Service;
using KasatotFireBase.Service.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasatotFireBase.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {
        private FirebaseAuthService _authService;

        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private string _errorMessage;
        [ObservableProperty]
        private string _userEmail;
        [ObservableProperty]
        private string _userPassword;

        public SignInViewModel() 
        {
            _authService = new FirebaseAuthService(new LogService());

            //Debug Mode
            UserEmail = "admin@gmail.com";
            UserPassword = "123456";
        
        }

        [RelayCommand]
        private async Task SignIn()
        {      
            try
            {
                IsBusy = true; //Show lock screen
                string userId = await _authService.SignIn(UserEmail, UserPassword);

                IsBusy = false;
				Application.Current!.Windows[0].Page = new AppShell();
            }
            catch (Exception ex)
            {
				IsBusy = false;
				ErrorMessage = ex.Message;
                //await Shell.Current.DisplayAlert("SignIn",ex.Message, "Cancel");
            }        
        }
    }
}
