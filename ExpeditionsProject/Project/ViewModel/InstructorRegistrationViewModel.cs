using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class InstructorRegistrationViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly InstructorRegistrationViewModel _viewModel;
        InstructorRegistrationModel _instructorRegistrationModel=new InstructorRegistrationModel();
        private readonly DataWork _dataWork;
        
        public string RegistrationStatus { get; set; }




        public InstructorRegistrationViewModel(ViewModelStore viewModelStor, DataWork dataWork)
        {
            _viewModelStore = viewModelStor;
            _dataWork = dataWork;

            GoLogin = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel(viewModelStor,_dataWork); });

            Back = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(viewModelStor, dataWork); });
            RegistrationInstructor = new RegistrationInstructorCommand(this, dataWork);


        }
        public InstructorRegistrationViewModel(InstructorRegistrationViewModel instructorRegistrationViewModel, DataWork dataWork, InstructorRegistrationModel instructorRegistrationModel)
        {
           
            _viewModel = instructorRegistrationViewModel;
            _instructorRegistrationModel = instructorRegistrationModel;
            _dataWork = dataWork;
            
        }



        public ICommand GoLogin { get; set; }

        public ICommand Back { get; set; }
        public ICommand RegistrationInstructor { get; set; }
       
        public string ForeName
        {
            get
            {
                return _instructorRegistrationModel.ForeName;
            }
            set
            {
                _instructorRegistrationModel.ForeName = value;
                OnPropertyChanged(nameof(ForeName));
            }
        }
        public string Patronymic
        {
            get
            {
                return _instructorRegistrationModel.Patronymic;
            }
            set
            {
                _instructorRegistrationModel.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        public string Surname
        {
            get
            {
                return _instructorRegistrationModel.Surname;
            }
            set
            {
                _instructorRegistrationModel.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string NumberTelefon
        {
            get
            {
                return _instructorRegistrationModel.NumberTelefon;
            }
            set
            {
                _instructorRegistrationModel.NumberTelefon = value;
                OnPropertyChanged(nameof(NumberTelefon));
            }
        }
        public string LevelProfisionsl
        {
            get
            {
                return _instructorRegistrationModel.LevelProfisionsl;
            }
            set
            {
                _instructorRegistrationModel.LevelProfisionsl = value;
                OnPropertyChanged(nameof(LevelProfisionsl));
            }
        }
        public string Sport
        {
            get
            {
                return _instructorRegistrationModel.Sport;
            }
            set
            {
                _instructorRegistrationModel.Sport = value;
                OnPropertyChanged(nameof(Sport));
            }
        }
        public string LevelHealth
        {
            get
            {
                return _instructorRegistrationModel.LevelHealth;
            }
            set
            {
                _instructorRegistrationModel.LevelHealth = value;
                OnPropertyChanged(nameof(LevelHealth));
            }
        }
        public string Email
        {
            get
            {
                return _instructorRegistrationModel.Email;
            }
            set
            {
                _instructorRegistrationModel.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return _instructorRegistrationModel.Password;
            }
            set
            {
                _instructorRegistrationModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    }
}
