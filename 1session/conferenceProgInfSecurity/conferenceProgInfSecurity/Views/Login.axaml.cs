using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.ViewModels;

namespace conferenceProgInfSecurity.Views
{
    public partial class Login : UserControl
    {
        //InformationsecuritydbContext db, MainWindowViewModel mainWindowViewModel
        public Login()
        {
            InitializeComponent();
            //DataContext = new LoginViewModel(db, mainWindowViewModel); // Передаем оба параметра
        }
    }
}
