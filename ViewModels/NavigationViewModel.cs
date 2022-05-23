using System.Collections.ObjectModel;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
            ActiveMenuItems = new ObservableCollection<string>();
        }

        public ObservableCollection<string> ActiveMenuItems { get; set; }


        private string currentContent;

        public string CurrentContent
        {
            get => currentContent;
            set
            {
                if (SetProperty(ref currentContent, value))
                {
                    switch (value)
                    {
                        case "Абоненты":
                            NavigationService.Navigate<AbonentsViewModel>();
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private object currentEmployee;

        public object CurrentEmployee { get => currentEmployee; set => SetProperty(ref currentEmployee, value); }
    }
}