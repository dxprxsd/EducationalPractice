using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.ViewModels;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity
{
    public partial class App : Application
    {

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var dbContext = new InformationsecuritydbContext(); // Создаем экземпляр БД
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(dbContext),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}