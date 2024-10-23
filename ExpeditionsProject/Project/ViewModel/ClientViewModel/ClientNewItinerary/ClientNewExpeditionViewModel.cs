using ExpeditionsProject.Project.Databases;
using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientNew;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientNewItinerary
{
    public class ClientNewExpeditionViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
       ClientNewExpeditionModel model = new ClientNewExpeditionModel();
        ExpeditionTibleModel _selectedExpedition;
        int IDClient {  get; set; }
        int IDIntetary {  get; set; }
        int IDExpedition { get; set; }


        public ICommand Back { get; set; }


        public ClientNewExpeditionViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient,int Idintetary)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            IDClient = idClient;
            IDIntetary = Idintetary;

            Back = new NavigateCommand(_viewModelStore, () => { return new ClientNewItineraryViewModel(_viewModelStore, dataWork,idClient); });

            RunTableInstrucror(Idintetary);



        }
        private void RunTableInstrucror(int idIntetaru)
        {
            RouteInfos = _dataWork.GetExpeditionsInNewExpedition(idIntetaru);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        private void OnSelectItitary(ClientNewExpeditionModel selectedExpedition)
        {
            if (selectedExpedition != null)
            {
                // Передаем ID экспедиции в следующее представление
                IDExpedition = selectedExpedition.ID_Expedition;

                _viewModelStore.CurrentViewModel = new ClientNewExpeditionAddViewModel(_viewModelStore, _dataWork, IDClient, IDExpedition);

            }
        }
        public List<ClientNewExpeditionModel> RouteInfos { get; private set; }

        public ClientNewExpeditionViewModel(ClientNewExpeditionModel _model)
        {
            model = _model;
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

        public ClientNewExpeditionModel SelectedRoute
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
