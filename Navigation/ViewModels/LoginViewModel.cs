using System.Windows.Input;
using Navigation.Helper;
using NavigationService = Navigation.Helper.NavigationService;

namespace Navigation.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public DashboardViewModel DashboardViewModel { get; set; }
        private readonly NavigationService navigationService;
        public string Message { get; set; }
        public LoginViewModel(NavigationService navigation)
        {
            navigationService = navigation;
            Message = "Welcome";
            OnPropertyChanged(nameof(Message));
        }
        public ICommand LoginCommand => new RelayCommand(() =>
        {
            if (DashboardViewModel is null)
            {
                DashboardViewModel = new DashboardViewModel(navigationService);
                navigationService.RegisterViewModel("Dashboard", DashboardViewModel); 
            }
            navigationService.NavigateTo("Dashboard");
            NotifyChanges();
        });

        public void ShowLogoutMessage()
        {
            Message = "Successfully Logged out.";
            OnPropertyChanged(nameof(Message));
        }
    }
}
