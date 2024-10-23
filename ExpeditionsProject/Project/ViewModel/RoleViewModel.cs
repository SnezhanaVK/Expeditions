using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class RoleViewModel : ViewModelBase
    {
        public RoleModel roleModel = new RoleModel();
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
       

        public RoleViewModel(ViewModelStore viewModelStore,DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            
            GoAdminLogin = new NavigateCommand(_viewModelStore, () => {return new LoginAdminViewModel(_viewModelStore, dataWork);});
            GoLoginInstructor=new NavigateCommand(_viewModelStore, () => { return new LoginInstructorViewModel(_viewModelStore, dataWork); });
            GoLoginClient=new NavigateCommand(_viewModelStore, () => { return new LoginClientViewModel(_viewModelStore,dataWork);});
            Back=new NavigateCommand(_viewModelStore, () => { return new StartViewModel(_viewModelStore,dataWork); });
        }

        public ICommand GoAdminLogin { get; set; }
        public ICommand GoLoginInstructor { get; set; }
        public ICommand GoLoginClient { get; set; }
        public ICommand Back { get; set; }
    }
}
