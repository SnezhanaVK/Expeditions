using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ClientInfoIntetaryViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ClientNewInfoItineraryModel model = new ClientNewInfoItineraryModel();
        public int ID_Client { get; set; }
        public int ID_Expedition { get; set; }

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ClientInfoIntetaryViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient, int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_Client = idClient;
            ID_Expedition = idExpedition;


            Back = new NavigateCommand(_viewModelStore, () => { return new ClientMenuInfoExpeditionViewModel(_viewModelStore, dataWork, idClient, idExpedition); });

            RunTableInstrucror(idExpedition);






        }


        private void RunTableInstrucror(int idExpedition)
        {
            RouteInfos = _dataWork.GetInfoItinerary(idExpedition);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ClientNewInfoItineraryModel> RouteInfos { get; private set; }

        public ClientInfoIntetaryViewModel(ClientNewInfoItineraryModel _model)
        {
            model = _model;
        }
        public int ID_Itinerary
        {
            get
            {
                return model.ID_Itinerary;
            }
            set
            {
                model.ID_Itinerary = value;
                OnPropertyChanged(nameof(ID_Itinerary));
            }
        }
        public string NameItinerary
        {
            get
            {
                return model.NameItinerary;
            }
            set
            {
                model.NameItinerary = value;
                OnPropertyChanged(nameof(NameItinerary));
            }
        }
        public int CountDay
        {
            get
            {
                return model.CountDay;
            }
            set
            {
                model.CountDay = value;
                OnPropertyChanged(nameof(CountDay));
            }
        }
        public float CountKM
        {
            get
            {
                return model.CountKM;
            }
            set
            {
                model.CountKM = value;
                OnPropertyChanged(nameof(CountKM));
            }
        }
        public string LevelItinerary
        {
            get
            {
                return model.LevelItinerary;
            }
            set
            {
                model.LevelItinerary = value;
                OnPropertyChanged(nameof(LevelItinerary));
            }
        }

        public string NameRegion
        {
            get
            {
                return model.NameRegion;
            }
            set
            {
                model.NameRegion = value;
                OnPropertyChanged(nameof(NameRegion));
            }
        }
    }
}

    
