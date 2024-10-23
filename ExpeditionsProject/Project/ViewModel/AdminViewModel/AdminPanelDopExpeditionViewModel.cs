using ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    public class AdminPanelDopExpeditionViewModel:  ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dadaWork;


    public AdminPanelDopExpeditionViewModel(ViewModelStore viewModelStore, DataWork dadaWork)
    {
        _viewModelStore = viewModelStore;
        _dadaWork = dadaWork;
        GoToTransfer = new NavigateCommand(_viewModelStore, () => { return new TransferViewModel(viewModelStore, dadaWork); });
        GoToMenu = new NavigateCommand(_viewModelStore, () => { return new ProductToMenuViewModel(viewModelStore, dadaWork); });
        GoToEquipment = new NavigateCommand(_viewModelStore, () => { return new EquipmentViewModel(viewModelStore, dadaWork); });
        Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(viewModelStore, dadaWork); });
        }

    public ICommand GoToTransfer { get; set; }
    public ICommand GoToMenu { get; set; }
    public ICommand GoToEquipment { get; set; }

        public ICommand Back { get; set; }

    }

}

