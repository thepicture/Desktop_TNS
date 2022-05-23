using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TelekomNevaSvyazWpfApp.Models.Entities;

namespace TelekomNevaSvyazWpfApp.ViewModels
{
    public class NavigationViewModel : ViewModelBase
    {
        public NavigationViewModel()
        {
            ActiveMenuItems = new string[] { };
            LoadEmployeesAsync()
                .ContinueWith(t =>
                {
                    LoadActiveMenuItemsAsync();
                });
        }

        private async Task LoadEmployeesAsync()
        {
            using (TelekomNevaSvyazBaseEntities entities = new TelekomNevaSvyazBaseEntities())
            {
                Employees = new ObservableCollection<Employee>(
                    await entities.Employees
                        .Include(e => e.EmployeeRole)
                        .ToListAsync());
                CurrentEmployee = Employees.First();
            }
        }

        private void LoadActiveMenuItemsAsync()
        {
            switch (CurrentEmployee.EmployeeRole.Title)
            {
                case "Руководитель отдела по работе с клиентами":
                    ActiveMenuItems = "Абоненты, CRM, Биллинг"
                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Менеджер по работе с клиентами":
                    ActiveMenuItems = "Абоненты, CRM"
                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Руководитель отдела технической поддержки":
                    ActiveMenuItems = "Абоненты, Поддержка пользователей, CRM, Управление оборудованием"
                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Специалист технической поддержки":
                    ActiveMenuItems = "Абоненты, Поддержка пользователей, CRM, Управление оборудованием"
                         .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Бухгалтер":
                    ActiveMenuItems = "Абоненты, Биллинг, Активы"
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Директор по развитию":
                    ActiveMenuItems = "Абоненты, Поддержка пользователей, CRM, Управление оборудованием, Биллинг, Активы"
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
                case "Сотрудник технического департамента":
                    ActiveMenuItems = "Абоненты, Активы, Управление оборудованием, CRM"
                        .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                    break;
            }
        }

        public string[] ActiveMenuItems
        {
            get => activeMenuItems;
            set
            {
                SetProperty(ref activeMenuItems, value);
            }
        }


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


        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get => currentEmployee;
            set
            {
                if (SetProperty(ref currentEmployee, value))
                {
                    LoadActiveMenuItemsAsync();
                }
            }
        }

        private ObservableCollection<Employee> employees;
        private string[] activeMenuItems;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
    }
}