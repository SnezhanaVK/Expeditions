using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using ExpeditionsProject.Project.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class LoginAdminViewModel:ViewModelBase

    {
        LoginAdminModel loginAdminModel=new LoginAdminModel();
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        public LoginAdminViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _dataWork = dataWork;
            _viewModelStore = viewModelStore;
            Back = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel(_viewModelStore,dataWork); });
            GoRegistration = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(_viewModelStore, dataWork); });
            LoginCommand = new LoginAdminCommand(this, dataWork);
        }
        public void GoToNextView()
        {

            // Предполагаем, что есть метод для проверки входа
            if (_dataWork.LoginAdmin(Email, Password))
            {
                // Переключение на следующее представление после успешного входа
                _viewModelStore.CurrentViewModel = new StartPanelAdminViewModel(_viewModelStore, _dataWork);
            }
            else
            {
                // Обработка ошибки входа, например, вывод сообщения об ошибке
                 MessageBox.Show("Неверный email или пароль");
            }
        }
        public string Email
        {
            get
            {
                return loginAdminModel.Email;
            }
            set
            {
                loginAdminModel.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return loginAdminModel.Password;
            }
            set
            {
                loginAdminModel.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand Back {  get; set; }
        public ICommand GoRegistration {  get; set; }
        
    }
}
