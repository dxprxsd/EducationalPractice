using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;

namespace conferenceProgInfSecurity.ViewModels
{
	public class ClientScreenViewModel : ViewModelBase
	{
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Client _client; // �������� ��� �������� ������������

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

        public Client Client
        {
            get => _client;
            set => this.RaiseAndSetIfChanged(ref _client, value);
        }

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
            string organizerName = !string.IsNullOrWhiteSpace(client.Nameclient) ? client.Nameclient : "��� �� �������";

            // ������������� ��� ������ �����������
            Greeting = $"{greetingWord}\n{genderPrefix} {organizerName}".Trim();
        }

        //private void LoadEvents()
        //{
        //    Events = new ObservableCollection<Meropriyatie>(_db.Meropriyaties.ToList());
        //}
    }
}