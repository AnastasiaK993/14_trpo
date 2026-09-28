using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class UserProfileForm : Page
    {
        private Student _student;
        private StudentsService _service = new StudentsService();

        public UserProfileForm(Student student)
        {
            InitializeComponent();
            _student = student;

            if (_student.UserProfile == null)
            {
                _student.UserProfile = new UserProfile();
            }

            DataContext = _student;

            var uigService = new UserInterestGroupService();
            var groups = uigService.GetUserGroups(_student.Id);
            UserGroupsList.ItemsSource = groups;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            _service.Commit();
            MessageBox.Show("Профиль сохранен");
            back(sender, e);
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}