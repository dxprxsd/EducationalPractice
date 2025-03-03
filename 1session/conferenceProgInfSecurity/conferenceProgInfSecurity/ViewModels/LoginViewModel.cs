using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using conferenceProgInfSecurity.Models;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _idClient;
        private string _password;
        private string _errorMessage;
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

        // �������� ������ �� ���� ������ MainWindowViewModel
        private readonly MainWindowViewModel _mainWindowViewModel;

        public string IdClient
        {
            get => _idClient;
            set => this.RaiseAndSetIfChanged(ref _idClient, value);
        }

        public string Password
        {
            get => _password;
            set => this.RaiseAndSetIfChanged(ref _password, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public LoginViewModel(InformationsecuritydbContext db, MainWindowViewModel mainWindowViewModel)
        {
            _db = db;
            _mainWindowViewModel = mainWindowViewModel ?? throw new ArgumentNullException(nameof(mainWindowViewModel));  // �������� �� null
            LoginCommand = ReactiveCommand.Create(Authenticate);
        }

        public void GoToMainScreen() => _mainWindowViewModel.Us = new MainScreen();

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
                        GoToMainScreen(); // ������� �� MainScreen
                    }
                    else if (organizer != null)
                    {
                        ErrorMessage = "�������� ���� ��� �����������!";
                        GoToOrganizerScreen(organizer); // ������� �� ����� ������������
                    }
                    else if (moderator != null)
                    {
                        ErrorMessage = "�������� ���� ��� ���������!";
                        GoToMainScreen(); // ������� �� MainScreen
                    }
                    else if (jury != null)
                    {
                        ErrorMessage = "�������� ���� ��� ����!";
                        GoToMainScreen(); // ������� �� MainScreen
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

        // ������� �������� �� ����� ������������
        private void GoToOrganizerScreen(Organizer organizer)
        {
            // ������� ����� ViewModel ��� ������ ������������
            var organizerScreenViewModel = new OrganizerScreenViewModel(_db, organizer);
            // ��������� �� ����� ������������
            _mainWindowViewModel.Us = new OrganizerScreen { DataContext = organizerScreenViewModel };
        }
    }
}
