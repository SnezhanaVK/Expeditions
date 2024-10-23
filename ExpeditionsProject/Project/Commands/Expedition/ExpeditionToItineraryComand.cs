using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using ExpeditionsProject.Project.Model.AdminModel.Expedition;

namespace ExpeditionsProject.Project.Commands.Expedition
{
    internal class ExpeditionToItineraryComand : ICommand
    {
        private readonly ExpeditionViewModel _viewModel;
        private readonly DataWork _dataWork;

        public ExpeditionToItineraryComand(ExpeditionViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.FK_Expedition) &&
                   !string.IsNullOrEmpty(_viewModel.FK_PointToItinerary) &&
                   !string.IsNullOrEmpty(_viewModel.Time) &&
                   !string.IsNullOrEmpty(_viewModel.Date);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionExpeditionToItinerary(new ExspeditionToItineraryModel
                {
                    FK_Expedition = _viewModel.FK_Expedition,
                    FK_PointToItinerary = _viewModel.FK_PointToItinerary,
                    Time = _viewModel.Time,
                    Date = _viewModel.Date
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
