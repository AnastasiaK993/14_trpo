using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class InterestGroupList : Page
    {
        public InterestGroupService service { get; set; } = new InterestGroupService();
        public InterestGroup current { get; set; } = null;

        public InterestGroupList()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += InterestGroupList_Loaded;
        }

        private void InterestGroupList_Loaded(object sender, RoutedEventArgs e)
        {
            service.GetAll();
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupForm());
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new InterestGroupForm(current));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить группу?",
                    "Удалить группу?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    service.Remove(current);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления", "Выберите группу",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void viewMembers(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new InterestGroupMembers(current));
            }
            else
            {
                MessageBox.Show("Выберите группу");
            }
        }
    }
}