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
    /// <summary>
    /// Основной ViewModel для окна программы, отвечающий за загрузку данных и навигацию по экранам.
    /// </summary>
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

        /// <summary>
        /// Список направлений для фильтрации мероприятий.
        /// </summary>
        public List<Models.Direction> DirectionOptions
        {
            get => directionOptions;
            set => this.RaiseAndSetIfChanged(ref directionOptions, value);
        }

        /// <summary>
        /// Направление для фильтрации мероприятий.
        /// </summary>
        public Models.Direction DirectionOneOption
        {
            get => directionOneOption;
            set { this.RaiseAndSetIfChanged(ref directionOneOption, value); allFilter(); }
        }

        /// <summary>
        /// Коллекция мероприятий.
        /// </summary>
        public ObservableCollection<Sobitie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// Жюри, участвующее в мероприятии.
        /// </summary>
        public Jury Juries
        {
            get => juries;
            set => this.RaiseAndSetIfChanged(ref juries, value);
        }

        /// <summary>
        /// Направление мероприятия.
        /// </summary>
        public Models.Direction Directions
        {
            get => directions;
            set => this.RaiseAndSetIfChanged(ref directions, value);
        }

        /// <summary>
        /// Информация о мероприятии и активности.
        /// </summary>
        public Meropriyatieandactivity Meropriyatieandactivities
        {
            get => meropriyatieandactivities;
            set => this.RaiseAndSetIfChanged(ref meropriyatieandactivities, value);
        }

        /// <summary>
        /// Список мероприятий.
        /// </summary>
        public List<Meropriyatie> Meropriyaties
        {
            get => meropriyaties;
            set => this.RaiseAndSetIfChanged(ref meropriyaties, value);
        }

        /// <summary>
        /// Контроллер текущего экрана.
        /// </summary>
        public UserControl Us
        {
            get => _us;
            set => this.RaiseAndSetIfChanged(ref _us, value);
        }

        /// <summary>
        /// Строка фильтра для поиска мероприятий.
        /// </summary>
        public string Filter
        {
            get => _filter;
            set
            {
                this.RaiseAndSetIfChanged(ref _filter, value);
                ApplyFilter();
            }
        }

        /// <summary>
        /// Конструктор ViewModel для главного окна программы.
        /// </summary>
        /// <param name="db">Контекст базы данных для загрузки данных.</param>
        public MainWindowViewModel(InformationsecuritydbContext db)
        {
            _db = db;
            Self = this;
            Us = new MainScreen(); // Экран начала программы
            LoadEvents();
            DirectionOptions = db.Directions.ToList();
            this.meropriyaties = db.Meropriyaties.Include(x => x.Directions).ToList();
            meropriyatiess = new Meropriyatie
            {
                Meropriyatiedate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };
        }

        /// <summary>
        /// Дата мероприятия, которая используется для фильтрации.
        /// </summary>
        public DateTimeOffset DateOfMeropriyatie
        {
            get => new DateTimeOffset((DateTime)meropriyatiess.Meropriyatiedate, TimeSpan.Zero);
            set
            {
                meropriyatiess.Meropriyatiedate = new DateTime(value.Year, value.Month, value.Day);
                allFilter();
            }
        }

        /// <summary>
        /// Метод для фильтрации мероприятий по дате и направлению.
        /// </summary>
        public void allFilter()
        {
            Meropriyaties = _db.Meropriyaties.ToList();

            DateTime dateTimeMeropriyatie = new DateTime(DateOfMeropriyatie.Year, DateOfMeropriyatie.Month, DateOfMeropriyatie.Day);
            Meropriyaties = meropriyaties.Where(x => x.Meropriyatiedate == dateTimeMeropriyatie && x.Directionsid == DirectionOneOption.Iddirections).ToList();
        }

        /// <summary>
        /// Загружает мероприятия из базы данных.
        /// </summary>
        private void LoadEvents()
        {
            Events = new ObservableCollection<Sobitie>(_db.Sobities.Where(s => s.Idsobitie > 0).ToList());
        }

        /// <summary>
        /// Применяет фильтр для поиска мероприятий по названию.
        /// </summary>
        private void ApplyFilter()
        {
            if (string.IsNullOrWhiteSpace(Filter)) return;
            Events = new ObservableCollection<Sobitie>(_db.Sobities.Where(e => e.Sobitiename.Contains(Filter, StringComparison.OrdinalIgnoreCase)).ToList());
        }

        /// <summary>
        /// Метод для перехода на экран логина.
        /// </summary>
        public void GoToLoginScreen()
        {
            var loginViewModel = new LoginViewModel(_db, this);
            Us = new Login { DataContext = loginViewModel };
        }

        /// <summary>
        /// Метод для перехода на экран организатора.
        /// </summary>
        /// <param name="organizer">Объект организатора для передачи данных в экран.</param>
        public void GoToOrganizerScreen(Organizer organizer)
        {
            Us = new OrganizerScreen { DataContext = new OrganizerScreenViewModel(_db, organizer) };
        }

        /// <summary>
        /// Метод для перехода на главный экран.
        /// </summary>
        public void GoToMainsScreen()
        {
            Us = new MainScreen(); // Пример, замените на вашу логику
        }
    }
}
