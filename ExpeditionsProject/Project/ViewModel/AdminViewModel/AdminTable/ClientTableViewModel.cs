using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable
{
    internal class ClientTableViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ClientTableModel model = new ClientTableModel();

        public ICommand Back { get; set; }


        public ClientTableViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;

            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(_viewModelStore, dataWork); });
            RunTableInstrucror();


        }
        private void RunTableInstrucror()
        {
            RouteInfos = _dataWork.ClientTable();
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ClientTableModel> RouteInfos { get; private set; }

        public ClientTableViewModel(ClientTableModel _model)
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

    }
}
