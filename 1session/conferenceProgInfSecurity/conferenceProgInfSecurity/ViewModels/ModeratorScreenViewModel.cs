using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace conferenceProgInfSecurity.ViewModels
{
    public class ModeratorScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Moderator _moderator; // �������� ��� �������� ������������

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

        public Moderator Moderator
        {
            get => _moderator;
            set => this.RaiseAndSetIfChanged(ref _moderator, value);
        }

        public ModeratorScreenViewModel(InformationsecuritydbContext db, Moderator moderator)
        {
            if (moderator == null)
            {
                throw new ArgumentNullException(nameof(moderator), "moderator cannot be null.");
            }
            _db = db;
            Moderator = moderator; // ������������� �������� ������������
            LoadModeratorData(moderator);
            //LoadEvents();
        }

        private void LoadModeratorData(Moderator moderator)
        {
            if (moderator == null)
                return;

            // �������� ������� ���
            var currentHour = DateTime.Now.Hour;

            // ���������� ����� ����� � ������������ "������"/"������"
            string greetingWord = currentHour < 11 ? "������ ����!" :
                                  currentHour < 18 ? "������ ����!" :
                                  "������ �����!";

            // ���������� ��������� �� ���� (���������� Genderid)
            string genderPrefix = moderator.Genderid switch
            {
                1 => "Mr.",  // �������
                2 => "Ms.",  // �������
                _ => ""      // ���� ��� �� ������ ��� ����������
            };

            // �������� ��� ������������ (���� �� ������� � ������������� ��������)
            string organizerName = !string.IsNullOrWhiteSpace(moderator.Namemoderator) ? moderator.Namemoderator : "��� �� �������";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }
    }
}