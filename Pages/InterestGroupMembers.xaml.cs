using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class InterestGroupMembers : Page
    {
        private InterestGroup _group;
        private UserInterestGroupService _service = new UserInterestGroupService();

        public ObservableCollection<UserInterestGroup> Members { get; set; } = new ObservableCollection<UserInterestGroup>();
        public UserInterestGroup current { get; set; } = null;

        public InterestGroupMembers(InterestGroup group)
        {
            InitializeComponent();
            _group = group;
            Title = $"Участники группы: {group.Title}";

            var members = _service.GetGroupMembers(group.Id);
            foreach (var m in members)
                Members.Add(m);

            DataContext = this;
            Loaded += InterestGroupMembers_Loaded;
        }

        private void InterestGroupMembers_Loaded(object sender, RoutedEventArgs e)
        {
            Members.Clear();
            var fresh = _service.GetGroupMembers(_group.Id);
            foreach (var m in fresh)
                Members.Add(m);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void addUser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUserToGroupForm(_group));
        }

        private void removeUser(object sender, RoutedEventArgs e)
        {
            if (current == null)
            {
                MessageBox.Show("Выберите участника");
                return;
            }

            if (MessageBox.Show($"Удалить {current.User.Name} из группы?",
                "Подтверждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            _service.Remove(current);
            Members.Remove(current);
        }
    }
}