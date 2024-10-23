using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.InstructorViewModel
{
    internal class InstructorInfoClientViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ClientTableModel model = new ClientTableModel();
        public int ID_client { get; set; }
        public int ID_Expedition { get; set; }

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public InstructorInfoClientViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient, int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_client = idClient;
            ID_Expedition = idExpedition;


            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelInstructorViewModel(_viewModelStore, dataWork, idClient, idExpedition); });

            RunTableInstrucror(idExpedition);






        }


        private void RunTableInstrucror(int idExpedition)
        {
            RouteInfos = _dataWork.GetInfoClient(idExpedition);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ClientTableModel> RouteInfos { get; private set; }

        public InstructorInfoClientViewModel(ClientTableModel _model)
        {
            model = _model;
        }

        public int ID_Client
        {
            get
            {
                return model.ID_Client;
            }
            set
            {
                model.ID_Client = value;
                OnPropertyChanged(nameof(ID_Client));
            }
        }

        public string ForeName
        {
            get
            {
                return model.ForeName;
            }
            set
            {
                model.ForeName = value;
                OnPropertyChanged(nameof(ForeName));
            }
        }
        public string LevelHealth
        {
            get
            {
                return model.LevelHealth;
            }
            set
            {
                model.LevelHealth = value;
                OnPropertyChanged(nameof(LevelHealth));
            }
        }

        public string Patronymic
        {
            get
            {
                return model.Patronymic;
            }
            set
            {
                model.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }

        public string Surname
        {
            get
            {
                return model.Surname;
            }
            set
            {
                model.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string NumberTelefon
        {
            get
            {
                return model.NumberTelefon;
            }
            set
            {
                model.NumberTelefon = value;
                OnPropertyChanged(nameof(NumberTelefon));
            }
        }
    }
}


