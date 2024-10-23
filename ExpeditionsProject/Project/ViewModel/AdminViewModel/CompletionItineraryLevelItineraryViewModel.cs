using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model;
using ExpeditionsProject.Project.Model.AdminModel.Itinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    public class CompletionItineraryLevelItineraryViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionItineraryLevelItineraryModel _model = new CompletionItineraryLevelItineraryModel();
        private readonly ClientRegistrationViewModel _viewModelViewModel;


        public CompletionItineraryLevelItineraryViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelItineraryViewModel(_viewModelStore, dataWork); });

            CompletionLevelItinerary = new CompletionLevelItineraryCommand(this, dataWork);
        }
        public CompletionItineraryLevelItineraryViewModel(CompletionItineraryLevelItineraryModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }

            
        public ICommand CompletionLevelItinerary { get; set; }
        public string NameLevelItinerary
        {
            get
            {
                return _model.NameLevelItinerary;
            }
            set
            {
                _model.NameLevelItinerary = value;
                OnPropertyChanged(nameof(NameLevelItinerary));
            }
        }
        public string DescriptionLevelItinerary
        {
            get
            {
                return _model.DescriptionLevelItinerary;
            }
            set
            {
                _model.DescriptionLevelItinerary = value;
                OnPropertyChanged(nameof(DescriptionLevelItinerary));
            }
        }



    }
}
