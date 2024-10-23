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
    internal class MenuCommand : ICommand
    {
        private readonly ProductToMenuViewModel _viewModel;
        private readonly DataWork _dataWork;

        public MenuCommand(ProductToMenuViewModel viewModel, DataWork dataWork)
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
            return !string.IsNullOrEmpty(_viewModel.NameMenu);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionMenu(new MenuModel
                {
                    NameMenu = _viewModel.NameMenu
                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Меню успешно добавлен в маршрут !", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
