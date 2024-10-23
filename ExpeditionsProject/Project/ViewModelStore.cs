using ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientNewItinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project
{
    public class ViewModelStore
    {
        ViewModelBase _currentViewModel;
        public ClientNewExpeditionViewModel ClientNewExpeditionViewModel { get; set; }
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }
        public event Action CurrentViewModelChanged;
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
