using ExpeditionsProject.Project.View.AdminView;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    class StartPanelAdminViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;


        public StartPanelAdminViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;

            GoAdminItinerary = new NavigateCommand(viewModelStore, () => { return new AdminPanelItineraryViewModel(viewModelStore, dataWork); });
            GoAdminPoint = new NavigateCommand(viewModelStore, () => { return new AdminPanelPointViewModel(viewModelStore, dataWork); });
            GoAdminDopExpedition = new NavigateCommand(viewModelStore, () => { return new AdminPanelDopExpeditionViewModel(viewModelStore, dataWork); });
            GoOsnovExpedition = new NavigateCommand(viewModelStore, () => { return new ExpeditionViewModel(viewModelStore, dataWork); });
            GoTableItinerary = new NavigateCommand(_viewModelStore, () => { return new ItineraryTableViewModel(_viewModelStore, dataWork); });
            GoTableInstructor= new NavigateCommand(_viewModelStore, () => { return new InstructorTableViewModel(_viewModelStore, dataWork); });
            GoTableClients = new NavigateCommand(_viewModelStore, () => { return new ClientTableViewModel(_viewModelStore, dataWork); });
            GoTableExpedition = new NavigateCommand(_viewModelStore, () => { return new ExpeditionTibelViewModel(_viewModelStore, dataWork); });
        }
       
            public ICommand GoTableExpedition { get; set; }
        public ICommand GoTableInstructor { get; set; }
        public ICommand GoTableItinerary { get; set; }
        public ICommand GoTableClients { get; set; }
       
        public ICommand GoAdminItinerary { get; set; }
        public ICommand GoAdminPoint { get; set; }
        public ICommand GoAdminDopExpedition { get; set; }
        public ICommand GoOsnovExpedition { get; set; }
     

    }
}
