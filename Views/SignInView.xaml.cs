using KasatotFireBase.ViewModels;

namespace KasatotFireBase.Views;

public partial class SignInView : ContentPage
{
	public SignInView()
	{
		InitializeComponent();
		BindingContext = new SignInViewModel();
	}
}