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
    internal class CompletionPointTypePointViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionPointTypePointModel _model = new CompletionPointTypePointModel();



        public CompletionPointTypePointViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelPointViewModel(_viewModelStore, dataWork); });

            CompletionTypePoint = new CompletionTypePointCommand(this, dataWork);
        }
        public CompletionPointTypePointViewModel(CompletionPointTypePointModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionTypePoint { get; set; }

        public string NameTypePoint
        {
            get
            {
                return _model.NameTypePoint;
            }
            set
            {
                _model.NameTypePoint = value;
                OnPropertyChanged(nameof(NameTypePoint));
            }
        }

        public string DescriptionTypePoint
        {
            get
            {
                return _model.DescriptionTypePoint;
            }
            set
            {
                _model.DescriptionTypePoint = value;
                OnPropertyChanged(nameof(DescriptionTypePoint));
            }
        }
    }
}
