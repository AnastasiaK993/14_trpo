using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class GroupList : Page
    {
        public GroupsService service { get; set; } = new GroupsService();
        public Group current { get; set; } = null;
        public ObservableCollection<Student> GroupStudents { get; set; } = new ObservableCollection<Student>();

        public GroupList()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupForm());
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            if (current != null)
            {
                NavigationService.Navigate(new GroupForm(current));
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
      
    }
}