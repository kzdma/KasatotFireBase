using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KasatotFireBase.Service;
using KasatotFireBase.Service.Firebase;
using KasatotFireBase.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasatotFireBase.ViewModels
{
	public partial class SignUpViewModel : ObservableObject
	{
		private IAuthService _authService;

		[ObservableProperty]
		private bool _isBusy;
		[ObservableProperty]
		private string _errorMessage;
		[ObservableProperty]
		private string _userEmail;
		[ObservableProperty]
		private string _userPassword;

		public INavigation Navigation { get; set; }

		public SignUpViewModel(IAuthService authService)
		{
			_authService = authService;
		}

		[RelayCommand]
		private async Task SignUp()
		{
			try
			{
				IsBusy = true; //Show lock screen
				string userId = await _authService.CreateAuth(UserEmail, UserPassword);

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
		private async Task NavigateToSignIn()
		{
			//Application.Current!.Windows[0].Page = new SignInView();
			await Navigation!.PopAsync();
		}
	}
}
