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
    public class OrganizerScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Organizer _organizer; // Свойство для текущего организатора

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

        public Organizer Organizer
        {
            get => _organizer;
            set => this.RaiseAndSetIfChanged(ref _organizer, value);
        }

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

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }

        public void GoToRegistrModerJuri() => MainWindowViewModel.Self.Us = new RegistrationJuriModersScreen();

        private void LoadEvents()
        {
            Events = new ObservableCollection<Meropriyatie>(_db.Meropriyaties.ToList());
        }
    }
}
