using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class SubscriberInformationViewModel : ViewModelBase
    {
        private Subscriber subscriber;

        public SubscriberInformationViewModel(Subscriber inputSubscriber)
        {
            Title = "Подробная информация об абоненте";
            Subscriber = inputSubscriber;
        }

        public Subscriber Subscriber
        {
            get => subscriber;
            set => SetProperty(ref subscriber, value);
        }
    }
}