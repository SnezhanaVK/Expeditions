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
    internal class CompletionPointCommand : ICommand
    {
        private readonly CompletionPointPointViewModel _viewModel;
        private readonly DataWork _dataWork;

        public CompletionPointCommand(CompletionPointPointViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NamePoint) &&
                   !string.IsNullOrEmpty(_viewModel.DescriptionPoint);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionPoint(new CompletionPointPointModel
                {
                    NamePoint = _viewModel.NamePoint,
                    DescriptionPoint = _viewModel.DescriptionPoint
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("очка успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлениии: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
