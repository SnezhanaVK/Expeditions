using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpeditionsProject.Project.View;
using ExpeditionsProject.Project.ViewModel;

namespace ExpeditionsProject.Project
{
    class NavigateCommand : CommandBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly Func<ViewModelBase> _createViewModel;
        public NavigateCommand(ViewModelStore viewModelStore, Func<ViewModelBase>
        createViewModel)
        {
            if (viewModelStore == null)
                throw new ArgumentNullException(nameof(viewModelStore));

            _viewModelStore = viewModelStore;
            _createViewModel = createViewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModelStore.CurrentViewModel = _createViewModel();
        }
    }
}
