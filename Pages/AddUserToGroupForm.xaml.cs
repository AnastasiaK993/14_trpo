using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class AddUserToGroupForm : Page
    {
        private InterestGroup _group;
        private UserInterestGroupService _service = new UserInterestGroupService();
        private StudentsService _studentsService = new StudentsService();

        public string GroupTitle => _group.Title;

        public AddUserToGroupForm(InterestGroup group)
        {
            InitializeComponent();
            _group = group;

            UserBox.ItemsSource = _studentsService.Students;
            UserBox.SelectedIndex = -1;

            JoinedAtPicker.SelectedDate = DateTime.Today;

            DataContext = this;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            Student selectedUser = UserBox.SelectedItem as Student;
            if (selectedUser == null)
            {
                MessageBox.Show("Выберите пользователя");
                return;
            }

            if (JoinedAtPicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату вступления");
                return;
            }

            ComboBoxItem roleItem = (ComboBoxItem)RoleBox.SelectedItem;
            bool isModerator = roleItem.Content.ToString() == "Модератор";

            var db = Service.BaseDbService.Instance.Context;
            bool alreadyExists = db.UserInterestGroups
                .Any(x => x.UserId == selectedUser.Id && x.InterestGroupId == _group.Id);
            if (alreadyExists)
            {
                MessageBox.Show("Этот пользователь уже состоит в данной группе",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var uig = new UserInterestGroup
            {
                UserId = selectedUser.Id,
                User = selectedUser,
                InterestGroupId = _group.Id,
                InterestGroup = _group,
                JoinedAt = JoinedAtPicker.SelectedDate.Value,
                IsModerator = isModerator,
            };

            try
            {
                _service.Add(uig);
                MessageBox.Show("Пользователь добавлен в группу");
                back(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}