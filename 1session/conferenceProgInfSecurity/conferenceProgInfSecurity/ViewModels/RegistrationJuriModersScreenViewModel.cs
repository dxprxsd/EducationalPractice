using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using ReactiveUI;
using conferenceProgInfSecurity.Models;
using Avalonia.Controls.ApplicationLifetimes;
using conferenceProgInfSecurity.Views;

namespace conferenceProgInfSecurity.ViewModels
{
    public class RegistrationJuriModersScreenViewModel : ViewModelBase
    {
        private readonly InformationsecuritydbContext db = new InformationsecuritydbContext();

        private string _firstName;
        private string _secondName;
        private string _patronymic;
        private string _selectedGender;
        private string _selectedRole;
        private string _email;
        private string _phone;
        private string _selectedEvent;
        private string _password;
        private string _confirmPassword;
        private string _message;
        private byte[] _photo;
        private Bitmap _photoPreview;
        private List<Gender> _genders;
        private Gender _selectedGenderEntity;
        private List<Direction> _directions;
        private Direction _selectedDirectionEntity;
        private List<Meropriyatie> _meropriyaties;
        private Meropriyatie _selectedMeropriyatiesEntity;

        public RegistrationJuriModersScreenViewModel()
        {
            //GenderOptions = new List<string> { "Мужской", "Женский" };
            RoleOptions = new List<string> { "Жюри", "Модератор" };
            EventOptions = new List<string>(); // Должно загружаться из базы
            LoadGenders();
            LoadDirections();
            LoadMeropriyaties();
        }

        public string FirstName { get => _firstName; set => this.RaiseAndSetIfChanged(ref _firstName, value); }
        public string SecondName { get => _secondName; set => this.RaiseAndSetIfChanged(ref _secondName, value); }
        public string Patronymic { get => _patronymic; set => this.RaiseAndSetIfChanged(ref _patronymic, value); }
        public string SelectedGender { get => _selectedGender; set => this.RaiseAndSetIfChanged(ref _selectedGender, value); }
        public string SelectedRole { get => _selectedRole; set => this.RaiseAndSetIfChanged(ref _selectedRole, value); }
        public string Email { get => _email; set => this.RaiseAndSetIfChanged(ref _email, value); }
        public string Phone { get => _phone; set => this.RaiseAndSetIfChanged(ref _phone, value); }
        public List<Direction> Directions { get => _directions; set => this.RaiseAndSetIfChanged(ref _directions, value); }
        public Direction SelectedDirectionEntity { get => _selectedDirectionEntity; set => this.RaiseAndSetIfChanged(ref _selectedDirectionEntity, value); }
        public List<Meropriyatie> Meropriyaties { get => _meropriyaties; set => this.RaiseAndSetIfChanged(ref _meropriyaties, value); }
        public Meropriyatie SelectedMeropriyatiesEntity { get => _selectedMeropriyatiesEntity; set => this.RaiseAndSetIfChanged(ref _selectedMeropriyatiesEntity, value); }
        public string SelectedEvent { get => _selectedEvent; set => this.RaiseAndSetIfChanged(ref _selectedEvent, value); }
        public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }
        public string ConfirmPassword { get => _confirmPassword; set => this.RaiseAndSetIfChanged(ref _confirmPassword, value); }
        public string Message { get => _message; set => this.RaiseAndSetIfChanged(ref _message, value); }
        public byte[] Photo { get => _photo; set => this.RaiseAndSetIfChanged(ref _photo, value); }
        public Bitmap PhotoPreview { get => _photoPreview; set => this.RaiseAndSetIfChanged(ref _photoPreview, value); }
        public List<Gender> Genders { get => _genders; set => this.RaiseAndSetIfChanged(ref _genders, value); }
        public Gender SelectedGenderEntity { get => _selectedGenderEntity; set => this.RaiseAndSetIfChanged(ref _selectedGenderEntity, value); }
        public List<string> GenderOptions { get; }
        public List<string> RoleOptions { get; }
        public List<string> EventOptions { get; set; }

        private void LoadGenders()
        {
            try
            {
                _genders = db.Genders.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки полов: {ex.Message}");
            }
        }

        private void LoadDirections()
        {
            try
            {
                _directions = db.Directions.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки направлений: {ex.Message}");
            }
        }

        private void LoadMeropriyaties()
        {
            try
            {
                _meropriyaties = db.Meropriyaties.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки мероприятий: {ex.Message}");
            }
        }

        public async Task UploadPhoto()
        {
            var window = Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;
            if (window?.MainWindow == null) return;

            var dialog = window.MainWindow.StorageProvider;
            var result = await dialog.OpenFilePickerAsync(new FilePickerOpenOptions { FileTypeFilter = new[] { FilePickerFileTypes.ImageAll } });

            if (result.Count > 0)
            {
                var file = result[0];
                Photo = await File.ReadAllBytesAsync(file.Path.LocalPath);
                using var stream = new MemoryStream(Photo);
                PhotoPreview = new Bitmap(stream);
            }
        }

        public void Cancel() => MainWindowViewModel.Self.Us = new MainScreen();

        public void Register()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(SecondName) ||
                string.IsNullOrWhiteSpace(Patronymic) || string.IsNullOrWhiteSpace(Email) ||
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

            try
            {
                if (SelectedRole == "Жюри")
                {
                    Jury newJury = new Jury
                    {
                        Snamejury = SecondName,
                        Namejury = FirstName,
                        Patronymicjury = Patronymic,
                        Genderid = SelectedGenderEntity.Idgender,
                        Email = Email,
                        Phonenumber = Phone,
                        Dob = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),  // Указание DateTimeKind.Unspecified
                        Password = Password
                    };
                    db.Juries.Add(newJury);
                    db.SaveChanges();
                    Message = "Регистрация прошла успешно!";
                    MainWindowViewModel.Self.Us = new MainScreen();
                }
                else if (SelectedRole == "Модератор")
                {
                    Moderator newModerator = new Moderator
                    {
                        Snamemoderator = SecondName,
                        Namemoderator = FirstName,
                        Patronymicmoderator = Patronymic,
                        Genderid = SelectedGenderEntity.Idgender,
                        Email = Email,
                        Phonenumber = Phone,
                        Dob = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified),  // Указание DateTimeKind.Unspecified
                        Password = Password
                    };
                    db.Moderators.Add(newModerator);
                    db.SaveChanges();
                    Message = "Регистрация прошла успешно!";
                    MainWindowViewModel.Self.Us = new MainScreen();
                }
                db.SaveChanges();
                Message = "Регистрация прошла успешно!";
            }
            catch (Exception ex)
            {
                Message = $"Ошибка регистрации: {ex.Message}";
            }
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