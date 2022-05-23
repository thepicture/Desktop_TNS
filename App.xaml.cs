using System;
using System.ComponentModel;
using System.Windows;
using TelekomNevaSvyazWpfApp.Services;
using TelekomNevaSvyazWpfApp.ViewModels;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INotifyPropertyChanged
    {
        private static int roleId;

        public event PropertyChangedEventHandler PropertyChanged;

        public int RoleId
        {
            get => roleId;
            set
            {
                if(roleId==value)
                {
                    return;
                }
                roleId = value;
                PropertyChanged?
                    .Invoke(this,
                            new PropertyChangedEventArgs(
                                nameof(RoleId)));
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Ioc.Register<NavigationService>();
            Ioc.Register<OpenFileDialog>();

            NavigationView view = new NavigationView();
            view.Show();
            view.NavigationFrame.Navigate(new AbonentsViewModel());
        }
    }
}
