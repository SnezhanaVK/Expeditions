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
    public class CompletionItineraryItineraryViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionItineraryItineraryModel _model = new CompletionItineraryItineraryModel();
        private readonly CompletionItineraryItineraryViewModel _viewModelViewModel;


        public CompletionItineraryItineraryViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelItineraryViewModel(viewModelStore, dataWork); });

            CompletionItinerary = new CompletionItineraryCommand(this, dataWork);
        }
        public CompletionItineraryItineraryViewModel(CompletionItineraryItineraryModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; } 
        public ICommand CompletionItinerary{ get; set; }

        public string FK_LevelItinerary
        {
            get
            {
                return _model.FK_LevelItinerary;
            }
            set
            {
                _model.FK_LevelItinerary = value;
                OnPropertyChanged(nameof(FK_LevelItinerary));
            }
        }

        public string NameItinerary
        {
            get
            {
                return _model.NameItinerary;
            }
            set
            {
                _model.NameItinerary = value;
                OnPropertyChanged(nameof(NameItinerary));
            }
        }

        public string CountDay
        {
            get
            {
                return _model.CountDay;
            }
            set
            {
                _model.CountDay = value;
                OnPropertyChanged(nameof(CountDay));
            }
        }

        public string CountKM
        {
            get
            {
                return _model.CountKM;
            }
            set
            {
                _model.CountKM = value;
                OnPropertyChanged(nameof(CountKM));
            }
        }

        public string FK_Itinerary
        {
            get
            {
                return _model.FK_Itinerary;
            }
            set
            {
                _model.FK_Itinerary = value;
                OnPropertyChanged(nameof(FK_Itinerary));
            }
        }
        public string FK_Regiona
        {
            get
            {
                return _model.FK_Regiona;
            }
            set
            {
                _model.FK_Regiona = value;
                OnPropertyChanged(nameof(FK_Regiona));
            }
        }


    }
}
