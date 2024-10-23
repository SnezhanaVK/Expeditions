using ExpeditionsProject.Project.Commands.DopExpeditionCommand;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel
{
    public class EquipmentViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        EquipmentModel _model= new EquipmentModel();
        EquipmentItineraryModel _Imodel = new EquipmentItineraryModel();



        public EquipmentViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelDopExpeditionViewModel(_viewModelStore, dataWork); });

            CompletionEquipment = new EquipmentCommand(this, dataWork);
            CompletionEquipmentItinerary = new EquipmentItineraryCommand(this, dataWork);
        }
        public EquipmentViewModel(EquipmentModel model, EquipmentItineraryModel Imodel)
        {

            _model = model;
            _Imodel = Imodel;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionEquipment { get; set; }
        public ICommand CompletionEquipmentItinerary { get; set; }

        public string NameEquipment
        {
            get
            {
                return _model.NameEquipment;
            }
            set
            {
                _model.NameEquipment = value;
                OnPropertyChanged(nameof(NameEquipment));
            }
        }

        public string SkillsEquipment
        {
            get
            {
                return _model.SkillsEquipment;
            }
            set
            {
                _model.SkillsEquipment = value;
                OnPropertyChanged(nameof(SkillsEquipment));
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
                OnPropertyChanged(nameof(SkillsEquipment));
            }
        }
        public string FK_Itinerary
        {
            get
            {
                return _Imodel.FK_Itinerary;
            }
            set
            {
                _Imodel.FK_Itinerary = value;
                OnPropertyChanged(nameof(FK_Itinerary));
            }
        }

        public string FK_Equipment
        {
            get
            {
                return _Imodel.FK_Equipment;
            }
            set
            {
                _Imodel.FK_Equipment = value;
                OnPropertyChanged(nameof(FK_Equipment));
            }
        }



    }
}
