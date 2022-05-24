using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using TelekomNevaSvyazWpfApp.Commands;
using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class AbonentsViewModel : ViewModelBase
    {
        public AbonentsViewModel()
        {
            Title = "Абоненты ТНС";
            (App.Current as App).PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(Employee.RoleId))
                {
                    LoadEventsAsync();
                }
            };
            LoadEventsAsync();
            LoadSubscribersAsync();
        }

        private async void LoadSubscribersAsync()
        {
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                List<Subscriber> subscribers = await entities.Subscribers
                    .Include(s => s.ContractType)
                    .ToListAsync();
                Subscribers = new ObservableCollection<Subscriber>(subscribers);
            }
        }

        private async void LoadEventsAsync()
        {
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                List<Event> events = await entities.Events.ToListAsync();
                events = events
                    .Where(e => e.RoleId == ((App)App.Current).RoleId)
                    .ToList();
                Events = new ObservableCollection<Event>(events);
            }
        }

        private ObservableCollection<Event> events;

        public ObservableCollection<Event> Events
        {
            get => events;
            set => SetProperty(ref events, value);
        }

        private ObservableCollection<Subscriber> subscribers;

        public ObservableCollection<Subscriber> Subscribers
        {
            get => subscribers;
            set => SetProperty(ref subscribers, value);
        }

        private Command goToSubscriberInformationCommand;

        public ICommand GoToSubscriberInformationCommand
        {
            get
            {
                if (goToSubscriberInformationCommand == null)
                {
                    goToSubscriberInformationCommand = new Command(GoToSubscriberInformation);
                }

                return goToSubscriberInformationCommand;
            }
        }

        private void GoToSubscriberInformation(object commandParameter)
        {
            Subscriber subscriber = (Subscriber)commandParameter;
            NavigationService.Navigate<SubscriberInformationViewModel, Subscriber>(subscriber);
        }
    }
}