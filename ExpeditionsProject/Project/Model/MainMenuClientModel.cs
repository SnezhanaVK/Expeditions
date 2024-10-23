using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExpeditionsProject.Project.Model
{
    public class MainMenuClientModel : INotifyPropertyChanged
    {
        private string selectedRoute;
        private List<string> selectedRoutesList;
        private List<string> completedRoutesList;

        public MainMenuClientModel()
        {
            SelectedRoutesList = new List<string>();
            CompletedRoutesList = new List<string>();
        }

        public string SelectedRoute
        {
            get { return selectedRoute; }
            set
            {
                selectedRoute = value;
                OnPropertyChanged();
            }
        }

        public List<string> SelectedRoutesList
        {
            get { return selectedRoutesList; }
            set
            {
                selectedRoutesList = value;
                OnPropertyChanged();
            }
        }

        public List<string> CompletedRoutesList
        {
            get { return completedRoutesList; }
            set
            {
                completedRoutesList = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
