using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Model.AdminModel.PointModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    internal class CompletionPointPointToItineraryViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionPointPointToItineraryModel _model = new CompletionPointPointToItineraryModel();
        


        public CompletionPointPointToItineraryViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelPointViewModel(_viewModelStore, dataWork); });

            CompletionPointToItinerary = new CompletionPointToItineraryCommand (this, dataWork);
        }
        public CompletionPointPointToItineraryViewModel(CompletionPointPointToItineraryModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionPointToItinerary { get; set; }

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

        public string FK_Point
        {
            get
            {
                return _model.FK_Point;
            }
            set
            {
                _model.FK_Point = value;
                OnPropertyChanged(nameof(FK_Point));
            }
        }

        public string FK_TypePoint
        {
            get
            {
                return _model.FK_TypePoint;
            }
            set
            {
                _model.FK_TypePoint = value;
                OnPropertyChanged(nameof(FK_TypePoint));
            }
        }

        public string DateToPoint
        {
            get
            {
                return _model.DateToPoint;
            }
            set
            {
                _model.DateToPoint = value;
                OnPropertyChanged(nameof(DateToPoint));
            }
        }

        public string TimeToPoint
        {
            get
            {
                return _model.TimeToPoint;
            }
            set
            {
                _model.TimeToPoint = value;
                OnPropertyChanged(nameof(TimeToPoint));
            }
        }

        public string DayToPoint
        {
            get
            {
                return _model.DayToPoint;
            }
            set
            {
                _model.DayToPoint = value;
                OnPropertyChanged(nameof(DayToPoint));
            }
        }


    }
}
