using ExpeditionsProject.Project.ViewModel;
using ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientNewItinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.Commands
{
    public class AddClientToExpeditionCommand : ICommand
    {
        private readonly ClientNewExpeditionAddViewModel _viewModel;
        private readonly DataWork _dataWork;

        public AddClientToExpeditionCommand(ClientNewExpeditionAddViewModel viewModel, DataWork dataWork)
        {
            _viewModel = viewModel;
            _dataWork = dataWork;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dataWork.AddClientToExpedition(_viewModel.ID_client, _viewModel.ID_expedition);
        }
    }
}


