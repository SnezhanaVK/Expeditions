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
    public class ClientRegistrationViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        ClientRegistrationModel _model=new ClientRegistrationModel();
        private readonly ClientRegistrationViewModel _viewModelViewModel;


        public ClientRegistrationViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
           

            _dataWork = dataWork;

            GoLogin = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel (_viewModelStore, dataWork); });

            Back = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(_viewModelStore, dataWork); });

            RegistrationClient = new RegistrationClientCommand(this, dataWork);
        }
        public ClientRegistrationViewModel( ClientRegistrationModel model)
        {
          
            _model = model;
        }




        public ICommand Back { get; set; }
        public ICommand GoLogin { get; set; }
        public ICommand RegistrationClient { get; set; }

        public string ForeName
        {
            get
            {
                return _model.ForeName;
            }
            set
            {
                _model.ForeName = value;
                OnPropertyChanged(nameof(ForeName));
            }
        }
        public string Patronymic
        {
            get
            {
                return _model.Patronymic;
            }
            set
            {
                _model.Patronymic = value;
                OnPropertyChanged(nameof(Patronymic));
            }
        }
        public string Surname
        {
            get
            {
                return _model.Surname;
            }
            set
            {
                _model.Surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public string NumberTelefon
        {
            get
            {
                return _model.NumberTelefon;
            }
            set
            {
                _model.NumberTelefon = value;
                OnPropertyChanged(nameof(NumberTelefon));
            }
        }
        public string Country
        {
            get
            {
                return _model.Country;
            }
            set
            {
                _model.Country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string City
        {
            get
            {
                return _model.City;
            }
            set
            {
                _model.City = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string LevelHealth
        {
            get
            {
                return _model.LevelHealth;
            }
            set
            {
                _model.LevelHealth = value;
                OnPropertyChanged(nameof(LevelHealth));
            }
        }
        public string Street
        {
            get
            {
                return _model.Street;
            }
            set
            {
                _model.Street = value;
                OnPropertyChanged(nameof(Street));
            }
        }
        public string NumberHome
        {
            get
            {
                return _model.NumberHome;
            }
            set
            {
                _model.NumberHome = value;
                OnPropertyChanged(nameof(NumberHome));
            }
        }
        public string Email
        {
            get
            {
                return _model.Email;
            }
            set
            {
                _model.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return _model.Password;
            }
            set
            {
                _model.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

    }
}
