using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace _12prak.Pages
{
    public partial class InterestGroupForm : Page
    {
        InterestGroup _group = new InterestGroup();
        InterestGroupService service = new InterestGroupService();
        bool IsEdit = false;

        public InterestGroupForm(InterestGroup group = null)
        {
            InitializeComponent();
            if (group != null)
            {
                _group = group;
                IsEdit = true;
            }
            DataContext = _group;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_group.Title))
            {
                MessageBox.Show("Введите название группы", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var db = Service.BaseDbService.Instance.Context;
            bool exists = db.InterestGroups.Any(g => g.Title == _group.Title && g.Id != _group.Id);
            if (exists)
            {
                MessageBox.Show("Группа с таким названием уже существует", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

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