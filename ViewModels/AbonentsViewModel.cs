using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
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
    }
}