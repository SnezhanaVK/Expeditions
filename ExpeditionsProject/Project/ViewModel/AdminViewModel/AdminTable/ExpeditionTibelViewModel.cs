using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable
{
    internal class ExpeditionTibelViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        ExpeditionTibleModel model = new ExpeditionTibleModel();
        public int ID;

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ExpeditionTibelViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;

            Back = new NavigateCommand(_viewModelStore, () => { return new StartPanelAdminViewModel(_viewModelStore, dataWork); });

            RunTableInstrucror();
            SelectExpeditionCommand = new RelayCommand<ExpeditionTibleModel>(OnSelectExpedition);
            



        }
       
        private void RunTableInstrucror()
        {
            RouteInfos = _dataWork.GetExpeditionData();
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<ExpeditionTibleModel> RouteInfos { get; private set; }

        public ExpeditionTibelViewModel(ExpeditionTibleModel _model)
        {
            model = _model;
        }
        private void OnSelectExpedition(ExpeditionTibleModel selectedExpedition)
        {
            if (selectedExpedition != null)
            {
                // Передаем ID экспедиции в следующее представление
                ID = selectedExpedition.ID_Expedition;

                _viewModelStore.CurrentViewModel = new PointAdminTableViewModel(_viewModelStore,_dataWork,ID);
              
            }
        }


        public int ID_Expedition
        {
            get
            {
                return model.ID_Expedition;
            }
            set
            {
                model.ID_Expedition = value;
                OnPropertyChanged(nameof(ID_Expedition));
            }
        }

        public int ID_Itinerary
        {
            get
            {
                return model.ID_Itinerary;
            }
            set
            {
                model.ID_Itinerary = value;
                OnPropertyChanged(nameof(ID_Itinerary));
            }
        }

        public string NameItinerary
        {
            get
            {
                return model.NameItinerary;
            }
            set
            {
                model.NameItinerary = value;
                OnPropertyChanged(nameof(NameItinerary));
            }
        }

        public DateTime DateStart
        {
            get
            {
                return model.DateStart;
            }
            set
            {
                model.DateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }

        public DateTime DateFinish
        {
            get
            {
                return model.DateFinish;
            }
            set
            {
                model.DateFinish = value;
                OnPropertyChanged(nameof(DateFinish));
            }
        }
        public ExpeditionTibleModel SelectedRoute
        {
            get { return model.SelectedRoute; }
            set
            {
                model.SelectedRoute = value;
                OnPropertyChanged(nameof(SelectedRoute));
                if (SelectedRoute != null)
                {
                    OnSelectExpedition(SelectedRoute);
                }
            }
        }


    }
}
