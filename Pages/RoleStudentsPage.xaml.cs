using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class RoleStudentsPage : Page
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public RoleStudentsPage(Role role)
        {
            InitializeComponent();
            Title = $"Студенты с ролью: {role.Title}";

            var studentsService = new StudentsService();
            var studentsWithRole = studentsService.Students
                .Where(s => s.RoleId == role.Id)
                .ToList();

            foreach (var student in studentsWithRole)
            {
                Students.Add(student);
            }

            DataContext = this;
        }

        private void back(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}