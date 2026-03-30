using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KasatotFireBase.Models;
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
		IAppUserRepository _dbService;
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

		public SignInViewModel(IAppUserRepository dbService, SignUpView signUpPage) 
        {
            _signUpPage = signUpPage;
			_dbService = dbService; // Injection from DIC Conteiner                                      

            //Debug Mode
            UserEmail = "kon@yahoo.com";
            UserPassword = "123456";
        
        }

        [RelayCommand]
        private async Task SignIn()
        {      
            try
            {
				IsBusy = true; //Show lock screen
				AppUser user = await _dbService.SignInAsync(UserEmail, UserPassword);

				IsBusy = false;

				//SignIn Success, add user to Current user Session
				(App.Current as App)!.CurrentUser = user;

				//Navigate to MainPage
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
