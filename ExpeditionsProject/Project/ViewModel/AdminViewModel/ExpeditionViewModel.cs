using ExpeditionsProject.Project.Commands.DopExpeditionCommand;
using ExpeditionsProject.Project.Commands.Expedition;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using ExpeditionsProject.Project.Model.AdminModel.Expedition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel
{
    internal class ExpeditionViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        ExpeditionModel _model = new ExpeditionModel();
        ExspeditionToItineraryModel _Imodel = new ExspeditionToItineraryModel();



        public ExpeditionViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(_viewModelStore, dataWork); });

            CompletionExpedition = new ExpeditionCommand(this, dataWork);
            CompletionExspeditionToItinerary = new ExpeditionToItineraryComand(this, dataWork);
        }
        public ExpeditionViewModel(ExpeditionModel model, ExspeditionToItineraryModel Imodel)
        {

            _model = model;
            _Imodel = Imodel;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionExpedition { get; set; }
        public ICommand CompletionExspeditionToItinerary { get; set; }

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

        public string FK_Menu
        {
            get
            {
                return _model.FK_Menu;
            }
            set
            {
                _model.FK_Menu = value;
                OnPropertyChanged(nameof(FK_Menu));
            }
        }

        public string FK_Equipment
        {
            get
            {
                return _model.FK_Equipment;
            }
            set
            {
                _model.CountEquipment = value;
                OnPropertyChanged(nameof(FK_Equipment));
            }
        }
        public string FK_Transfera
        {
            get
            {
                return _model.FK_Transfera;
            }
            set
            {
                _model.FK_Transfera = value;
                OnPropertyChanged(nameof(FK_Transfera));
            }
        }
        public string CounMenu
        {
            get
            {
                return _model.CounMenu;
            }
            set
            {
                _model.CounMenu = value;
                OnPropertyChanged(nameof(CounMenu));
            }
        }
        public string CountEquipment
        {
            get
            {
                return _model.CountEquipment;
            }
            set
            {
                _model.CountEquipment = value;
                OnPropertyChanged(nameof(CountEquipment));
            }
        }

        public string DateStart
        {
            get
            {
                return _model.DateStart;
            }
            set
            {
                _model.DateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }
        public string DateFinish
        {
            get
            {
                return _model.DateFinish;
            }
            set
            {
                _model.DateFinish = value;
                OnPropertyChanged(nameof(DateFinish));
            }
        }



        public string FK_Expedition
        {
            get
            {
                return _Imodel.FK_Expedition;
            }
            set
            {
                _Imodel.FK_Expedition = value;
                OnPropertyChanged(nameof(FK_Expedition));
            }
        }

        public string FK_PointToItinerary
        {
            get
            {
                return _Imodel.FK_PointToItinerary;
            }
            set
            {
                _Imodel.FK_PointToItinerary = value;
                OnPropertyChanged(nameof(FK_PointToItinerary));
            }
        }

        public string Time
        {
            get
            {
                return _Imodel.Time;
            }
            set
            {
                _Imodel.Time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public string Date
        {
            get
            {
                return _Imodel.Date;
            }
            set
            {
                _Imodel.FK_PointToItinerary = value;
                OnPropertyChanged(nameof(FK_PointToItinerary));
            }
        }






    }
    
}
