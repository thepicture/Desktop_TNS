using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Data;

namespace TelekomNevaSvyazWpfApp.Converters
{
    internal class ImageNameToImageBytesOrEmptyImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] fileNames = Directory.GetFiles($"{AppDomain.CurrentDomain.BaseDirectory}/../../Resources/EmployeePhotos");
            if (value == null)
            {
                return fileNames.First(f => f.Contains("NoEmployeeImage"));
            }
            else
            {
                if (fileNames.FirstOrDefault(f => f.Contains((string)value)) is string filePath)
                {
                    return File.ReadAllBytes(filePath);
                }
                else
                {
                    return fileNames.First(f => f.Contains("NoEmployeeImage"));
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
