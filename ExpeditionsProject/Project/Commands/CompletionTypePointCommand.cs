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
    internal class CompletionTypePointCommand : ICommand
    {
        private readonly CompletionPointTypePointViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionTypePointCommand(CompletionPointTypePointViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameTypePoint) &&
                   !string.IsNullOrEmpty(_viewModel.DescriptionTypePoint);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionTypePoint(new CompletionPointTypePointModel
                {
                    NameTypePoint = _viewModel.NameTypePoint,
                    DescriptionTypePoint = _viewModel.DescriptionTypePoint
                   
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Тип точки успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлениии: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
    
}
