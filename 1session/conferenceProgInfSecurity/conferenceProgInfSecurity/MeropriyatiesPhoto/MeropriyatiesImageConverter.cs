﻿using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace conferenceProgInfSecurity.MeropriyatiesPhoto
{
    internal class MeropriyatiesImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Console.WriteLine($"Convert method called with value: {value}");

            // Путь к папке с фотографиями организаторов
            string MeropriyatiesPhotoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MeropriyatiesPhoto");

            // Проверка, если значение пустое
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                // Путь к изображению-заглушке
                string defaultImagePath = Path.Combine(MeropriyatiesPhotoPath, "1.jpg");
                Console.WriteLine($"Default image path: {defaultImagePath}");
                return File.Exists(defaultImagePath) ? new Bitmap(defaultImagePath) : null;
            }

            // Если значение - строка с именем файла изображения
            if (value is string fileName)
            {
                // Полный путь к изображению
                string imagePath = Path.Combine(MeropriyatiesPhotoPath, fileName.Trim());
                Console.WriteLine($"Image path: {imagePath}");

                // Проверяем, существует ли файл изображения
                if (File.Exists(imagePath))
                {
                    try
                    {
                        var bitmap = new Bitmap(imagePath);
                        Console.WriteLine("Image loaded successfully.");
                        return bitmap;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading image: {ex.Message}");
                        return null;
                    }
                }
                else
                {
                    // Если файл не найден, возвращаем изображение-заглушку
                    string defaultImagePath = Path.Combine(MeropriyatiesPhotoPath, "foto1.jpg");
                    Console.WriteLine($"Default image path (fallback): {defaultImagePath}");
                    return File.Exists(defaultImagePath) ? new Bitmap(defaultImagePath) : null;
                }
            }

            return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
