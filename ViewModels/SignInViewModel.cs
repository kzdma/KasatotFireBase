using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KasatotFireBase.Service;
using KasatotFireBase.Service.DBService;
using KasatotFireBase.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasatotFireBase.ViewModels
{
    public partial class SignInViewModel : ObservableObject
    {
        private IAuthService _authService;
        private Page _signUpPage;

        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private string _errorMessage;
        [ObservableProperty]
        private string _userEmail;
        [ObservableProperty]
        private string _userPassword;

		public INavigation Navigation { get; set; }

		public SignInViewModel(IAuthService authService, SignUpView signUpPage) 
        {
            _signUpPage = signUpPage;
			_authService = authService; // Injection from DIC Conteiner
                                        // new FirebaseAuthService(new LogService());

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

		[RelayCommand]
        private async Task NavigateToSignUp()
        {
			//Application.Current!.Windows[0].Page = _signUpPage;
			try
			{
				await Navigation!.PushAsync(_signUpPage);
			}
			catch (Exception ex)
			{
				var message = ex.Message;
			}
		}
	}
}
