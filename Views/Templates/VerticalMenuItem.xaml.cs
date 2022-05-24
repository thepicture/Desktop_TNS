using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TelekomNevaSvyazWpfApp.Views.Templates
{
    /// <summary>
    /// Interaction logic for VerticalMenuItem.xaml
    /// </summary>
    public partial class VerticalMenuItem : UserControl
    {


        public Brush Brush
        {
            get { return (Brush)GetValue(BrushProperty); }
            set { SetValue(BrushProperty, value); }
        }

        public static readonly DependencyProperty BrushProperty =
            DependencyProperty.Register("Brush",
                                        typeof(Brush),
                                        typeof(VerticalMenuItem),
                                        new PropertyMetadata(Application.Current.Resources["AdditionalBackground"]));



        public string MenuContent
        {
            get { return (string)GetValue(MenuContentProperty); }
            set { SetValue(MenuContentProperty, value); }
        }

        public static readonly DependencyProperty MenuContentProperty =
            DependencyProperty.Register("MenuContent",
                                        typeof(string),
                                        typeof(VerticalMenuItem),
                                        new PropertyMetadata(default(string)));



        public byte[] Source
        {
            get { return (byte[])GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
                                        typeof(byte[]),
                                        typeof(VerticalMenuItem),
                                        new PropertyMetadata(default(byte[])));


        public VerticalMenuItem()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            ((dynamic)Parent).Parent.Parent.VerticalMenuItemContent = MenuContent;
            Brush = (SolidColorBrush)Application.Current.Resources["AttentionAccent"];
            foreach (var menuItem in ((StackPanel)Parent).Children.OfType<VerticalMenuItem>())
            {
                if (menuItem == this)
                {
                    continue;
                }
                menuItem.Brush = (SolidColorBrush)Application.Current.Resources["AdditionalBackground"];
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if(MenuContent == "Абоненты")
            {
                Brush = (SolidColorBrush)Application.Current.Resources["AttentionAccent"];
            }
        }
    }
}
