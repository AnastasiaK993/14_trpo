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
    /// Логика взаимодействия для GroupForm.xaml
    /// </summary>
    public partial class GroupForm : Page
    {
        Group _group = new Group();
        GroupsService service = new GroupsService();
        bool IsEdit = false;
        public GroupForm(Group group = null) //  public GroupForm(Group? group = null)
        {
            InitializeComponent();
            if (group != null)
            {
                service.LoadRelation(group, "Students");
                _group = group;
                IsEdit = true;
            }
            DataContext = _group;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_group);
            back(sender, e);
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
