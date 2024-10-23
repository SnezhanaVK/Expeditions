using ExpeditionsProject.Project.ViewModel.InstructorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel
{
    class StartPanelInstructorViewModel : ViewModelBase
    {

        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        private int IDInstructor {  get; set; }
        private int IDExpedition { get; set; }



        public StartPanelInstructorViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idInstructor,int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            IDInstructor = idInstructor;
            IDExpedition = idExpedition;

            GoInfoExpedition = new NavigateCommand(_viewModelStore, () => { return new InstructorInfoExpeditionViewModel(_viewModelStore, dataWork,idInstructor,idExpedition); });
            GoInfoClient = new NavigateCommand(_viewModelStore, () => { return new InstructorInfoClientViewModel(_viewModelStore, dataWork, idInstructor, idExpedition); });
            Back = new NavigateCommand(_viewModelStore, () => { return new InstructorListExpeditionViewModel(_viewModelStore, dataWork, idExpedition); });

        }


        public ICommand GoInfoExpedition { get; set; }
        public ICommand GoInfoClient { get; set; }
        public ICommand Back { get; set; }

    }
}
