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

namespace _12prak.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public StudentsService service { get; set; } = new StudentsService();
        public Student student { get; set; } = null; //   public Student? student { get; set; } = null;
        public MainPage()
        {
            InitializeComponent();
        }
        public void go_form(object sender, EventArgs e)
        {
            NavigationService.Navigate(new StudentFormPage());
        }
        private void go_to_groups(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupList());
        }
        private void editProfile(object sender, RoutedEventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите студента");
                return;
            }
            NavigationService.Navigate(new UserProfileForm(student));
        }
        private void go_to_interest_groups(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestGroupList());
        }
        public void remove(object sender, EventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(student);
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (student == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new StudentFormPage(student));
        }

        private void go_to_roles(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RoleList());
        }

        
    }
}
