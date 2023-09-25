using System.Windows.Input;
using Navigation.Helper;

namespace Navigation.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        public LoginViewModel loginViewModel { get; set; }
       
        public DashboardViewModel(NavigationService navigation)
        {
            navigationService = navigation;            
        }

        public ICommand LogoutCommand => new RelayCommand(() =>
        {
            if (loginViewModel is null)
            {
                loginViewModel = new LoginViewModel(navigationService);
                navigationService.RegisterViewModel("Login", loginViewModel);
            }
            navigationService.NavigateTo("Login");
            loginViewModel.ShowLogoutMessage();
            NotifyChanges();
        });
    }
}
