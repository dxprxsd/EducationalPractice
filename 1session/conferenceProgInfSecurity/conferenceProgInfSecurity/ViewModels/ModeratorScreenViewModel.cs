using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ������ ������ ����������.
    /// </summary>
    public class ModeratorScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Moderator _moderator; // �������� ��� �������� ����������

        /// <summary>
        /// �������������� ��������� ��� ����������.
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
        /// �������� ��� �������� ����������.
        /// </summary>
        public Moderator Moderator
        {
            get => _moderator;
            set => this.RaiseAndSetIfChanged(ref _moderator, value);
        }

        /// <summary>
        /// ����������� ������ ������ ����������.
        /// </summary>
        /// <param name="db">�������� ���� ������.</param>
        /// <param name="moderator">������� ���������.</param>
        /// <exception cref="ArgumentNullException">���� ��������� ����� null.</exception>
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

        /// <summary>
        /// ��������� ������ ��� ���������� � ������������� �������������� ���������.
        /// </summary>
        /// <param name="moderator">������� ���������.</param>
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

        /// <summary>
        /// ����� �� ������� �����.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
