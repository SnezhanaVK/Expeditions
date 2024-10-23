using ExpeditionsProject.Project.Model.AdminModel.PointModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ExpeditionsProject.Project.Commands
{
    internal class CompletionPointToItineraryCommand : ICommand
    {
        private readonly CompletionPointPointToItineraryViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionPointToItineraryCommand(CompletionPointPointToItineraryViewModel viewModel, DataWork dataWork)
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
                   !string.IsNullOrEmpty(_viewModel.FK_Point)&&
                   !string.IsNullOrEmpty(_viewModel.FK_TypePoint) &&
                   !string.IsNullOrEmpty(_viewModel.DayToPoint) &&
                   !string.IsNullOrEmpty(_viewModel.TimeToPoint) &&
                   !string.IsNullOrEmpty(_viewModel.DayToPoint);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionPointToItinerary(new CompletionPointPointToItineraryModel
                {
                    FK_Itinerary = _viewModel.FK_Itinerary,
                    FK_Point = _viewModel.FK_Point,
                    FK_TypePoint = _viewModel.FK_TypePoint,
                    DateToPoint = _viewModel.DateToPoint,
                    TimeToPoint = _viewModel.TimeToPoint,
                    DayToPoint = _viewModel.DayToPoint
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Точка на маршрут успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлениии: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
