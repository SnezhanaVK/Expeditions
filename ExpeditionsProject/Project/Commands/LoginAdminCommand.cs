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
    public class LoginAdminCommand : ICommand
    {
        private readonly LoginAdminViewModel _viewModel;
        private readonly DataWork _dataWork;

        public LoginAdminCommand(LoginAdminViewModel viewModel, DataWork dataWork)
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
            if (_dataWork.LoginAdmin(_viewModel.Email, _viewModel.Password))
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
