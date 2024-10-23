using ExpeditionsProject.Project.Commands;
using ExpeditionsProject.Project.Commands.DopExpeditionCommand;
using ExpeditionsProject.Project.Model.AdminModel;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel
{
    internal class TransferViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        TransferModel _model = new TransferModel();



        public TransferViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;


            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelDopExpeditionViewModel(_viewModelStore, dataWork); });

            CompletionTransfer = new TransferCommand(this, dataWork);
        }
        public TransferViewModel(TransferModel model)
        {

            _model = model;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionTransfer { get; set; }

        public string Date
        {
            get
            {
                return _model.Date;
            }
            set
            {
                _model.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string TimeStart
        {
            get
            {
                return _model.TimeStart;
            }
            set
            {
                _model.TimeStart = value;
                OnPropertyChanged(nameof(TimeStart));
            }
        }
        public string TimeFinish
        {
            get
            {
                return _model.TimeFinish;
            }
            set
            {
                _model.TimeFinish = value;
                OnPropertyChanged(nameof(TimeFinish));
            }
        }
        public string Prise
        {
            get
            {
                return _model.Prise;
            }
            set
            {
                _model.Prise = value;
                OnPropertyChanged(nameof(Prise));
            }
        }
    }
    
    
}
