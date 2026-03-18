using KasatotFireBase.Models;
using KasatotFireBase.Views;

namespace KasatotFireBase
{
    public partial class App : Application
    {
        private Page _page;
		public AppUser? CurrentUser { get; set; } = null;

		public App(SignInView signinpage)
        {
            InitializeComponent();
			_page = signinpage;
		}

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(_page));
        }
    }
}