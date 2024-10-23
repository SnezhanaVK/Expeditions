using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    public class AdminPanelItineraryViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dadaWork;


        public AdminPanelItineraryViewModel(ViewModelStore viewModelStore, DataWork dadaWork)
        {
            _viewModelStore = viewModelStore;
            _dadaWork = dadaWork;
            GoCompletionRegion = new NavigateCommand(viewModelStore, () => { return new CompletionItineraryRegionViewModel(viewModelStore, dadaWork); });
            GoCompletionLevelItinerary = new NavigateCommand(viewModelStore, () => { return new CompletionItineraryLevelItineraryViewModel(viewModelStore, dadaWork); });
            GoCompletionItinerary = new NavigateCommand(viewModelStore, () => { return new CompletionItineraryItineraryViewModel(viewModelStore, dadaWork); });
            Back = new NavigateCommand(viewModelStore, () => { return new StartPanelAdminViewModel(viewModelStore, dadaWork); });
            
        }

        public ICommand GoCompletionRegion { get; set; }
        public ICommand  Back { get; set; }
        public ICommand GoCompletionLevelItinerary { get; set; }
        public ICommand GoCompletionItinerary { get; set; }

    }
    
}

