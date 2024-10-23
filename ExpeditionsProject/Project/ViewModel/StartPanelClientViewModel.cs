using ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientNewItinerary;
using ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    class StartPanelClientViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        private int ID_Client;


        public StartPanelClientViewModel(ViewModelStore viewModelStore, DataWork dataWork,int id_client)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_Client = id_client;

            GoNewExpedition = new NavigateCommand(_viewModelStore, () => { return new ClientNewItineraryViewModel(_viewModelStore, dataWork,ID_Client); });
            GoExpedition = new NavigateCommand(_viewModelStore, () => { return new ListExpeditionToClientViewModel(_viewModelStore, dataWork,ID_Client); });
           

        }


        public ICommand GoNewExpedition { get; set; }
        public ICommand GoExpedition { get; set; }
        

    }
}
