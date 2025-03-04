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
        private Jury _jury; // �������� ��� �������� ������������

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
            Jury = jury; // ������������� �������� ������������
            LoadJuryData(jury);
            //LoadEvents();
        }

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
            string organizerName = !string.IsNullOrWhiteSpace(jury.Namejury) ? jury.Namejury : "��� �� �������";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }
    }
}