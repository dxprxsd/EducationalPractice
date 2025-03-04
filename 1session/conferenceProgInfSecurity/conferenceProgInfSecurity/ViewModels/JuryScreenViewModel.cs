using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace conferenceProgInfSecurity.ViewModels
{
	public class JuryScreenViewModel : ViewModelBase
	{
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Jury _jury; // Свойство для текущего организатора

        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        public Jury Jury
        {
            get => _jury;
            set => this.RaiseAndSetIfChanged(ref _jury, value);
        }

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
            string organizerName = !string.IsNullOrWhiteSpace(jury.Namejury) ? jury.Namejury : "Имя не указано";

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }
    }
}