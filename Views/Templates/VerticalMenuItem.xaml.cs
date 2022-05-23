using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TelekomNevaSvyazWpfApp.Views.Templates
{
    /// <summary>
    /// Interaction logic for VerticalMenuItem.xaml
    /// </summary>
    public partial class VerticalMenuItem : UserControl
    {


        public string MenuContent
        {
            get { return (string)GetValue(MenuContentProperty); }
            set { SetValue(MenuContentProperty, value); }
        }

        public static readonly DependencyProperty MenuContentProperty =
            DependencyProperty.Register("MenuContent", typeof(string), typeof(VerticalMenuItem), new PropertyMetadata(default(string)));



        public byte[] Source
        {
            get { return (byte[])GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(byte[]), typeof(VerticalMenuItem), new PropertyMetadata(default(byte[])));


        public VerticalMenuItem()
        {
            InitializeComponent();
        }
    }
}
