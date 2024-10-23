using ExpeditionsProject.Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class StartViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dadaWork;


        public StartViewModel(ViewModelStore viewModelStore, DataWork dadaWork)
        {
            _viewModelStore = viewModelStore;

            GoRoleLogin = new NavigateCommand(_viewModelStore, () => { return new RoleViewModel(viewModelStore,dadaWork); });
            GoRoleRegistration = new NavigateCommand(_viewModelStore, () => { return new RoleRegistrationViewModel(viewModelStore,dadaWork); });
            _dadaWork = dadaWork;
        }

        public ICommand GoRoleLogin { get; set; }
        public ICommand GoRoleRegistration { get; set; }

    }
}
