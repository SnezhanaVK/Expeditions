using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project
{
    class MainViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dateWork;
        public ViewModelBase CurrentViewModel => _viewModelStore.CurrentViewModel;
        public MainViewModel(ViewModelStore viewModelStore, DataWork dateWork)
        {
            _viewModelStore = viewModelStore;
            _viewModelStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _dateWork = dateWork;
        }
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
