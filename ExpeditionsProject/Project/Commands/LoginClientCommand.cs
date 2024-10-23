using ExpeditionsProject.Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ExpeditionsProject.Project.Commands
{
    class LoginClientCommand : ICommand
    {

        private readonly LoginClientViewModel _viewModel;
        private readonly DataWork _dataWork;

        public LoginClientCommand(LoginClientViewModel viewModel, DataWork dataWork)
        {
            _viewModel = viewModel;
            _dataWork = dataWork;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int? clientId = _dataWork.LoginClient(_viewModel.Email, _viewModel.Password);
            if (clientId.HasValue)
            {
                // Переход на другую View, если вход успешен
                _viewModel.GoToNextView();
            }
            else
            {
                // Обработка ошибки входа
                MessageBox.Show("Неверный email или пароль.");
            }
        }
    }
}



