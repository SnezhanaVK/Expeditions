using ExpeditionsProject.Project.Model.AdminModel.AdminTabe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.AdminTable
{
    internal class PointAdminTableViewModel : ViewModelBase
    {
        private readonly ViewModelStore _viewModelStore;
        private readonly DataWork _dataWork;
        PointAdminTableModel model = new PointAdminTableModel();
        ExpeditionTibleModel _selectedExpedition;
  

        public ICommand Back { get; set; }


        public PointAdminTableViewModel(ViewModelStore viewModelStore, DataWork dataWork, int id)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;

            Back = new NavigateCommand(_viewModelStore, () => { return new ExpeditionTibelViewModel(_viewModelStore, dataWork); });
           
            RunTableInstrucror(id);
           


        }
        private void RunTableInstrucror(int id)
        {
            RouteInfos = _dataWork.GetPointsByExpedition(id);
            OnPropertyChanged(nameof(RouteInfos)); // Уведомляем WPF о том, что данные изменились
        }
        public List<PointAdminTableModel> RouteInfos { get; private set; }

        public PointAdminTableViewModel(PointAdminTableModel _model)
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
