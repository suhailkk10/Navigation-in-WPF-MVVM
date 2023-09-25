using Navigation.Helper;

namespace Navigation.ViewModels
{
    public class MainViewModel : Observable
    {
        public NavigationService navigationService { get; set; }
        public MainViewModel()
        {
            navigationService = new NavigationService();
            navigationService.RegisterViewModel("Login", new LoginViewModel(navigationService));
            navigationService.NavigateTo("Login");            
        }
    }
}
