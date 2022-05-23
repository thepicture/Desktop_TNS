using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TelekomNevaSvyazWpfApp.Views.Templates;

namespace TelekomNevaSvyazWpfApp.Views.UserControls
{
    /// <summary>
    /// Interaction logic for VerticalMenu.xaml
    /// </summary>
    public partial class VerticalMenu : UserControl
    {



        public string VerticalMenuItemContent
        {
            get { return (string)GetValue(VerticalMenuItemContentProperty); }
            set { SetValue(VerticalMenuItemContentProperty, value); }
        }

        public static readonly DependencyProperty VerticalMenuItemContentProperty =
            DependencyProperty.Register("VerticalMenuItemContent",
                                        typeof(string),
                                        typeof(VerticalMenu),
                                        new PropertyMetadata("Абоненты"));


        public string[] ActiveMenuItems
        {
            get { return (string[])GetValue(ActiveMenuItemsProperty); }
            set { SetValue(ActiveMenuItemsProperty, value); }
        }

        public static readonly DependencyProperty ActiveMenuItemsProperty =
            DependencyProperty.Register("ActiveMenuItems",
                                        typeof(string[]),
                                        typeof(VerticalMenu),
                                        new PropertyMetadata(default(string[]),
                                                             OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            else
            {
                var menuItems = ((VerticalMenu)d).MenuPanel.Children.OfType<VerticalMenuItem>();
                menuItems
                    .ToList()
                    .ForEach(i => i.Visibility = Visibility.Collapsed);
                foreach (string content in (string[])e.NewValue)
                {
                    if (menuItems.FirstOrDefault(i => i.MenuContent == content) is VerticalMenuItem item)
                    {
                        item.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        public VerticalMenu()
        {
            InitializeComponent();
            foreach (string imagePath in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "/../../Resources/MenuIcons"))
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                VerticalMenuItem menuItem = new VerticalMenuItem()
                {
                    Source = imageBytes,
                    MenuContent = new FileInfo(imagePath).Name
                        .Split('.')[0]
                };
                MenuPanel.Children.Add(menuItem);
            }
        }
    }
}
