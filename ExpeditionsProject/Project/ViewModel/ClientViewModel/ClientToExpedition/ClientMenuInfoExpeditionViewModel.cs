using ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ClientMenuInfoExpeditionViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;

        public int ID_Client;
        public int ID_Expedition;

        public ICommand Back { get; set; }
        public ICommand GoClientPointList { get; set; }
        public ICommand GoClientItiteraryInfo { get; set; }
        public ICommand GoClientInfo { get; set; }
        public ICommand GoClientInfoInstructor { get; set; }
        public ICommand GoClientInfoExpedition { get; set; }




        public ClientMenuInfoExpeditionViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient ,int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_Client = idClient;
            ID_Expedition = idExpedition;

            Back = new NavigateCommand(_viewModelStore, () => { return new ListExpeditionToClientViewModel(_viewModelStore, dataWork,idClient); });
            GoClientPointList = new NavigateCommand(_viewModelStore, () => { return new ClientPointExpeditionViewModel(_viewModelStore, dataWork, idClient,idExpedition); });
            GoClientItiteraryInfo = new NavigateCommand(_viewModelStore, () => { return new ClientInfoIntetaryViewModel(_viewModelStore, dataWork, idClient, idExpedition); });
            GoClientInfo = new NavigateCommand(_viewModelStore, () => { return new ClientInfoViewModel(_viewModelStore, dataWork, idClient, idExpedition); });
            GoClientInfoInstructor = new NavigateCommand(_viewModelStore, () => { return new ClientInstructorInfoViewModel(_viewModelStore, dataWork, idClient, idExpedition); });
            GoClientInfoExpedition = new NavigateCommand(_viewModelStore, () => { return new ClientInfoExpeditionViewModel(_viewModelStore, dataWork, idClient, idExpedition); });


        }

        
    
        
    }
}
