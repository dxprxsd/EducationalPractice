using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ������ ������ ����.
    /// </summary>
    public class JuryScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Jury _jury; // �������� ��� �������� ������������

        /// <summary>
        /// �������������� ��������� ��� ����.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// ������ �����������.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// �������� ��� �������� ����.
        /// </summary>
        public Jury Jury
        {
            get => _jury;
            set => this.RaiseAndSetIfChanged(ref _jury, value);
        }

        /// <summary>
        /// ����������� ������ ������ ����.
        /// </summary>
        /// <param name="db">�������� ���� ������.</param>
        /// <param name="jury">������� ����.</param>
        /// <exception cref="ArgumentNullException">���� ���� ����� null.</exception>
        public JuryScreenViewModel(InformationsecuritydbContext db, Jury jury)
        {
            if (jury == null)
            {
                throw new ArgumentNullException(nameof(jury), "jury cannot be null.");
            }
            _db = db;
            Jury = jury; // ������������� �������� ������������
            LoadJuryData(jury);
            //LoadEvents();
        }

        /// <summary>
        /// ��������� ������ ��� ���� � ������������� �������������� ���������.
        /// </summary>
        /// <param name="jury">������� ����.</param>
        private void LoadJuryData(Jury jury)
        {
            if (jury == null)
                return;

            // �������� ������� ���
            var currentHour = DateTime.Now.Hour;

            // ���������� ����� ����� � ������������ "������"/"������"
            string greetingWord = currentHour < 11 ? "������ ����!" :
                                  currentHour < 18 ? "������ ����!" :
                                  "������ �����!";

            // ���������� ��������� �� ���� (���������� Genderid)
            string genderPrefix = jury.Genderid switch
            {
                1 => "Mr.",  // �������
                2 => "Ms.",  // �������
                _ => ""      // ���� ��� �� ������ ��� ����������
            };

            // �������� ��� ������������ (���� �� ������� � ������������� ��������)
            string juryName = !string.IsNullOrWhiteSpace(jury.Namejury) ? jury.Namejury : "��� �� �������";

            // �������� �������� ������������ (���� �� ������� � ������������� ������ ������)
            string juryPatronymic = !string.IsNullOrWhiteSpace(jury.Patronymicjury) ? jury.Patronymicjury : "";

            // ��������� ������ ��� � ��������� (���� �������� ����)
            string fullName = string.IsNullOrWhiteSpace(juryPatronymic)
                ? juryName
                : $"{juryName} {juryPatronymic}";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// ����� �� ������� �����.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
