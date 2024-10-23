using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ExpeditionsProject.Project.Commands.DopExpeditionCommand
{
    internal class ProductToMenuCommand : ICommand
    {
        private readonly ProductToMenuViewModel _viewModel;
        private readonly DataWork _dataWork;

        public ProductToMenuCommand(ProductToMenuViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.FK_Product) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Menu);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionProductToMenu(new ProductToMenuModel
                {
                    FK_Product = _viewModel.FK_Product,
                    FK_Menu = _viewModel.FK_Menu
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Продукт успешно добавлен в меню !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
    
}
