using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.Views.Templates
{
    /// <summary>
    /// Interaction logic for SubscribersControl.xaml
    /// </summary>
    public partial class SubscribersControl : UserControl
    {
        public ICommand SelectItemCommand
        {
            get { return (ICommand)GetValue(SelectItemCommandProperty); }
            set { SetValue(SelectItemCommandProperty, value); }
        }

        public static readonly DependencyProperty SelectItemCommandProperty =
            DependencyProperty.Register("SelectItemCommand",
                                        typeof(ICommand),
                                        typeof(SubscribersControl),
                                        new PropertyMetadata(null));



        private void OnFilterChanged()
        {
            if (Subscribers == null)
            {
                return;
            }
            if (ActiveCheckBox.IsChecked.Value && InactiveCheckBox.IsChecked.Value)
            {
                FilteredSubscribers = Subscribers;
            }
            else if (ActiveCheckBox.IsChecked.Value)
            {
                FilteredSubscribers = new ObservableCollection<Subscriber>(
                    Subscribers.Where(s => !s.ContractRejectDate.HasValue));
            }
            else if (InactiveCheckBox.IsChecked.Value)
            {
                FilteredSubscribers = new ObservableCollection<Subscriber>(
                    Subscribers.Where(s => s.ContractRejectDate.HasValue));
            }
            else
            {
                FilteredSubscribers = new ObservableCollection<Subscriber>();
            }
        }



        public ObservableCollection<Subscriber> FilteredSubscribers
        {
            get { return (ObservableCollection<Subscriber>)GetValue(FilteredSubscribersProperty); }
            set { SetValue(FilteredSubscribersProperty, value); }
        }

        public static readonly DependencyProperty FilteredSubscribersProperty =
            DependencyProperty.Register("FilteredSubscribers",
                                        typeof(ObservableCollection<Subscriber>),
                                        typeof(SubscribersControl),
                                        new PropertyMetadata(null));



        public ObservableCollection<Subscriber> Subscribers
        {
            get { return (ObservableCollection<Subscriber>)GetValue(SubscribersProperty); }
            set { SetValue(SubscribersProperty, value); }
        }

        public static readonly DependencyProperty SubscribersProperty =
            DependencyProperty.Register("Subscribers",
                                        typeof(ObservableCollection<Subscriber>),
                                        typeof(SubscribersControl),
                                        new PropertyMetadata(null));


        public SubscribersControl()
        {
            InitializeComponent();
        }

        private void OnActiveChecked(object sender, RoutedEventArgs e)
        {
            OnFilterChanged();
        }

        private void OnActiveUnchecked(object sender, RoutedEventArgs e)
        {
            OnFilterChanged();
        }

        private void OnIntactiveChecked(object sender, RoutedEventArgs e)
        {
            OnFilterChanged();
        }

        private void OnInactiveUnchecked(object sender, RoutedEventArgs e)
        {
            OnFilterChanged();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ActiveCheckBox.IsChecked = true;
        }
    }
}
