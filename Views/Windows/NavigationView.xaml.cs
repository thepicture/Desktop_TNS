using System.Windows;
using System.Windows.Input;

namespace TelekomNevaSvyazWpfApp
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : Window
    {
        public NavigationView()
        {
            InitializeComponent();
            RibbonVerticalMenu.Width = 250;
        }

        private void OnOpenVerticalMenu(object sender, MouseButtonEventArgs e)
        {
            RibbonVerticalMenu.Width = 250;
        }

        private void OnCloseVerticalMenu(object sender, MouseButtonEventArgs e)
        {
            RibbonVerticalMenu.Width = 65;
        }
    }
}
