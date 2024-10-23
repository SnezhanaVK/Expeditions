using ExpeditionsProject.Project.Model.AdminModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;

namespace ExpeditionsProject.Project.Commands.DopExpeditionCommand
{
    internal class EquipmentCommand : ICommand
    {
        private readonly EquipmentViewModel _viewModel;
        private readonly DataWork _dataWork;

        public EquipmentCommand(EquipmentViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameEquipment) &&
                   !string.IsNullOrEmpty(_viewModel.SkillsEquipment) &&
                   !string.IsNullOrEmpty(_viewModel.CountEquipment);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionEquipment(new EquipmentModel
                {
                    NameEquipment= _viewModel.NameEquipment,
                    SkillsEquipment = _viewModel.SkillsEquipment,
                    CountEquipment = _viewModel.CountEquipment
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Снаряжение успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
