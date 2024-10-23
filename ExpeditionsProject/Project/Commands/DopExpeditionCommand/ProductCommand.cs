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
    internal class ProductCommand : ICommand
    {
        private readonly ProductToMenuViewModel _viewModel;
        private readonly DataWork _dataWork;

        public ProductCommand(ProductToMenuViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameProduct) &&
                   !string.IsNullOrEmpty(_viewModel.Count);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionProduct(new ProductModel
                {
                    NameProduct = _viewModel.NameProduct,
                    Count = _viewModel.Count
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Продукт успешно добавлен !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
