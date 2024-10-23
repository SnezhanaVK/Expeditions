using ExpeditionsProject.Project.ViewModel;
using ExpeditionsProject.Project;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ExpeditionsProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private ViewModelStore _viewModelStore;
        private DataWork _dataWork;
        private readonly string _connectionString = "Data Source=LAPTOP-6AHT87V0;Initial Catalog=Тур-агенства;User ID=sa;Password=cndjvbhdt6r3t;Integrated Security=False;TrustServerCertificate=True";
        public App()
        {
            _viewModelStore = new ViewModelStore();
            _dataWork = new DataWork(_connectionString);
            _viewModelStore.CurrentViewModel = new StartViewModel(_viewModelStore,_dataWork);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_viewModelStore,_dataWork)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }



}
    

