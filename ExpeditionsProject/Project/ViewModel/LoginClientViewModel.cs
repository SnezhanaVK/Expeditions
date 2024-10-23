using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class LoginClientViewModel:ViewModelBase
    {
        LoginClientModel loginClientModel =new LoginClientModel();
        readonly private ViewModelStore _viewModelStore;
        readonly private DataWork _dataWork;
        public string Email
        {
            get
            {
                return loginClientModel.Email;
            }
            set
            {
                loginClientModel.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return loginClientModel.Password;
            }
            set
            {
                loginClientModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public int ID_Client
        {
            get
            {
                return loginClientModel.ID_Clienta;
            }
            set
            {
                loginClientModel.ID_Clienta = value;
                OnPropertyChanged(nameof(ID_Client));
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand Back { get; set; }
        public ICommand GoRegistration { get; set; }
        public LoginClientViewModel(ViewModelStore viewModelStore,DataWork dataWork)
        {
            _dataWork = dataWork;
            _viewModelStore= viewModelStore;

            Back = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel(_viewModelStore, dataWork); });
            GoRegistration = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(_viewModelStore, dataWork); });
            LoginCommand = new LoginClientCommand(this, _dataWork);

        }
        public void GoToNextView()
        {
            // Попытка входа с использованием предоставленных Email и Password
            int? clientId = _dataWork.LoginClient(Email, Password);

            if (clientId.HasValue)
            {
                // Если clientId имеет значение, значит вход успешен
                ID_Client = clientId.Value; // Сохраняем ID клиента

                // Переключение на следующее представление после успешного входа
                _viewModelStore.CurrentViewModel = new StartPanelClientViewModel(_viewModelStore, _dataWork,ID_Client);
            }
            else
            {
                // Обработка ошибки входа, например, вывод сообщения об ошибке
                MessageBox.Show("Неверный email или пароль");
            }
        }

    }
}
