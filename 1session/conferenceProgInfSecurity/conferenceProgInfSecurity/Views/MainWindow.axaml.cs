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
            DataContext = new MainWindowViewModel(_db);
        }
    }
}