using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ViewModel ��� ������ �������, ����������� ������� ������� � ������������ �������.
    /// </summary>
    public class ClientScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Client _client; // �������� ��� �������� ������������

        /// <summary>
        /// ����������� ��� ����������� �� ������ �������.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// ������ �����������, ��������� � ������� ��������.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// ������ �������� ������� (������������).
        /// </summary>
        public Client Client
        {
            get => _client;
            set => this.RaiseAndSetIfChanged(ref _client, value);
        }

        /// <summary>
        /// ����������� ��� �������� ���������� <see cref="ClientScreenViewModel"/>.
        /// </summary>
        /// <param name="db">�������� ���� ������ ��� ������ � �������.</param>
        /// <param name="client">���������� � ������� ������� (������������).</param>
        /// <exception cref="ArgumentNullException">���� ������ ����� null.</exception>
        public ClientScreenViewModel(InformationsecuritydbContext db, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "client cannot be null.");
            }
            _db = db;
            Client = client; // ������������� �������� ������������
            LoadClientData(client);
            //LoadEvents();
        }

        /// <summary>
        /// ��������� ������ �������, ������� ����������� � ������ ���������.
        /// </summary>
        /// <param name="client">���������� � ������� �������.</param>
        private void LoadClientData(Client client)
        {
            if (client == null)
                return;

            // �������� ������� ���
            var currentHour = DateTime.Now.Hour;

            // ���������� ����� ����� � ������������ "������"/"������"
            string greetingWord = currentHour < 11 ? "������ ����!" :
                                  currentHour < 18 ? "������ ����!" :
                                  "������ �����!";

            // ���������� ��������� �� ���� (���������� Genderid)
            string genderPrefix = client.Genderid switch
            {
                1 => "Mr.",  // �������
                2 => "Ms.",  // �������
                _ => ""      // ���� ��� �� ������ ��� ����������
            };

            // �������� ��� ������������ (���� �� ������� � ������������� ��������)
            string clientName = !string.IsNullOrWhiteSpace(client.Nameclient) ? client.Nameclient : "��� �� �������";

            // �������� �������� ������������ (���� �� ������� � ������������� ������ ������)
            string clientPatronymic = !string.IsNullOrWhiteSpace(client.Patronymicclient) ? client.Patronymicclient : "";

            // ��������� ������ ��� � ��������� (���� �������� ����)
            string fullName = string.IsNullOrWhiteSpace(clientPatronymic)
                ? clientName
                : $"{clientName} {clientPatronymic}";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// ��������� �� ������� �����.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
