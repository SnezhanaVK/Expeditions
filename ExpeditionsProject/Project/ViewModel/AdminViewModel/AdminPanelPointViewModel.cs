using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    internal class AdminPanelPointViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dadaWork;


        public AdminPanelPointViewModel(ViewModelStore viewModelStore, DataWork dadaWork)
        {
            _viewModelStore = viewModelStore;
            _dadaWork = dadaWork;
            TypePoint = new NavigateCommand(_viewModelStore, () => { return new CompletionPointTypePointViewModel(viewModelStore, dadaWork); });
            GoPointToItinerary = new NavigateCommand(_viewModelStore, () => { return new CompletionPointPointToItineraryViewModel(viewModelStore, dadaWork); });
            GoPoint = new NavigateCommand(_viewModelStore, () => { return new CompletionPointPointViewModel(viewModelStore, dadaWork); });
            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(viewModelStore, dadaWork); });
           
        }

        public ICommand GoPoint { get; set; }
        public ICommand TypePoint { get; set; }
        public ICommand GoPointToItinerary { get; set; }

        public ICommand Back { get; set; }

    }
    
    
}
