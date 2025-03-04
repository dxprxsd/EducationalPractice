using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// Модель экрана модератора.
    /// </summary>
    public class ModeratorScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Moderator _moderator; // Свойство для текущего модератора

        /// <summary>
        /// Приветственное сообщение для модератора.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// Список мероприятий.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// Свойство для текущего модератора.
        /// </summary>
        public Moderator Moderator
        {
            get => _moderator;
            set => this.RaiseAndSetIfChanged(ref _moderator, value);
        }

        /// <summary>
        /// Конструктор модели экрана модератора.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="moderator">Текущий модератор.</param>
        /// <exception cref="ArgumentNullException">Если модератор равен null.</exception>
        public ModeratorScreenViewModel(InformationsecuritydbContext db, Moderator moderator)
        {
            if (moderator == null)
            {
                throw new ArgumentNullException(nameof(moderator), "moderator cannot be null.");
            }
            _db = db;
            Moderator = moderator; // Устанавливаем текущего организатора
            LoadModeratorData(moderator);
            //LoadEvents();
        }

        /// <summary>
        /// Загружает данные для модератора и устанавливает приветственное сообщение.
        /// </summary>
        /// <param name="moderator">Текущий модератор.</param>
        private void LoadModeratorData(Moderator moderator)
        {
            if (moderator == null)
                return;

            // Получаем текущий час
            var currentHour = DateTime.Now.Hour;

            // Определяем время суток и корректируем "Доброе"/"Добрый"
            string greetingWord = currentHour < 11 ? "Доброе утро!" :
                                  currentHour < 18 ? "Добрый день!" :
                                  "Добрый вечер!";

            // Определяем обращение по полу (используем Genderid)
            string genderPrefix = moderator.Genderid switch
            {
                1 => "Mr.",  // Мужской
                2 => "Ms.",  // Женский
                _ => ""      // Если пол не указан или неизвестен
            };

            // Получаем имя организатора (если не указано — подставляется заглушка)
            string organizerName = !string.IsNullOrWhiteSpace(moderator.Namemoderator) ? moderator.Namemoderator : "Имя не указано";

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }

        /// <summary>
        /// Выход на главный экран.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
