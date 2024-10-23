using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ExpeditionsProject.Project.ViewModel.AdminViewModel;
using ExpeditionsProject.Project.Model.AdminModel.Expedition;

namespace ExpeditionsProject.Project.Commands.Expedition
{
    internal class ExpeditionCommand : ICommand
    {
        private readonly ExpeditionViewModel _viewModel;
        private readonly DataWork _dataWork;

        public ExpeditionCommand(ExpeditionViewModel viewModel, DataWork dataWork)
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
                   !string.IsNullOrEmpty(_viewModel.FK_Menu) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Equipment) &&
                   !string.IsNullOrEmpty(_viewModel.FK_Transfera) &&
                   !string.IsNullOrEmpty(_viewModel.CounMenu) &&
                !string.IsNullOrEmpty(_viewModel.CountEquipment) &&
                !string.IsNullOrEmpty(_viewModel.DateStart) &&
                 !string.IsNullOrEmpty(_viewModel.DateFinish);

        }

        public void Execute(object parameter)
        {
            try
            {
                // Регистрация инструктора
                _dataWork.CompletionExpedition(new ExpeditionModel
                {
                    FK_Itinerary = _viewModel.FK_Itinerary,
                    FK_Menu = _viewModel.FK_Menu,
                    FK_Equipment = _viewModel.FK_Equipment,
                    FK_Transfera = _viewModel.FK_Transfera,
                    CounMenu = _viewModel.CounMenu,
                    CountEquipment = _viewModel.CountEquipment,
                    DateStart = _viewModel.DateStart,
                    DateFinish = _viewModel.DateFinish

                });

                // Вывод сообщения об успешной регистрации
                MessageBox.Show("Экспедиция успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                // Вывод сообщения об ошибке
                MessageBox.Show($"Ошибка при добовлении: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
