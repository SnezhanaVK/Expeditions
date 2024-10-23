using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable
{
    internal class InstructorTableViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        InstructorTableModel model = new InstructorTableModel();

        public ICommand Back { get; set; }


        public InstructorTableViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;

            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(_viewModelStore, dataWork); });
            RunTableInstrucror();


        }
        private void RunTableInstrucror()
        {
            RouteInfos = _dataWork.InstructorsTable();
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<InstructorTableModel> RouteInfos { get; private set; }

        public InstructorTableViewModel(InstructorTableModel _model)
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
