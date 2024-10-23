using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ExpeditionsProject.Project.Commands.DopExpeditionCommand
{
    internal class EquipmentItineraryCommand : ICommand
    {
        private readonly EquipmentViewModel _viewModel;
        private readonly DataWork _dataWork;

        public EquipmentItineraryCommand(EquipmentViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.FK_Itinerary) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Equipment);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionEquipmentItinerary(new EquipmentItineraryModel
                {
                    FK_Itinerary = _viewModel.FK_Itinerary,
                    FK_Equipment = _viewModel.FK_Equipment
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Снаряжение успешно добавлен в маршрут !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
