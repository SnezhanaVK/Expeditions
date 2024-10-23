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
    internal class TransferCommand : ICommand
    {
        private readonly TransferViewModel _viewModel;
        private readonly DataWork _dataWork;

        public TransferCommand(TransferViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.Date) &&
                   !string.IsNullOrEmpty(_viewModel.TimeStart)&&
                   !string.IsNullOrEmpty(_viewModel.TimeFinish) &&
                   !string.IsNullOrEmpty(_viewModel.Prise);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionTransfer(new TransferModel
                {
                    Date = _viewModel.Date,
                    TimeStart = _viewModel.TimeStart,
                    TimeFinish = _viewModel.TimeFinish,
                    Prise = _viewModel.Prise,
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Трансфер успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
