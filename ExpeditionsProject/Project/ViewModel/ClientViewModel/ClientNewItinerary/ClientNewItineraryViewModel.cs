using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientNew;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientNewItinerary
{
    internal class ClientNewItineraryViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ClientNewInfoItineraryModel model = new ClientNewInfoItineraryModel();
       
        private int IDclient { get; set; }
        private int IDItinerary { get; set; }




        public ICommand Back { get; set; }
        public ICommand ClientIntoteryCommand  { get; private set; }




        public ClientNewItineraryViewModel(ViewModelStore viewModelStore, DataWork dataWork,int idClient)
        {
            _viewModelStore = viewModelStore;
            IDclient = idClient;
            _dataWork = dataWork;
            LoadRouteInfos();
            ClientIntoteryCommand = new RelayCommand<ClientNewInfoItineraryModel>(OnSelectItitary);
           

            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelClientViewModel(_viewModelStore, dataWork,idClient); });

        }
        private void LoadRouteInfos()
        {
            RouteInfos = _dataWork.GetRouteInfo();
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
       
         
        
        private void OnSelectItitary(ClientNewInfoItineraryModel selectedExpedition)
        {
            if (selectedExpedition != null)
            {
                // Передаем ID экспедиции в следующее представление
                IDItinerary = selectedExpedition.ID_Itinerary;

                _viewModelStore.CurrentViewModel = new ClientNewExpeditionViewModel(_viewModelStore, _dataWork,IDclient,IDItinerary);

            }
        }

        public List<ClientNewInfoItineraryModel> RouteInfos { get; private set; }


        public ClientNewItineraryViewModel(ClientNewInfoItineraryModel _model)
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
        public ClientNewInfoItineraryModel SelectedRoute
        {
            get { return model.SelectedRoute; }
            set
            {
                model.SelectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
                if (SelectedRoute != null)
                {
                    OnSelectItitary(SelectedRoute);
                }
            }
        }


    }
}
