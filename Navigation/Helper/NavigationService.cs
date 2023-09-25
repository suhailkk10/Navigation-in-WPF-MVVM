using System.Collections.Generic;

namespace Navigation.Helper
{
    public class NavigationService : Observable
    {
        private readonly Dictionary<string, ViewModelBase> _viewModels;

        public NavigationService()
        {
            _viewModels = new Dictionary<string, ViewModelBase>();
        }

        public void RegisterViewModel(string key, ViewModelBase viewModel)
        {
            _viewModels[key] = viewModel;
        }
        public void UnregisterViewModel(string key)
        {
            _viewModels.Remove(key);
        }

        public ViewModelBase? GetViewModel(string key)
        {
            if (_viewModels.TryGetValue(key, out var viewModel))
                return viewModel;
            return null;
        }

        public void NavigateTo(string key)
        {
            if (_viewModels.TryGetValue(key, out var viewModel))
                CurrentViewModel = viewModel;
            NotifyChanges();
        }

        public ViewModelBase CurrentViewModel { get; private set; }
    }
}
