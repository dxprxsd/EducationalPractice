using System;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using conferenceProgInfSecurity.Models;

namespace conferenceProgInfSecurity.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext _db;
        private string _idClient;  
        private string _password;
        private string _errorMessage;
        public ReactiveCommand<Unit, Unit> LoginCommand { get; }

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

        public LoginViewModel(InformationsecuritydbContext db)
        {
            _db = db;
            LoginCommand = ReactiveCommand.Create(Authenticate);
        }

        private void Authenticate()
        {
            try
            {
                // ������� ������������� IdClient � �������� ���
                if (int.TryParse(IdClient, out int clientId))
                {
                    var user = _db.Clients.FirstOrDefault(u => u.Idclient == clientId && u.Password == Password);

                    if (user != null)
                    {
                        ErrorMessage = "�������� ����!";
                    }
                    else
                    {
                        ErrorMessage = "�������� ������";
                    }
                }
                else
                {
                    ErrorMessage = "������������ ������ ID �������";
                }
            }
            catch (Exception ex)
            {
                // �������� ������, ����� ������, ��� ������ ��� ����������
                ErrorMessage = "��������� ������: " + ex.Message;
            }
        }


    }
}
