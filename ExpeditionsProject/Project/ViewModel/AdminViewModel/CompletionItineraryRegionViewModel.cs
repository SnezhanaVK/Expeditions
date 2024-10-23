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
    public class CompletionItineraryRegionViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionItineraryRegionModel _model = new CompletionItineraryRegionModel();
        private readonly ClientRegistrationViewModel _viewModelViewModel;


        public CompletionItineraryRegionViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelItineraryViewModel(_viewModelStore, dataWork); });

            CompletionRegion = new CompletionIRegionCommand(this, dataWork);
        }
        public CompletionItineraryRegionViewModel(CompletionItineraryRegionModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionRegion { get; set; }

        public string NameRegion
        {
            get
            {
                return _model.NameRegion;
            }
            set
            {
                _model.NameRegion = value;
                OnPropertyChanged(nameof(NameRegion));
            }
        }

        public string NameCountry
        {
            get
            {
                return _model.NameCountry;
            }
            set
            {
                _model.NameCountry = value;
                OnPropertyChanged(nameof(NameCountry));
            }
        }
        public string NearestCity
        {
            get
            {
                return _model.NearestCity;
            }
            set
            {
                _model.NearestCity = value;
                OnPropertyChanged(nameof(NearestCity));
            }
        }

        public string DescriptionRegion
        {
            get
            {
                return _model.DescriptionRegion;
            }
            set
            {
                _model.DescriptionRegion = value;
                OnPropertyChanged(nameof(DescriptionRegion));
            }
        }

    }
}
