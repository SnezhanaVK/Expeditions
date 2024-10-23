using ExpeditionsProject.Project.Model.AdminModel.Itinerary;
using ExpeditionsProject.Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using ExpeditionsProject.Project.Model.AdminModel;

namespace ExpeditionsProject.Project.Commands
{
    internal class CompletionItineraryCommand : ICommand
    {
        private readonly CompletionItineraryItineraryViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionItineraryCommand(CompletionItineraryItineraryViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.FK_LevelItinerary) &&
                   !string.IsNullOrEmpty(_viewModel.NameItinerary) &&
                   !string.IsNullOrEmpty(_viewModel.CountDay) &&
                   !string.IsNullOrEmpty(_viewModel.CountKM) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Itinerary) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Regiona);
                 
        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionItinerary(new CompletionItineraryItineraryModel
                {
                    FK_LevelItinerary = _viewModel.FK_LevelItinerary,
                    NameItinerary = _viewModel.NameItinerary,
                    CountDay = _viewModel.CountDay,
                    CountKM = _viewModel.CountKM,
                    FK_Itinerary = _viewModel.FK_Itinerary,
                   
                    FK_Regiona = _viewModel.FK_Regiona
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


