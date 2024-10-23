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
    internal class CompletionPointPointViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        CompletionPointPointModel _model = new CompletionPointPointModel();



        public CompletionPointPointViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelPointViewModel(_viewModelStore, dataWork); });

            CompletionPoint = new CompletionPointCommand(this, dataWork);
        }
        public CompletionPointPointViewModel(CompletionPointPointModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionPoint { get; set; }

        public string NamePoint
        {
            get
            {
                return _model.NamePoint;
            }
            set
            {
                _model.NamePoint = value;
                OnPropertyChanged(nameof(NamePoint));
            }
        }

        public string DescriptionPoint
        {
            get
            {
                return _model.DescriptionPoint;
            }
            set
            {
                _model.DescriptionPoint = value;
                OnPropertyChanged(nameof(DescriptionPoint));
            }
        }
    }
    
    
}
