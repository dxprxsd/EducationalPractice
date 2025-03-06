using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.Views;
using ReactiveUI;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ViewModel для экрана организатора.
    /// </summary>
    public class OrganizerScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Organizer _organizer; // Свойство для текущего организатора

        /// <summary>
        /// Приветствие для организатора в зависимости от времени суток.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// Список мероприятий для отображения на экране организатора.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// Текущий организатор, чьи данные отображаются на экране.
        /// </summary>
        public Organizer Organizer
        {
            get => _organizer;
            set => this.RaiseAndSetIfChanged(ref _organizer, value);
        }

        /// <summary>
        /// Конструктор для инициализации ViewModel с данными организатора.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="organizer">Организатор, чьи данные будут отображаться.</param>
        /// <exception cref="ArgumentNullException">Выбрасывается, если организатор равен null.</exception>
        public OrganizerScreenViewModel(InformationsecuritydbContext db, Organizer organizer)
        {
            if (organizer == null)
            {
                throw new ArgumentNullException(nameof(organizer), "Organizer cannot be null.");
            }
            _db = db;
            Organizer = organizer; // Устанавливаем текущего организатора
            LoadOrganizerData(organizer);
            LoadEvents();
        }

        /// <summary>
        /// Метод для загрузки данных организатора (приветствие, пол и имя).
        /// </summary>
        /// <param name="organizer">Объект организатора с данными.</param>
        private void LoadOrganizerData(Organizer organizer)
        {
            if (organizer == null)
                return;

            // Получаем текущий час
            var currentHour = DateTime.Now.Hour;

            // Определяем время суток и корректируем "Доброе"/"Добрый"
            string greetingWord = currentHour < 11 ? "Доброе утро!" :
                                  currentHour < 18 ? "Добрый день!" :
                                  "Добрый вечер!";

            // Определяем обращение по полу (используем Genderid)
            string genderPrefix = organizer.Genderid switch
            {
                1 => "Mr.",  // Мужской
                2 => "Ms.",  // Женский
                _ => ""      // Если пол не указан или неизвестен
            };

            // Получаем имя организатора (если не указано — подставляется заглушка)
            string organizerName = !string.IsNullOrWhiteSpace(organizer.Nameorganizer) ? organizer.Nameorganizer : "Имя не указано";

            // Получаем отчество организатора (если не указано — подставляется пустая строка)
            string organizerPatronymic = !string.IsNullOrWhiteSpace(organizer.Patronymicorganizer) ? organizer.Patronymicorganizer : "";

            // Формируем полное имя с отчеством (если отчество есть)
            string fullName = string.IsNullOrWhiteSpace(organizerPatronymic)
                ? organizerName
                : $"{organizerName} {organizerPatronymic}";

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// Метод для перехода на экран регистрации модераторов и жюри.
        /// </summary>
        public void GoToRegistrModerJuri() => MainWindowViewModel.Self.Us = new RegistrationJuriModersScreen();

        /// <summary>
        /// Метод для загрузки списка мероприятий.
        /// </summary>
        private void LoadEvents()
        {
            // Загружаем все мероприятия из базы данных и присваиваем их в свойство Events
            Events = new ObservableCollection<Meropriyatie>(_db.Meropriyaties.ToList());
        }

        /// <summary>
        /// Переходит на главный экран.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
