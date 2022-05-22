using TelekomNevaSvyazWpfApp.Models;
using TelekomNevaSvyazWpfApp.Services;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public string Title { get; set; } = string.Empty;
        public static INavigationService NavigationService => Ioc.Get<INavigationService>();
    }
}
