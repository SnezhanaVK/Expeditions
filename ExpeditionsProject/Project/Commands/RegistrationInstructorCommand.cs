using ExpeditionsProject.Project.Databases;
using ExpeditionsProject.Project.Model;
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
    public class RegistrationInstructorCommand : ICommand
    {
        private readonly InstructorRegistrationViewModel _viewModel;
        private readonly DataWork _dataWork;

        public RegistrationInstructorCommand(InstructorRegistrationViewModel viewModel, DataWork dataWork)
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
                   !string.IsNullOrEmpty(_viewModel.LevelProfisionsl) &&
                   !string.IsNullOrEmpty(_viewModel.Sport) &&
                   !string.IsNullOrEmpty(_viewModel.LevelHealth) &&
                   !string.IsNullOrEmpty(_viewModel.Email) &&
                   !string.IsNullOrEmpty(_viewModel.Password);
        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.RegistrationInstructor(new InstructorRegistrationModel
                {
                    ForeName = _viewModel.ForeName,
                    Patronymic = _viewModel.Patronymic,
                    Surname = _viewModel.Surname,
                    NumberTelefon = _viewModel.NumberTelefon,
                    LevelProfisionsl = _viewModel.LevelProfisionsl,
                    Sport = _viewModel.Sport,
                    LevelHealth = _viewModel.LevelHealth,
                    Email = _viewModel.Email,
                    Password = _viewModel.Password
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Инструктор успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    }