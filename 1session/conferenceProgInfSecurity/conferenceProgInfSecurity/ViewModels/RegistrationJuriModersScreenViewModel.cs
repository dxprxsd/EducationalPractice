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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace conferenceProgInfSecurity.ViewModels
{
    /// <summary>
    /// Модель представления для экрана регистрации жюри и модераторов.
    /// </summary>
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
        Moderator? typeModerator;
        Jury? typeJyru;
        bool isEnableMeropriyatie = true;
        char? pass;
        bool show_pass;
        private bool isEventEnabled;

        /// <summary>
        /// Конструктор модели представления, инициализирует данные для экрана регистрации.
        /// </summary>
        public RegistrationJuriModersScreenViewModel()
        {
            RoleOptions = new List<string> { "Жюри", "Модератор" };
            EventOptions = new List<string>(); // Должно загружаться из базы
            LoadGenders();
            LoadDirections();
            LoadMeropriyaties();
            typeModerator = new Moderator();
            typeJyru = new Jury();
            pass = '*';
            IsEventEnabled = false; // По умолчанию чекбокс выключен
        }

        // Свойства для привязки данных в представлении

        public bool IsEnableMeropriyatie { get => isEnableMeropriyatie; set => this.RaiseAndSetIfChanged(ref isEnableMeropriyatie, value); }
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
        public Moderator? TypeModerator { get => typeModerator; set => this.RaiseAndSetIfChanged(ref typeModerator, value); }
        public Jury? TypeJyru { get => typeJyru; set => this.RaiseAndSetIfChanged(ref typeJyru, value); }
        public List<string> GenderOptions { get; }
        public List<string> RoleOptions { get; }
        public List<string> EventOptions { get; set; }
        public char? Pass { get => pass; set => this.RaiseAndSetIfChanged(ref pass, value); }
        public bool ShowPassword { get => show_pass; set { this.RaiseAndSetIfChanged(ref show_pass, value); VisiblePass(); } }
        public bool IsEventEnabled { get => isEventEnabled; set { this.RaiseAndSetIfChanged(ref isEventEnabled, value); OnPropertyChanged();} }

        /// <summary>
        /// Загружает данные о полах из базы данных.
        /// </summary>
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void VisiblePass()
        {
            if (ShowPassword)
            {
                Pass = null;
            }
            else
            {
                Pass = '*';
            }
        }

    /// <summary>
    /// Загружает данные о направлениях из базы данных.
    /// </summary>
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

        /// <summary>
        /// Загружает данные о мероприятиях из базы данных.
        /// </summary>
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

        /// <summary>
        /// Открывает диалоговое окно для загрузки фото пользователя.
        /// </summary>
        /// <returns>Асинхронная задача загрузки фото.</returns>
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




        /// <summary>
        /// Отменяет регистрацию и возвращает пользователя на главный экран.
        /// </summary>
        public void Cancel() => MainWindowViewModel.Self.Us = new MainScreen();

        /// <summary>
        /// Регистрация пользователя в системе.
        /// </summary>
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
                Message = "Пароль слишком простой";
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
                        Photo = typeJyru.Photo,
                        Directionsid = SelectedDirectionEntity.Iddirections,
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
                        Photo = typeModerator.Photo,
                        Directionsid = SelectedDirectionEntity.Iddirections,
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

        public async Task ChangesImage()
        {
            Window newWindow = new Window();

            var dialog = newWindow.StorageProvider;

            var result = await dialog.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions() { FileTypeFilter = new[] { FilePickerFileTypes.ImageAll } });

            if (result.Count != 0)
            {
                if (SelectedRole == "Жюри")
                {
                    typeJyru.Photo = ProverkaPhoto(result[0].Path.LocalPath, result[0].Name);
                    PhotoPreview = new Bitmap(Environment.CurrentDirectory + "\\JuriPhotos" + "\\" + typeJyru.Photo);
                }
                else if (SelectedRole == "Модератор")
                {
                    typeModerator.Photo = ProverkaPhoto(result[0].Path.LocalPath, result[0].Name);
                    PhotoPreview = new Bitmap(Environment.CurrentDirectory + "\\ModeratorsPhotos" + "\\" + typeModerator.Photo);
                }
            }
        }

        private string ProverkaPhoto(string filename, string shortfilename)
        {
            string directoriya = Environment.CurrentDirectory;

            if (SelectedRole == "Жюри")
            {
                directoriya += "\\JuriPhotos";
            }
            else if (SelectedRole == "Модератор")
            {
                directoriya += "\\ModeratorsPhotos";
            }
            
            string path = filename;
            if (!path.Contains(directoriya))
            {
                string newPath = directoriya + "\\" + shortfilename;
                while (true)
                {
                    if (File.Exists(newPath))
                    {
                        string[] pathDots = shortfilename.Split('.');
                        pathDots[pathDots.Length - 2] = pathDots[pathDots.Length - 2] + "(1)";
                        shortfilename = "";
                        foreach (string pathDot in pathDots)
                        {
                            shortfilename += pathDot + ".";
                        }
                        shortfilename = shortfilename.Substring(0, shortfilename.Length - 1);
                        newPath = directoriya + "\\" + shortfilename;

                    }
                    else
                    {
                        break;
                    }

                }
                File.Copy(path, newPath, false);
                path = newPath;
            }
            string[] massiv = path.Split("\\");
            path = massiv[massiv.Length - 1];
            return path;
        }

        public void DeletePhoto()
        {
            if (SelectedRole == "Жюри" && typeJyru != null && !string.IsNullOrEmpty(typeJyru.Photo))
            {
                string photoPath = Path.Combine(Environment.CurrentDirectory, "JuriPhotos", typeJyru.Photo);
                if (File.Exists(photoPath))
                {
                    File.Delete(photoPath);
                }
                typeJyru.Photo = null;
                PhotoPreview = null; 
            }
            else if (SelectedRole == "Модератор" && typeModerator != null && !string.IsNullOrEmpty(typeModerator.Photo))
            {
                string photoPath = Path.Combine(Environment.CurrentDirectory, "ModeratorsPhotos", typeModerator.Photo);
                if (File.Exists(photoPath))
                {
                    File.Delete(photoPath);
                }
                typeModerator.Photo = null;
                PhotoPreview = null; 
            }
            Message = "Фото удалено.";
        }

        /// <summary>
        /// Валидирует пароль по нескольким критериям.
        /// </summary>
        /// <param name="password">Пароль для проверки.</param>
        /// <returns>Результат валидации пароля.</returns>
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
