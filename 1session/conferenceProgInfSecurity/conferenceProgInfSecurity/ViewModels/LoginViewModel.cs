using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// ViewModel ��� ������ �����.
    /// ������������ �������������� ������������ � �������� �� ��������������� ������.
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _idClient;
        private string _password;
        private string _errorMessage;

        /// <summary>
        /// ������� ��� ���������� ��������������.
        /// </summary>
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        // �������� ������ �� ���� ������ MainWindowViewModel
        private readonly MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// ������������� ������� ��� �����.
        /// </summary>
        public string IdClient
        {
            get => _idClient;
            set => this.RaiseAndSetIfChanged(ref _idClient, value);
        }

        /// <summary>
        /// ������ ��� �����.
        /// </summary>
        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        /// <summary>
        /// ��������� �� ������ ��� �������� ��������������.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        /// <summary>
        /// ����������� ��� ������������� ViewModel ��� ������ �����.
        /// </summary>
        /// <param name="db">�������� ���� ������.</param>
        /// <param name="mainWindowViewModel">ViewModel �������� ����.</param>
        public LoginViewModel(InformationsecuritydbContext db, MainWindowViewModel mainWindowViewModel)
        {
            _db = db;
            _mainWindowViewModel = mainWindowViewModel ?? throw new ArgumentNullException(nameof(mainWindowViewModel));  // �������� �� null
            LoginCommand = ReactiveCommand.Create(Authenticate);
        }

        /// <summary>
        /// ������� �� �������� ����� ����������.
        /// </summary>
        public void GoToMainScreen() => _mainWindowViewModel.Us = new MainScreen();

        /// <summary>
        /// ����� ��� �������������� ������������.
        /// ��������� ��������� ������ � �������������� �� ��������������� �����.
        /// </summary>
        private void Authenticate()
        {
            try
            {
                if (int.TryParse(IdClient, out int userId))
                {
                    // �������� ������������ � ������ �������
                    var client = _db.Clients.FirstOrDefault(u => u.Idclient == userId && u.Password == Password);
                    var organizer = _db.Organizers.FirstOrDefault(u => u.Idorganizer == userId && u.Password == Password);
                    var moderator = _db.Moderators.FirstOrDefault(u => u.Moderatorid == userId && u.Password == Password);
                    var jury = _db.Juries.FirstOrDefault(u => u.Juryid == userId && u.Password == Password);

                    if (client != null)
                    {
                        ErrorMessage = "�������� ���� ��� ������!";
                        GoToClientScreen(client); // ������� �� ����� �������
                    }
                    else if (organizer != null)
                    {
                        ErrorMessage = "�������� ���� ��� �����������!";
                        GoToOrganizerScreen(organizer); // ������� �� ����� ������������
                    }
                    else if (moderator != null)
                    {
                        ErrorMessage = "�������� ���� ��� ���������!";
                        GoToModeratorScreen(moderator); // ������� �� ����� ����������
                    }
                    else if (jury != null)
                    {
                        ErrorMessage = "�������� ���� ��� ����!";
                        GoToJuryScreen(jury); // ������� �� ����� ����
                    }
                    else
                    {
                        ErrorMessage = "�������� ������";
                    }
                }
                else
                {
                    ErrorMessage = "������������ ������ ID ������������";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = "��������� ������: " + ex.Message;
            }
        }

        /// <summary>
        /// ������� �� ����� ������������.
        /// </summary>
        /// <param name="organizer">�����������.</param>
        private void GoToOrganizerScreen(Organizer organizer)
        {
            // ������� ����� ViewModel ��� ������ ������������
            var organizerScreenViewModel = new OrganizerScreenViewModel(_db, organizer);
            // ��������� �� ����� ������������
            _mainWindowViewModel.Us = new OrganizerScreen { DataContext = organizerScreenViewModel };
        }

        /// <summary>
        /// ������� �� ����� �������.
        /// </summary>
        /// <param name="client">������.</param>
        private void GoToClientScreen(Client client)
        {
            // ������� ����� ViewModel ��� ������ �������
            var clientScreenViewModel = new ClientScreenViewModel(_db, client);
            // ��������� �� ����� �������
            _mainWindowViewModel.Us = new ClientScreen { DataContext = clientScreenViewModel };
        }

        /// <summary>
        /// ������� �� ����� ����.
        /// </summary>
        /// <param name="jury">���� ����.</param>
        private void GoToJuryScreen(Jury jury)
        {
            // ������� ����� ViewModel ��� ������ ����
            var juryScreenViewModel = new JuryScreenViewModel(_db, jury);
            // ��������� �� ����� ����
            _mainWindowViewModel.Us = new JuryScreen { DataContext = juryScreenViewModel };
        }

        /// <summary>
        /// ������� �� ����� ����������.
        /// </summary>
        /// <param name="moderator">���������.</param>
        private void GoToModeratorScreen(Moderator moderator)
        {
            // ������� ����� ViewModel ��� ������ ����������
            var moderatorScreenViewModel = new ModeratorScreenViewModel(_db, moderator);
            // ��������� �� ����� ����������
            _mainWindowViewModel.Us = new ModeratorScreen { DataContext = moderatorScreenViewModel };
        }
    }
}
