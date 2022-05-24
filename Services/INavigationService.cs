namespace TelekomNevaSvyazWpfApp.Services
{
    public interface INavigationService
    {
        void Navigate<T>();
        void Navigate<T, TParam>(TParam param);
        void GoBack();
        void GoToRoot();
        bool IsCanGoBack { get; }
    }
}
