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
using HarfBuzzSharp;

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

        List<Models.Direction> directionOptions;

        Models.Direction directionOneOption;

        Meropriyatie meropriyatiess;

        Models.Direction directions;

        Jury juries;

        Meropriyatieandactivity meropriyatieandactivities;

        public List<Models.Direction> DirectionOptions { 
            get => directionOptions; 
            set => this.RaiseAndSetIfChanged(ref directionOptions, value); 
        }

        public Models.Direction DirectionOneOption { 
            get => directionOneOption; 
            set { this.RaiseAndSetIfChanged(ref directionOneOption, value); allFilter(); } 
        }

        public ObservableCollection<Sobitie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        public Jury Juries
        {
            get => juries;
            set => this.RaiseAndSetIfChanged(ref juries, value);
        }

        public Models.Direction Directions
        {
            get => directions;
            set => this.RaiseAndSetIfChanged(ref directions, value);
        }

        public Meropriyatieandactivity Meropriyatieandactivities
        {
            get => meropriyatieandactivities;
            set => this.RaiseAndSetIfChanged(ref meropriyatieandactivities, value);
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
            DirectionOptions = db.Directions.ToList();
            this.meropriyaties = db.Meropriyaties.Include(x => x.Directions).ToList();

            meropriyatiess = new Meropriyatie();

            meropriyatiess.Meropriyatiedate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public DateTimeOffset DateOfMeropriyatie
        {
            get => new DateTimeOffset((DateTime)meropriyatiess.Meropriyatiedate, TimeSpan.Zero);

            set { meropriyatiess.Meropriyatiedate = new DateTime(value.Year, value.Month, value.Day); allFilter(); }
        }
        /// <summary>
        /// Метод для фильтрации мероприятий по дате
        /// </summary>
        public void allFilter()
        {
            Meropriyaties = _db.Meropriyaties.ToList();

            DateTime dateTimeMeropriyatie = new DateTime(DateOfMeropriyatie.Year, DateOfMeropriyatie.Month, DateOfMeropriyatie.Day);
            Meropriyaties = meropriyaties.Where(x => x.Meropriyatiedate == dateTimeMeropriyatie && x.Directionsid == DirectionOneOption.Iddirections).ToList();
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
        /// <summary>
        /// Метод для перехода на LoginScreen
        /// </summary> 
        public void GoToLoginScreen()
        {
            var loginViewModel = new LoginViewModel(_db, this);
            Us = new Login { DataContext = loginViewModel };
        }
        /// <summary>
        /// Метод для перехода на OrganizerScreen
        /// </summary> 
        public void GoToOrganizerScreen(Organizer organizer)
        {
            Us = new OrganizerScreen { DataContext = new OrganizerScreenViewModel(_db, organizer) };
        }

        /// <summary>
        /// Метод для перехода на MainScreen
        /// </summary> 
        public void GoToMainsScreen()
        {
            // Переход на MainScreen
            Us = new MainScreen(); // Пример, замените на вашу логику
        }        
    }
}
