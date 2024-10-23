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
    internal class CompletionIRegionCommand : ICommand
    {
        private readonly CompletionItineraryRegionViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionIRegionCommand(CompletionItineraryRegionViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameRegion) &&
                   !string.IsNullOrEmpty(_viewModel.NameCountry) &&
                   !string.IsNullOrEmpty(_viewModel.NearestCity) &&
                   !string.IsNullOrEmpty(_viewModel.DescriptionRegion);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionRegion(new CompletionItineraryRegionModel
                {
                    NameRegion = _viewModel.NameRegion,
                    NameCountry = _viewModel.NameCountry,
                    NearestCity = _viewModel.NearestCity,
                    DescriptionRegion = _viewModel.DescriptionRegion
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Регион успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
