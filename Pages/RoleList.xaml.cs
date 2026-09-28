using _12prak.Data;
using _12prak.Service;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class RoleList : Page
    {
        private AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; set; } = new ObservableCollection<Role>();
        public Role SelectedRole { get; set; }

        public RoleList()
        {
            InitializeComponent();

            var roles = _db.Roles.ToList();
            foreach (var r in roles)
                Roles.Add(r);

            DataContext = this;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ViewStudents(object sender, MouseButtonEventArgs e)
        {
            if (SelectedRole != null)
            {
                NavigationService.Navigate(new RoleStudentsPage(SelectedRole));
            }
            else
            {
                MessageBox.Show("Выберите роль");
            }
        }
    }
}