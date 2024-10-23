using ExpeditionsProject.Project.Model;
using ExpeditionsProject.Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ExpeditionsProject.Project.Commands
{
    public class RegistrationClientCommand : ICommand
    {
        private readonly ClientRegistrationViewModel _viewModel;
        private readonly DataWork _dataWork;

        public RegistrationClientCommand(ClientRegistrationViewModel viewModel, DataWork dataWork)
        {
            _viewModel = viewModel;
            _dataWork = dataWork;

            // Подписка на изменения свойств модели
            _viewModel.PropertyChanged += (sender, args) => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // Проверка, заполнены ли все необходимые поля
            return !string.IsNullOrEmpty(_viewModel.ForeName) &&
                   !string.IsNullOrEmpty(_viewModel.Patronymic) &&
                   !string.IsNullOrEmpty(_viewModel.Surname) &&
                   !string.IsNullOrEmpty(_viewModel.NumberTelefon) &&
                   !string.IsNullOrEmpty(_viewModel.Country) &&
                   !string.IsNullOrEmpty(_viewModel.City) &&
                   !string.IsNullOrEmpty(_viewModel.Street) &&
                   !string.IsNullOrEmpty(_viewModel.NumberHome) &&
                   !string.IsNullOrEmpty(_viewModel.LevelHealth) &&
                   !string.IsNullOrEmpty(_viewModel.Email) &&
                   !string.IsNullOrEmpty(_viewModel.Password);
        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.RegistrationClient(new ClientRegistrationModel
                {
                    ForeName = _viewModel.ForeName,
                    Patronymic = _viewModel.Patronymic,
                    Surname = _viewModel.Surname,
                    NumberTelefon = _viewModel.NumberTelefon,
                    Country = _viewModel.Country,
                    City = _viewModel.City,
                    Street = _viewModel.Street,
                    LevelHealth = _viewModel.LevelHealth,
                    Email = _viewModel.Email,
                    Password = _viewModel.Password
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Клиент успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
