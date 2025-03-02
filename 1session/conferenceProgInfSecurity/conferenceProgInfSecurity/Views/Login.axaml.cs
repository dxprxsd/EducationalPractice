using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.ViewModels;

namespace conferenceProgInfSecurity.Views
{
    public partial class Login : UserControl
    {
        public Login()
        {
            var _db = new InformationsecuritydbContext(); // Создаем экземпляр БД
            InitializeComponent();
            DataContext = new LoginViewModel(_db);
        }
    }
}

