using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using ExpeditionsProject.Project.ViewModel.InstructorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class LoginInstructorViewModel:ViewModelBase
    {
        LoginInstructorModel loginInstructor=new LoginInstructorModel();
        readonly private ViewModelStore _viewModelStore;
        readonly private DataWork _dataWork;
        public string Email
        {
            get
            {
                return loginInstructor.Email;
            }
            set
            {
                loginInstructor.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get
            {
                return loginInstructor.Password;
            }
            set
            {
                loginInstructor.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public int ID_Instructor
        {
            get
            {
                return loginInstructor.ID_Instructor;
            }
            set
            {
                loginInstructor.ID_Instructor = value;
                OnPropertyChanged(nameof(ID_Instructor));
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand Back { get; set; }
        public ICommand GoRegistration { get; set; }
        public LoginInstructorViewModel(ViewModelStore viewModelStore,DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork= dataWork;
            Back = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel(_viewModelStore,dataWork); });
            GoRegistration = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(_viewModelStore, dataWork); });
            LoginCommand = new LoginInstructorCommand(this, _dataWork);

        }
        public void GoToNextView()
        {
            // Попытка входа с использованием предоставленных Email и Password
            int? clientId = _dataWork.LoginInstructor(Email, Password);

            if (clientId.HasValue)
            {
                // Если clientId имеет значение, значит вход успешен
                ID_Instructor = clientId.Value; // Сохраняем ID клиента

                // Переключение на следующее представление после успешного входа
                _viewModelStore.CurrentViewModel = new InstructorListExpeditionViewModel(_viewModelStore, _dataWork, ID_Instructor);
            }
            else
            {
                // Обработка ошибки входа, например, вывод сообщения об ошибке
                MessageBox.Show("Неверный email или пароль");
            }
        }

    }
}
