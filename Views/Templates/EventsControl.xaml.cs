using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.Views.Templates
{
    /// <summary>
    /// Interaction logic for EventsControl.xaml
    /// </summary>
    public partial class EventsControl : UserControl
    {
        public ObservableCollection<Event> Events
        {
            get { return (ObservableCollection<Event>)GetValue(EventsProperty); }
            set { SetValue(EventsProperty, value); }
        }

        public static readonly DependencyProperty EventsProperty =
            DependencyProperty.Register("Events",
                                        typeof(ObservableCollection<Event>),
                                        typeof(EventsControl),
                                        new PropertyMetadata(null));

        public EventsControl()
        {
            InitializeComponent();
        }


        public ScrollViewer EventsScroller =>
            (ScrollViewer)(VisualTreeHelper.GetChild(EventsView, 0) as Decorator).Child;

        private void OnEventsScrollUp(object sender, RoutedEventArgs e)
        {
            EventsScroller.LineUp();
        }

        private void OnEventsScrollDown(object sender, RoutedEventArgs e)
        {
            EventsScroller.LineDown();
        }
    }
}
