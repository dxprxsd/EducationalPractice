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
    /// ViewModel ��� ������ ������������.
    /// </summary>
    public class OrganizerScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Organizer _organizer; // �������� ��� �������� ������������

        /// <summary>
        /// ����������� ��� ������������ � ����������� �� ������� �����.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// ������ ����������� ��� ����������� �� ������ ������������.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// ������� �����������, ��� ������ ������������ �� ������.
        /// </summary>
        public Organizer Organizer
        {
            get => _organizer;
            set => this.RaiseAndSetIfChanged(ref _organizer, value);
        }

        /// <summary>
        /// ����������� ��� ������������� ViewModel � ������� ������������.
        /// </summary>
        /// <param name="db">�������� ���� ������.</param>
        /// <param name="organizer">�����������, ��� ������ ����� ������������.</param>
        /// <exception cref="ArgumentNullException">�������������, ���� ����������� ����� null.</exception>
        public OrganizerScreenViewModel(InformationsecuritydbContext db, Organizer organizer)
        {
            if (organizer == null)
            {
                throw new ArgumentNullException(nameof(organizer), "Organizer cannot be null.");
            }
            _db = db;
            Organizer = organizer; // ������������� �������� ������������
            LoadOrganizerData(organizer);
            LoadEvents();
        }

        /// <summary>
        /// ����� ��� �������� ������ ������������ (�����������, ��� � ���).
        /// </summary>
        /// <param name="organizer">������ ������������ � �������.</param>
        private void LoadOrganizerData(Organizer organizer)
        {
            if (organizer == null)
                return;

            // �������� ������� ���
            var currentHour = DateTime.Now.Hour;

            // ���������� ����� ����� � ������������ "������"/"������"
            string greetingWord = currentHour < 11 ? "������ ����!" :
                                  currentHour < 18 ? "������ ����!" :
                                  "������ �����!";

            // ���������� ��������� �� ���� (���������� Genderid)
            string genderPrefix = organizer.Genderid switch
            {
                1 => "Mr.",  // �������
                2 => "Ms.",  // �������
                _ => ""      // ���� ��� �� ������ ��� ����������
            };

            // �������� ��� ������������ (���� �� ������� � ������������� ��������)
            string organizerName = !string.IsNullOrWhiteSpace(organizer.Nameorganizer) ? organizer.Nameorganizer : "��� �� �������";

            // �������� �������� ������������ (���� �� ������� � ������������� ������ ������)
            string organizerPatronymic = !string.IsNullOrWhiteSpace(organizer.Patronymicorganizer) ? organizer.Patronymicorganizer : "";

            // ��������� ������ ��� � ��������� (���� �������� ����)
            string fullName = string.IsNullOrWhiteSpace(organizerPatronymic)
                ? organizerName
                : $"{organizerName} {organizerPatronymic}";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// ����� ��� �������� �� ����� ����������� ����������� � ����.
        /// </summary>
        public void GoToRegistrModerJuri() => MainWindowViewModel.Self.Us = new RegistrationJuriModersScreen();

        /// <summary>
        /// ����� ��� �������� ������ �����������.
        /// </summary>
        private void LoadEvents()
        {
            // ��������� ��� ����������� �� ���� ������ � ����������� �� � �������� Events
            Events = new ObservableCollection<Meropriyatie>(_db.Meropriyaties.ToList());
        }

        /// <summary>
        /// ��������� �� ������� �����.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
