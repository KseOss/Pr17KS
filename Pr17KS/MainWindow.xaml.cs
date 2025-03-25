using Pr17KS.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;

namespace Pr17KS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ExamResultContext exam;
        public MainWindow()
        {
            InitializeComponent();
            exam = new ExamResultContext();
            LoadStudents();
        }
        private void LoadStudents()
        {
            dgStudents.ItemsSource = exam.SessionsResults.ToList();
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddEditStudentWindow(new Student());
            if (addWindow.ShowDialog() == true)
            {
                exam.Students.Add(addWindow.Student);
                exam.SaveChanges();
                LoadStudents();
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dgStudents.SelectedItem as Student;
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите студента для редактирования.");
                return;
            }

            var editWindow = new AddEditStudentWindow(selectedStudent);
            if (editWindow.ShowDialog() == true)
            {
                exam.SaveChanges();
                LoadStudents();
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dgStudents.SelectedItem as Student;
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить студента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                exam.Students.Remove(selectedStudent);
                exam.SaveChanges();
                LoadStudents();
            }
        }
    }
}
