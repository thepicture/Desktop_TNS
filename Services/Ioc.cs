using System;
using System.Windows;

namespace TelekomNevaSvyazWpfApp
{
    public static class Ioc
    {
        public static T Get<T>()
        {
            return (T)Application.Current.Resources[typeof(T).Name];
        }

        public static void Register<T>()
        {
            string? interfaceNameOfType = typeof(T)
                .GetInterface(
                    $"I{typeof(T).Name}")?.Name;
            Application.Current.Resources[interfaceNameOfType] = Activator
                .CreateInstance(
                    typeof(T));
        }
    }
}
