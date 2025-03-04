using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ViewModel для экрана входа.
    /// Обрабатывает аутентификацию пользователя и переходы на соответствующие экраны.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _idClient;
        private string _password;
        private string _errorMessage;

        /// <summary>
        /// Команда для выполнения аутентификации.
        /// </summary>
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        // Добавьте ссылку на вашу модель MainWindowViewModel
        private readonly MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// Идентификатор клиента для входа.
        /// </summary>
        public string IdClient
        {
            get => _idClient;
            set => this.RaiseAndSetIfChanged(ref _idClient, value);
        }

        /// <summary>
        /// Пароль для входа.
        /// </summary>
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        /// <summary>
        /// Сообщение об ошибке или успешной аутентификации.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        /// <summary>
        /// Конструктор для инициализации ViewModel для экрана входа.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="mainWindowViewModel">ViewModel главного окна.</param>
        public LoginViewModel(InformationsecuritydbContext db, MainWindowViewModel mainWindowViewModel)
        {
            _db = db;
            _mainWindowViewModel = mainWindowViewModel ?? throw new ArgumentNullException(nameof(mainWindowViewModel));  // Проверка на null
            LoginCommand = ReactiveCommand.Create(Authenticate);
        }

        /// <summary>
        /// Переход на основной экран приложения.
        /// </summary>
        public void GoToMainScreen() => _mainWindowViewModel.Us = new MainScreen();

        /// <summary>
        /// Метод для аутентификации пользователя.
        /// Проверяет введенные данные и перенаправляет на соответствующий экран.
        /// </summary>
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
                        GoToClientScreen(client); // Переход на экран клиента
                    }
                    else if (organizer != null)
                    {
                        ErrorMessage = "Успешный вход как организатор!";
                        GoToOrganizerScreen(organizer); // Переход на экран организатора
                    }
                    else if (moderator != null)
                    {
                        ErrorMessage = "Успешный вход как модератор!";
                        GoToModeratorScreen(moderator); // Переход на экран модератора
                    }
                    else if (jury != null)
                    {
                        ErrorMessage = "Успешный вход как жюри!";
                        GoToJuryScreen(jury); // Переход на экран жюри
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

        /// <summary>
        /// Переход на экран организатора.
        /// </summary>
        /// <param name="organizer">Организатор.</param>
        private void GoToOrganizerScreen(Organizer organizer)
        {
            // Создаем новый ViewModel для экрана организатора
            var organizerScreenViewModel = new OrganizerScreenViewModel(_db, organizer);
            // Переходим на экран организатора
            _mainWindowViewModel.Us = new OrganizerScreen { DataContext = organizerScreenViewModel };
        }

        /// <summary>
        /// Переход на экран клиента.
        /// </summary>
        /// <param name="client">Клиент.</param>
        private void GoToClientScreen(Client client)
        {
            // Создаем новый ViewModel для экрана клиента
            var clientScreenViewModel = new ClientScreenViewModel(_db, client);
            // Переходим на экран клиента
            _mainWindowViewModel.Us = new ClientScreen { DataContext = clientScreenViewModel };
        }

        /// <summary>
        /// Переход на экран жюри.
        /// </summary>
        /// <param name="jury">Член жюри.</param>
        private void GoToJuryScreen(Jury jury)
        {
            // Создаем новый ViewModel для экрана жюри
            var juryScreenViewModel = new JuryScreenViewModel(_db, jury);
            // Переходим на экран жюри
            _mainWindowViewModel.Us = new JuryScreen { DataContext = juryScreenViewModel };
        }

        /// <summary>
        /// Переход на экран модератора.
        /// </summary>
        /// <param name="moderator">Модератор.</param>
        private void GoToModeratorScreen(Moderator moderator)
        {
            // Создаем новый ViewModel для экрана модератора
            var moderatorScreenViewModel = new ModeratorScreenViewModel(_db, moderator);
            // Переходим на экран модератора
            _mainWindowViewModel.Us = new ModeratorScreen { DataContext = moderatorScreenViewModel };
        }
    }
}
