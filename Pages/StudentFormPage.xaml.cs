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

    public partial class StudentFormPage : Page
    {

        private StudentsService _service = new StudentsService();
        public Student _student = new Student();
        bool isEdit = false;

        public int ExcludedStudentId { get; set; } = 0;

        public StudentFormPage(Student _editStudent = null) //  public StudentFormPage(Student? _editStudent = null)
        {

            InitializeComponent();
            if (_editStudent != null)
            {
                _student = _editStudent;
                isEdit = true;
                ExcludedStudentId = _editStudent.Id;

                if (Resources["emailValidationRule"] is ValidationRules.emailValidationRule emailRule)
                    emailRule.ExcludedId = _editStudent.Id;
                if (Resources["loginValidationRule"] is ValidationRules.loginValidationRule loginRule)
                    loginRule.ExcludedId = _editStudent.Id;
            }
            if (_student.Passport == null)
                _student.Passport = new Passport();
            if (_student.UserProfile == null)
                _student.UserProfile = new UserProfile();
            DataContext = _student;
        }

        private void save(object sender, RoutedEventArgs e)
        {


            if (isEdit)
            {
                _student.CreatedAt = DateTime.Now;
                _service.Commit();
            }
            else
            {
                _student.CreatedAt = DateTime.Now;
                _service.Add(_student);

            }
            NavigationService.GoBack();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}