using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ListExpeditionToClientViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ListExpeditionToClientModel model = new ListExpeditionToClientModel();
        public int ID_Client;

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ListExpeditionToClientViewModel(ViewModelStore viewModelStore, DataWork dataWork,int idClient)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_Client = idClient;

            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelClientViewModel(_viewModelStore, dataWork,idClient); });

            RunTableInstrucror(idClient);
            SelectExpeditionCommand = new RelayCommand<ListExpeditionToClientModel>(OnSelectExpedition);




        }

        private void RunTableInstrucror(int idClient)
        {
            RouteInfos = _dataWork.GetListExpeditionToClient(idClient);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ListExpeditionToClientModel> RouteInfos { get; private set; }

        public ListExpeditionToClientViewModel(ListExpeditionToClientModel _model)
        {
            model = _model;
        }
        private void OnSelectExpedition(ListExpeditionToClientModel selectedExpedition)
        {
            if (selectedExpedition != null)
            {
                // Передаем ID экспедиции в следующее представление
                ID_Expedition = selectedExpedition.ID_Expedition;

                _viewModelStore.CurrentViewModel = new ClientMenuInfoExpeditionViewModel(_viewModelStore, _dataWork, ID_Client,ID_Expedition);

            }
        }


        public int ID_Expedition
        {
            get
            {
                return model.ID_Expedition;
            }
            set
            {
                model.ID_Expedition = value;
                OnPropertyChanged(nameof(ID_Expedition));
            }
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

        public DateTime DateStart
        {
            get
            {
                return model.DateStart;
            }
            set
            {
                model.DateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        public DateTime DateFinish
        {
            get
            {
                return model.DateFinish;
            }
            set
            {
                model.DateFinish = value;
                OnPropertyChanged(nameof(DateFinish));
            }
        }
        public ListExpeditionToClientModel SelectedRoute
        {
            get { return model.SelectedRoute; }
            set
            {
                model.SelectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
                if (SelectedRoute != null)
                {
                    OnSelectExpedition(SelectedRoute);
                }
            }
        }


    }
}



