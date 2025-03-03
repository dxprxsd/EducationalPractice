using Microsoft.Extensions.Logging;
using ReactiveUI;
using System.Collections.ObjectModel;
using System;
using conferenceProgInfSecurity.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Avalonia.Controls;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private ObservableCollection<Sobitie> _events;
        private string _filter;
        private UserControl _us;
        public static MainWindowViewModel Self;
        List<Meropriyatie> meropriyaties;

        public ObservableCollection<Sobitie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        public List<Meropriyatie> Meropriyaties
        {
            get => meropriyaties;
            set => this.RaiseAndSetIfChanged(ref meropriyaties, value);
        }

        public UserControl Us
        {
            get => _us;
            set => this.RaiseAndSetIfChanged(ref _us, value);
        }

        public string Filter
        {
            get => _filter;
            set
            {
                this.RaiseAndSetIfChanged(ref _filter, value);
                ApplyFilter();
            }
        }

        public MainWindowViewModel(InformationsecuritydbContext db)
        {
            _db = db;
            Self = this;
            Us = new MainScreen(); // ЭКРАН НАЧАЛА ПРОГРАММЫ
            //Us = new Login(_db, this); // ЭКРАН НАЧАЛА ПРОГРАММЫ
            LoadEvents();
            // Создание LoginViewModel с передачей Self
            //Us.DataContext = loginViewModel; // Устанавливаем DataContext для экрана входа
            //var loginViewModel = new LoginViewModel(_db, this);
            this.meropriyaties = db.Meropriyaties.ToList();
        }

        private void LoadEvents()
        {
            Events = new ObservableCollection<Sobitie>(_db.Sobities.Where(s => s.Idsobitie > 0).ToList());
        }

        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(Filter)) return;
            Events = new ObservableCollection<Sobitie>(_db.Sobities.Where(e => e.Sobitiename.Contains(Filter, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        public void GoToLoginScreen()
        {
            var loginViewModel = new LoginViewModel(_db, this);
            Us = new Login { DataContext = loginViewModel };
        }

        public void GoToOrganizerScreen(Organizer organizer)
        {
            Us = new OrganizerScreen { DataContext = new OrganizerScreenViewModel(_db, organizer) };
        }

        // Метод для перехода на MainScreen
        public void GoToMainsScreen()
        {
            // Переход на MainScreen
            Us = new MainScreen(); // Пример, замените на вашу логику
        }
    }
}
