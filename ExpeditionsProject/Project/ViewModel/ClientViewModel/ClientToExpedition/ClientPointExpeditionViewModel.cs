using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using ExpeditionsProject.Project.Model.ClientModel.ClientToExpedition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.ClientViewModel.ClientToExpedition
{
    internal class ClientPointExpeditionViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        PointAdminTableModel model = new PointAdminTableModel();
        public int ID_Client {  get; set; }
        public int ID_Expedition {  get; set; }

        public ICommand Back { get; set; }
        public ICommand Next { get; set; }
        public ICommand SelectExpeditionCommand { get; private set; }


        public ClientPointExpeditionViewModel(ViewModelStore viewModelStore, DataWork dataWork, int idClient, int idExpedition)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;
            ID_Client = idClient;
            ID_Expedition = idExpedition;


            Back = new NavigateCommand(_viewModelStore, () => { return new ClientMenuInfoExpeditionViewModel(_viewModelStore, dataWork, idClient, idExpedition); });

            RunTableInstrucror(idExpedition);

           




        }


        private void RunTableInstrucror(int idExpedition)
        {
            RouteInfos = _dataWork.GetPointsByExpedition(idExpedition);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<PointAdminTableModel> RouteInfos { get; private set; }

        public ClientPointExpeditionViewModel(PointAdminTableModel _model)
        {
            model = _model;
        }
     


        public int ID_Point
        {
            get
            {
                return model.ID_Point;
            }
            set
            {
                model.ID_Point = value;
                OnPropertyChanged(nameof(ID_Point));
            }
        }

        public string NamePoint
        {
            get
            {
                return model.NamePoint;
            }
            set
            {
                model.NamePoint = value;
                OnPropertyChanged(nameof(NamePoint));
            }
        }

        public DateTime DateToPoint
        {
            get
            {
                return model.DateToPoint;
            }
            set
            {
                model.DateToPoint = value;
                OnPropertyChanged(nameof(DateToPoint));
            }
        }


        public int DayToPoint
        {
            get
            {
                return model.DayToPoint;
            }
            set
            {
                model.DayToPoint = value;
                OnPropertyChanged(nameof(DayToPoint));
            }
        }

        public string NameTypePoint
        {
            get
            {
                return model.NameTypePoint;
            }
            set
            {
                model.NameTypePoint = value;
                OnPropertyChanged(nameof(DayToPoint));
            }
        }
       


    }
}





