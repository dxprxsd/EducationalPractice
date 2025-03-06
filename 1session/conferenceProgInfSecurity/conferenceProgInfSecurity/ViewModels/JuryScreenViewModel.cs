using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// Модель экрана жюри.
    /// </summary>
    public class JuryScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Jury _jury; // Свойство для текущего организатора

        /// <summary>
        /// Приветственное сообщение для жюри.
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
        /// Свойство для текущего жюри.
        /// </summary>
        public Jury Jury
        {
            get => _jury;
            set => this.RaiseAndSetIfChanged(ref _jury, value);
        }

        /// <summary>
        /// Конструктор модели экрана жюри.
        /// </summary>
        /// <param name="db">Контекст базы данных.</param>
        /// <param name="jury">Текущее жюри.</param>
        /// <exception cref="ArgumentNullException">Если жюри равно null.</exception>
        public JuryScreenViewModel(InformationsecuritydbContext db, Jury jury)
        {
            if (jury == null)
            {
                throw new ArgumentNullException(nameof(jury), "jury cannot be null.");
            }
            _db = db;
            Jury = jury; // Устанавливаем текущего организатора
            LoadJuryData(jury);
            //LoadEvents();
        }

        /// <summary>
        /// Загружает данные для жюри и устанавливает приветственное сообщение.
        /// </summary>
        /// <param name="jury">Текущее жюри.</param>
        private void LoadJuryData(Jury jury)
        {
            if (jury == null)
                return;

            // Получаем текущий час
            var currentHour = DateTime.Now.Hour;

            // Определяем время суток и корректируем "Доброе"/"Добрый"
            string greetingWord = currentHour < 11 ? "Доброе утро!" :
                                  currentHour < 18 ? "Добрый день!" :
                                  "Добрый вечер!";

            // Определяем обращение по полу (используем Genderid)
            string genderPrefix = jury.Genderid switch
            {
                1 => "Mr.",  // Мужской
                2 => "Ms.",  // Женский
                _ => ""      // Если пол не указан или неизвестен
            };

            // Получаем имя организатора (если не указано — подставляется заглушка)
            string juryName = !string.IsNullOrWhiteSpace(jury.Namejury) ? jury.Namejury : "Имя не указано";

            // Получаем отчество организатора (если не указано — подставляется пустая строка)
            string juryPatronymic = !string.IsNullOrWhiteSpace(jury.Patronymicjury) ? jury.Patronymicjury : "";

            // Формируем полное имя с отчеством (если отчество есть)
            string fullName = string.IsNullOrWhiteSpace(juryPatronymic)
                ? juryName
                : $"{juryName} {juryPatronymic}";

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// Выход на главный экран.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
