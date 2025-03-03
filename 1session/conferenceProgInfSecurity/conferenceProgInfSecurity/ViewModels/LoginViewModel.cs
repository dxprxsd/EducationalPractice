using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _idClient;
        private string _password;
        private string _errorMessage;
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        // Добавьте ссылку на вашу модель MainWindowViewModel
        private readonly MainWindowViewModel _mainWindowViewModel;

        public string IdClient
        {
            get => _idClient;
            set => this.RaiseAndSetIfChanged(ref _idClient, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public LoginViewModel(InformationsecuritydbContext db, MainWindowViewModel mainWindowViewModel)
        {
            _db = db;
            _mainWindowViewModel = mainWindowViewModel ?? throw new ArgumentNullException(nameof(mainWindowViewModel));  // Проверка на null
            LoginCommand = ReactiveCommand.Create(Authenticate);
        }

        public void GoToMainScreen() => _mainWindowViewModel.Us = new MainScreen();

        private void Authenticate()
        {
            try
            {
                if (int.TryParse(IdClient, out int userId))
                {
                    // Проверка пользователя в каждой таблице
                    var client = _db.Clients.FirstOrDefault(u => u.Idclient == userId && u.Password == Password);
                    var organizer = _db.Organizers.FirstOrDefault(u => u.Idorganizer == userId && u.Password == Password);
                    var moderator = _db.Moderators.FirstOrDefault(u => u.Moderatorid == userId && u.Password == Password);
                    var jury = _db.Juries.FirstOrDefault(u => u.Juryid == userId && u.Password == Password);

                    if (client != null)
                    {
                        ErrorMessage = "Успешный вход как клиент!";
                        GoToMainScreen(); // Переход на MainScreen
                    }
                    else if (organizer != null)
                    {
                        ErrorMessage = "Успешный вход как организатор!";
                        GoToOrganizerScreen(organizer); // Переход на экран организатора
                    }
                    else if (moderator != null)
                    {
                        ErrorMessage = "Успешный вход как модератор!";
                        GoToMainScreen(); // Переход на MainScreen
                    }
                    else if (jury != null)
                    {
                        ErrorMessage = "Успешный вход как жюри!";
                        GoToMainScreen(); // Переход на MainScreen
                    }
                    else
                    {
                        ErrorMessage = "Неверные данные";
                    }
                }
                else
                {
                    ErrorMessage = "Некорректный формат ID пользователя";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "Произошла ошибка: " + ex.Message;
            }
        }

        // Функция перехода на экран организатора
        private void GoToOrganizerScreen(Organizer organizer)
        {
            // Создаем новый ViewModel для экрана организатора
            var organizerScreenViewModel = new OrganizerScreenViewModel(_db, organizer);
            // Переходим на экран организатора
            _mainWindowViewModel.Us = new OrganizerScreen { DataContext = organizerScreenViewModel };
        }
    }
}
