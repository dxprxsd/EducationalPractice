using System;
using System.Collections.Generic;
using conferenceProgInfSecurity.Models;
using System.Collections.ObjectModel;
using ReactiveUI;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ViewModel для экрана клиента, управляющий данными клиента и отображением событий.
    /// </summary>
    public class ClientScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _greeting;
        private ObservableCollection<Meropriyatie> _events;
        private Client _client; // Свойство для текущего организатора

        /// <summary>
        /// Приветствие для отображения на экране клиента.
        /// </summary>
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }

        /// <summary>
        /// Список мероприятий, связанных с текущим клиентом.
        /// </summary>
        public ObservableCollection<Meropriyatie> Events
        {
            get => _events;
            set => this.RaiseAndSetIfChanged(ref _events, value);
        }

        /// <summary>
        /// Данные текущего клиента (организатора).
        /// </summary>
        public Client Client
        {
            get => _client;
            set => this.RaiseAndSetIfChanged(ref _client, value);
        }

        /// <summary>
        /// Конструктор для создания экземпляра <see cref="ClientScreenViewModel"/>.
        /// </summary>
        /// <param name="db">Контекст базы данных для работы с данными.</param>
        /// <param name="client">Информация о текущем клиенте (организаторе).</param>
        /// <exception cref="ArgumentNullException">Если клиент равен null.</exception>
        public ClientScreenViewModel(InformationsecuritydbContext db, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client), "client cannot be null.");
            }
            _db = db;
            Client = client; // Устанавливаем текущего организатора
            LoadClientData(client);
            //LoadEvents();
        }

        /// <summary>
        /// Загружает данные клиента, включая приветствие и другие параметры.
        /// </summary>
        /// <param name="client">Информация о текущем клиенте.</param>
        private void LoadClientData(Client client)
        {
            if (client == null)
                return;

            // Получаем текущий час
            var currentHour = DateTime.Now.Hour;

            // Определяем время суток и корректируем "Доброе"/"Добрый"
            string greetingWord = currentHour < 11 ? "Доброе утро!" :
                                  currentHour < 18 ? "Добрый день!" :
                                  "Добрый вечер!";

            // Определяем обращение по полу (используем Genderid)
            string genderPrefix = client.Genderid switch
            {
                1 => "Mr.",  // Мужской
                2 => "Ms.",  // Женский
                _ => ""      // Если пол не указан или неизвестен
            };

            // Получаем имя организатора (если не указано — подставляется заглушка)
            string clientName = !string.IsNullOrWhiteSpace(client.Nameclient) ? client.Nameclient : "Имя не указано";

            // Получаем отчество организатора (если не указано — подставляется пустая строка)
            string clientPatronymic = !string.IsNullOrWhiteSpace(client.Patronymicclient) ? client.Patronymicclient : "";

            // Формируем полное имя с отчеством (если отчество есть)
            string fullName = string.IsNullOrWhiteSpace(clientPatronymic)
                ? clientName
                : $"{clientName} {clientPatronymic}";

            // Устанавливаем две строки приветствия
            Greeting = $"{greetingWord}\n{genderPrefix} {fullName}".Trim();
        }

        /// <summary>
        /// Переходит на главный экран.
        /// </summary>
        public void ExitToMainScreen() => MainWindowViewModel.Self.Us = new MainScreen();
    }
}
