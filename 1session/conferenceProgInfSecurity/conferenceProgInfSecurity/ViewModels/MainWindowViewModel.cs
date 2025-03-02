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

        public ObservableCollection<Sobitie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
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
            Us = new MainScreen(); // Инициализация MainScreen
            LoadEvents();
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

        public void GoToLoginScreen() => Us = new Login();
    }
}
