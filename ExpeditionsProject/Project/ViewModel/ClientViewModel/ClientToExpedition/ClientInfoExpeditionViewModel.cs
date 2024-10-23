using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ClientInfoExpeditionViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ClientInfoExpeditionModel model = new ClientInfoExpeditionModel();
        public int ID_client { get; set; }
        public int ID_expedition { get; set; }

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ClientInfoExpeditionViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient, int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_client = idClient;
            ID_expedition = idExpedition;


            Back = new NavigateCommand(_viewModelStore, () => { return new ClientMenuInfoExpeditionViewModel(_viewModelStore, dataWork, idClient, idExpedition); });

            RunTableInstrucror(idExpedition);






        }


        private void RunTableInstrucror(int idExpedition)
        {
            RouteInfos = _dataWork.GetInfoExpedition(idExpedition);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ClientInfoExpeditionModel> RouteInfos { get; private set; }

        public ClientInfoExpeditionViewModel(ClientInfoExpeditionModel _model)
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
        public int CountPortion
        {
            get
            {
                return model.CountPortion;
            }
            set
            {
                model.CountPortion = value;
                OnPropertyChanged(nameof(CountPortion));
            }
        }
        public int CountEquipment
        {
            get
            {
                return model.CountEquipment;
            }
            set
            {
                model.CountEquipment = value;
                OnPropertyChanged(nameof(CountEquipment));
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
        public DateTime DateEnd
        {
            get
            {
                return model.DateEnd;
            }
            set
            {
                model.DateEnd = value;
                OnPropertyChanged(nameof(DateEnd));
            }
        }
        public int Id_Menu
        {
            get
            {
                return model.Id_Menu;
            }
            set
            {
                model.Id_Menu = value;
                OnPropertyChanged(nameof(Id_Menu));
            }
        }
        public string NameMenu
        {
            get
            {
                return model.NameMenu;
            }
            set
            {
                model.NameMenu = value;
                OnPropertyChanged(nameof(NameMenu));
            }
        }
        public int Id_Transfer
        {
            get
            {
                return model.Id_Transfer;
            }
            set
            {
                model.Id_Transfer = value;
                OnPropertyChanged(nameof(Id_Transfer));
            }
        }
        public DateTime Date
        {
            get
            {
                return model.Date;
            }
            set
            {
                model.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int ID_Equipment
        {
            get
            {
                return model.ID_Equipment;
            }
            set
            {
                model.ID_Equipment = value;
                OnPropertyChanged(nameof(ID_Equipment));
            }
        }
        public string NameEquipment
        {
            get
            {
                return model.NameEquipment;
            }
            set
            {
                model.NameEquipment = value;
                OnPropertyChanged(nameof(NameEquipment));
            }
        }
        public string SkillRequirements
        {
            get
            {
                return model.SkillRequirements;
            }
            set
            {
                model.SkillRequirements = value;
                OnPropertyChanged(nameof(SkillRequirements));
            }
        }
        public int CountInPerson
        {
            get
            {
                return model.CountInPerson;
            }
            set
            {
                model.CountInPerson = value;
                OnPropertyChanged(nameof(CountInPerson));
            }
        }
    }
}
