using System.Windows;
using TelekomNevaSvyazWpfApp.Services;
using TelekomNevaSvyazWpfApp.ViewModels;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Register<NavigationService>();

            NavigationView view = new();
            view.Show();
            view.NavigationFrame.Navigate(new AbonentsViewModel());
        }
    }
}
