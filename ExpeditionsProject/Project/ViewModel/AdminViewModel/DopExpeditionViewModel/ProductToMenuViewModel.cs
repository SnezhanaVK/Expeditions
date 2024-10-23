using ExpeditionsProject.Project.Commands.DopExpeditionCommand;
using ExpeditionsProject.Project.Model.AdminModel.DopExpeditionModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExpeditionsProject.Project.ViewModel.AdminViewModel.DopExpeditionViewModel
{
    internal class ProductToMenuViewModel : ViewModelBase
    {
        private readonly DataWork _dataWork;
        private readonly ViewModelStore _viewModelStore;
        ProductToMenuModel _model = new ProductToMenuModel();
        ProductModel _Pmodel = new ProductModel();
        MenuModel _Mmodel = new MenuModel();



        public ProductToMenuViewModel(ViewModelStore viewModelStore, DataWork dataWork)
        {
            _viewModelStore = viewModelStore;
            _dataWork = dataWork;


            Back = new NavigateCommand(_viewModelStore, () => { return new AdminPanelDopExpeditionViewModel(_viewModelStore, dataWork); });

            CompletionProductToMenu = new ProductToMenuCommand(this, dataWork);
            CompletionProduct=new ProductCommand(this,dataWork);
            CompletionMenu = new MenuCommand(this, dataWork);

        }
        public ProductToMenuViewModel(ProductToMenuModel model, ProductModel Pmodel, MenuModel Mmodel)
        {

            _model = model;
            _Pmodel = Pmodel;
            _Mmodel = Mmodel;
        }




        public ICommand Back { get; set; }


        public ICommand CompletionProductToMenu { get; set; }
        public ICommand CompletionProduct { get; set; }
        public ICommand CompletionMenu { get; set; }

        public string NameMenu
        {
            get
            {
                return _Mmodel.NameMenu;
            }
            set
            {
                _Mmodel.NameMenu = value;
                OnPropertyChanged(nameof(NameMenu));
            }
        }
        public string NameProduct
        {
            get
            {
                return _Pmodel.NameProduct;
            }
            set
            {
                _Pmodel.NameProduct = value;
                OnPropertyChanged(nameof(NameProduct));
            }
        }

        public string Count
        {
            get
            {
                return _Pmodel.Count;
            }
            set
            {
                _Pmodel.Count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public string FK_Product
        {
            get
            {
                return _model.FK_Product;
            }
            set
            {
                _model.FK_Product = value;
                OnPropertyChanged(nameof(FK_Product));
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



    }
    
}
