using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static VelvetEyebrows.Class1;
using VelvetEyebrows.Models;
using System.ComponentModel;

namespace VelvetEyebrows.view
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page, INotifyPropertyChanged
    {
        private int currentCount;
        public int CurrentCount
        {
            get => currentCount;
            set
            {
                currentCount = value;
                notifyPropertyChanged("CurrentCount");
            }
        }
        private int totalCount;

        public int TotalCount
        {
            get => totalCount;
            set
            {
                totalCount = value;
                notifyPropertyChanged("TotalCount");
            }
        }

        public bool IsAdmin { get; private set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        private void notifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Service> Services { get; private set; }

        public ServicesPage(bool isAdmin)
        {
            IsAdmin = isAdmin;
            Services = new ObservableCollection<Service>();
            CurrentCount = 0;
            TotalCount = Session.Instance.Context.Services.Count();
            InitializeComponent();


        }
        private IQueryable<Service> applySearch(IQueryable<Service> query) =>
    query.Where(q => q.Description.Contains(searchTextBox.Text) ||
        q.Title.Contains(searchTextBox.Text));

        private IQueryable<Service> applySort(IQueryable<Service> query) =>
    sortingComboBox.SelectedIndex switch
    {
        1 => query.OrderBy(service => service.Cost),
        2 => query.OrderByDescending(service => service.Cost),
        _ => query
    };

        private IQueryable<Service> applyDiscountFilter(IQueryable<Service> query)
        {
            if (filterComboBox.SelectedItem == null)
            {
                return query;
            }

            var filterComboBoxItem = (KeyValuePair<string, Func<IQueryable<Service>, IQueryable<Service>>>)filterComboBox.SelectedItem;
            var filterFunc = filterComboBoxItem.Value;
            return filterFunc(query);
        }
        private void removeService(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button)?.DataContext as Service;
            if (service == null) return;

            bool hasClientService = Session.Instance.Context.ClientServices.Any(cs => cs.ServiceId == service.Id);

            if (hasClientService)
            {
                MessageBox.Show("Невозможно удалить услугу, по которой есть записи", "Удаление невозможно",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var answer = MessageBox.Show("Вы уверены, что хотите удалить запись", "Подтверждение удаления",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    Session.Instance.Context.Services.Remove(service);
                    Session.Instance.Context.SaveChanges();
                    MessageBox.Show("Услуга удалена.", "Удаление успешно",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    applyFilters();
                }
                catch
                {
                    MessageBox.Show("Произошла ошибка при удалении!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void editService(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button)?.DataContext as Service;
            if (service == null) return;
            NavigationService.Navigate(new UpdateServicePage(service));
        }
        private void goToAddServicePage(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UpdateServicePage(new Service()));
        }

        private void applyFilters()
        {
            Services.Clear();
            // если ничего не введено, то выводим сообщение "Введите поисковый запрос"
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchResultLabel.Content = "Введите поисковый запрос";
                searchResultLabel.Visibility = Visibility.Visible;
                CurrentCount = 0;
                return;
            }

            // выполняем поиск подходящих значений
            IQueryable<Service> query = Session.Instance.Context.Services.AsQueryable();
            query = applyDiscountFilter(query);
            query = applySearch(query);
            query = applySort(query);

            // заполняем коллекцию значениями
            foreach (Service service in query)
            {
                Services.Add(service);
            }

            CurrentCount = Services.Count;

            // выводим сообщение, если ничего не найдено
            if (CurrentCount == 0)
            {
                searchResultLabel.Content = "По данному запросу ничего не найдено";
                searchResultLabel.Visibility = Visibility.Visible;
            }
            else
            {
                searchResultLabel.Visibility = Visibility.Collapsed;
            }

            TotalCount = Session.Instance.Context.Services.Count();
        }
        public Dictionary<string, Func<IQueryable<Service>, IQueryable<Service>>> DiscountFilters { get; set; } = new Dictionary<string, Func<IQueryable<Service>, IQueryable<Service>>>
        {
            { "Все записи", q => q },
            { "0% - 5%", q => q.Where(service => service.Discount >= 0 && service.Discount < 0.05) },
            { "5% - 15%", q => q.Where(service => service.Discount >= 0.05 && service.Discount < 0.15) },
            { "15% - 30%", q => q.Where(service => service.Discount >= 0.15 && service.Discount < 0.30) },
            { "30% - 70%", q => q.Where(service => service.Discount >= 0.3 && service.Discount < 0.7) },
            { "70% - 100%", q => q.Where(service => service.Discount >= 0.7 && service.Discount <= 1) }
        };


        private void search(object sender, TextChangedEventArgs e)
        {
            applyFilters();
        }

        private void sort(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }

        private void filter(object sender, SelectionChangedEventArgs e)
        {
            applyFilters();
        }

        private void goToRegistrationPage(object sender, RoutedEventArgs e)
        {
            var service = (sender as Button)?.DataContext as Service;
            if (service == null) return;
            NavigationService.Navigate(new Registrachia(service));
        }
    }
}
