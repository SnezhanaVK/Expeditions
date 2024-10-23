using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ClientInstructorInfoViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        InstructorTableModel model = new InstructorTableModel();
        public int ID_client { get; set; }
        public int ID_Expedition { get; set; }

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ClientInstructorInfoViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient, int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_client = idClient;
            ID_Expedition = idExpedition;


            Back = new NavigateCommand(_viewModelStore, () => { return new ClientMenuInfoExpeditionViewModel(_viewModelStore, dataWork, idClient, idExpedition); });

            RunTableInstrucror(idExpedition);






        }


        private void RunTableInstrucror(int idExpedition)
        {
            RouteInfos = _dataWork.GetCientInfoInstructor(idExpedition);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<InstructorTableModel> RouteInfos { get; private set; }

        public ClientInstructorInfoViewModel(InstructorTableModel _model)
        {
            model = _model;
        }
        public int ID_Instructor
        {
            get
            {
                return model.ID_Instructor;
            }
            set
            {
                model.ID_Instructor = value;
                OnPropertyChanged(nameof(ID_Instructor));
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

        public string Sport
        {
            get
            {
                return model.Sport;
            }
            set
            {
                model.Sport = value;
                OnPropertyChanged(nameof(Sport));
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
        public string LevelProfisionsl
        {
            get
            {
                return model.LevelProfisionsl;
            }
            set
            {
                model.LevelProfisionsl = value;
                OnPropertyChanged(nameof(LevelProfisionsl));
            }
        }
    }
}
