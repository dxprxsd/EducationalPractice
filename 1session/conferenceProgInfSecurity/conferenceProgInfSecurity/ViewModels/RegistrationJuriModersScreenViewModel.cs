using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Platform.Storage;
using Avalonia.Media.Imaging;
using ReactiveUI;
using conferenceProgInfSecurity.Models;

namespace conferenceProgInfSecurity.ViewModels
{
    public class RegistrationJuriModersScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext db;

        private string _idNumber;
        private string _fullName;
        private string _selectedGender;
        private string _selectedRole;
        private string _email;
        private string _phone;
        private string _direction;
        private string _selectedEvent;
        private string _password;
        private string _confirmPassword;
        private string _message;
        private byte[] _photo;
        private Bitmap _photoPreview;

        Jury juries;

        Moderator moderators;

        public RegistrationJuriModersScreenViewModel()
        {
            _idNumber = Guid.NewGuid().ToString();
            GenderOptions = new List<string> { "Мужской", "Женский" };
            RoleOptions = new List<string> { "Жюри", "Модератор" };
            EventOptions = new List<string>(); // Должно загружаться из базы

            juries = new Jury();

            juries.Dob = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            moderators = new Moderator();

            moderators.Dob = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public string IdNumber => _idNumber;
        public string FullName { get => _fullName; set => this.RaiseAndSetIfChanged(ref _fullName, value); }
        public string SelectedGender { get => _selectedGender; set => this.RaiseAndSetIfChanged(ref _selectedGender, value); }
        public string SelectedRole { get => _selectedRole; set => this.RaiseAndSetIfChanged(ref _selectedRole, value); }
        public string Email { get => _email; set => this.RaiseAndSetIfChanged(ref _email, value); }
        public string Phone { get => _phone; set => this.RaiseAndSetIfChanged(ref _phone, value); }
        public string Direction { get => _direction; set => this.RaiseAndSetIfChanged(ref _direction, value); }
        public string SelectedEvent { get => _selectedEvent; set => this.RaiseAndSetIfChanged(ref _selectedEvent, value); }
        public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }
        public string ConfirmPassword { get => _confirmPassword; set => this.RaiseAndSetIfChanged(ref _confirmPassword, value); }
        public string Message { get => _message; set => this.RaiseAndSetIfChanged(ref _message, value); }
        public byte[] Photo { get => _photo; set => this.RaiseAndSetIfChanged(ref _photo, value); }
        public Bitmap PhotoPreview { get => _photoPreview; set => this.RaiseAndSetIfChanged(ref _photoPreview, value); }

        public List<string> GenderOptions { get; }
        public List<string> RoleOptions { get; }
        public List<string> EventOptions { get; set; }

        public DateTimeOffset DateOfJury
        {
            get => new DateTimeOffset((DateTime)juries.Dob, TimeSpan.Zero);

            set => juries.Dob = new DateTime(value.Year, value.Month, value.Day);
        }

        //public DateTimeOffset DateOfModerator
        //{
        //    get => new DateTimeOffset((DateTime)juries.Dob, TimeSpan.Zero);

        //    set => juries.Dob = new DateTime(value.Year, value.Month, value.Day);
        //}

        public async Task UploadPhoto()
        {
            var window = Application.Current.ApplicationLifetime as Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime;
            if (window?.MainWindow == null) return;

            var dialog = window.MainWindow.StorageProvider;
            var result = await dialog.OpenFilePickerAsync(new FilePickerOpenOptions() { FileTypeFilter = new[] { FilePickerFileTypes.ImageAll } });

            if (result.Count > 0)
            {
                var file = result[0];
                Photo = await File.ReadAllBytesAsync(file.Path.LocalPath);
                using var stream = new MemoryStream(Photo);
                PhotoPreview = new Bitmap(stream);
            }
        }

        public void Register()
        {
            if (string.IsNullOrWhiteSpace(FullName) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Phone) || string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                Message = "Все обязательные поля должны быть заполнены.";
                return;
            }

            if (Password != ConfirmPassword)
            {
                Message = "Пароли не совпадают.";
                return;
            }

            if (!ValidatePassword(Password))
            {
                Message = "Пароль должен содержать минимум 6 символов, заглавные и строчные буквы, одну цифру и спецсимвол.";
                return;
            }

            // Сохранение в базу данных логика здесь
            Message = "Регистрация прошла успешно.";
        }

        private bool ValidatePassword(string password)
        {
            return password.Length >= 6 &&
                   password.IndexOfAny("ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray()) != -1 &&
                   password.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) != -1 &&
                   password.IndexOfAny("0123456789".ToCharArray()) != -1 &&
                   password.IndexOfAny("!@#$%^&*()_-+=<>?/|".ToCharArray()) != -1;
        }
    }
}