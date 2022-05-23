using System;
using System.IO;
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
        public VerticalMenu()
        {
            InitializeComponent();
            foreach (string imagePath in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory +  "/../../../Resources/MenuIcons"))
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                FrameworkElementFactory menuItemFactory = new(
                    typeof(VerticalMenuItem));
                menuItemFactory.SetValue(VerticalMenuItem.SourceProperty, imageBytes);
                menuItemFactory.SetValue(VerticalMenuItem.MenuContentProperty,
                                         new FileInfo(imagePath).Name.Split('.')[0]);
                Button button = new()
                {
                    Width = double.NaN,
                    ContentTemplate = new DataTemplate
                    {
                        VisualTree = menuItemFactory
                    }
                };
                MenuPanel.Children.Add(button);
            }
        }
    }
}
