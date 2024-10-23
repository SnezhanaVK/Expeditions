using ExpeditionsProject.Project.Model.AdminModel.Itinerary;
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
    internal class CompletionLevelItineraryCommand : ICommand
    {
        private readonly CompletionItineraryLevelItineraryViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionLevelItineraryCommand(CompletionItineraryLevelItineraryViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameLevelItinerary) &&
                   !string.IsNullOrEmpty(_viewModel.DescriptionLevelItinerary);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionLevelItinerary(new CompletionItineraryLevelItineraryModel
                {
                   NameLevelItinerary = _viewModel.NameLevelItinerary,
                    DescriptionLevelItinerary = _viewModel.DescriptionLevelItinerary
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show(" успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}




