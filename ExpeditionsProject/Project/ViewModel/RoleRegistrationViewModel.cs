using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    public class RoleRegistrationViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;


        public RoleRegistrationViewModel(ViewModelStore viewModelStore,DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
           
            GoRegistrationInstructor = new NavigateCommand(_viewModelStore, () => { return new InstructorRegistrationViewModel(_viewModelStore, dataWork); });
            GoRegistrationClient = new NavigateCommand(_viewModelStore, () => { return new ClientRegistrationViewModel(_viewModelStore, dataWork); });
            Back = new NavigateCommand(_viewModelStore, () => { return new StartViewModel(_viewModelStore, dataWork); });

        }

        
        public ICommand GoRegistrationInstructor { get; set; }
        public ICommand GoRegistrationClient { get; set; }
        public ICommand Back { get; set; }

    }
}
