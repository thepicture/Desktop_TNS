namespace TelekomNevaSvyazWpfApp.Services
{
    public interface INavigationService
    {
        void Navigate<T>();
        void GoBack();
        void GoToRoot();
        bool IsCanGoBack { get; }
    }
}
