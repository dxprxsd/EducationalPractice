using Avalonia.Controls;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.ViewModels;

namespace conferenceProgInfSecurity.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var _db = new InformationsecuritydbContext(); // Создаем экземпляр БД
            InitializeComponent();
            var mainWindowViewModel = new MainWindowViewModel(_db);
            DataContext = new MainWindowViewModel(_db);
        }
    }
}