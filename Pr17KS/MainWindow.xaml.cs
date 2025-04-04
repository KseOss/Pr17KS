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
            var addWindow = new AddEditStudentWindow(new SessionsResult());
            if (addWindow.ShowDialog() == true)
            {
                exam.SessionsResults.Add(addWindow.Student);
                exam.SaveChanges();
                LoadStudents();
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = dgStudents.SelectedItem as SessionsResult;
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
            var selectedStudent = dgStudents.SelectedItem as SessionsResult;
            if (selectedStudent == null)
            {
                MessageBox.Show("Выберите студента для удаления.");
                return;
            }

            if (MessageBox.Show("Вы уверены, что хотите удалить студента?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                exam.SessionsResults.Remove(selectedStudent);
                exam.SaveChanges();
                LoadStudents();
            }
        }
        private void SortStudents_Click(object sender, RoutedEventArgs e)
        {
            var selectedCriteriy = cmbSort.SelectedItem as ComboBoxItem;
            if (selectedCriteriy == null)
            {
                MessageBox.Show("Выберите критерий сортировки.");
                return;
            }
            IEnumerable<SessionsResult> sortedStudents;
            switch (selectedCriteriy.Content.ToString())
            {
                case "По фамилии":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.LastName);
                    break;
                case "По имени":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.FirstName);
                    break;
                case "По оценке по математике":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.Math);
                    break;
                case "По оценке по русскому":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.Rus);
                    break;
                case "По оценке по английскому":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.Eng);
                    break;
                case "По оценке по физике":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.Phys);
                    break;
                case "По оценке по информатике":
                    sortedStudents = exam.SessionsResults.OrderBy(s => s.Inf);
                    break;
                default:
                    MessageBox.Show("Неизвестный критерий сортировки.");
                    return;
            }
            dgStudents.ItemsSource = sortedStudents.ToList();
        }
        private void ResetSort_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }
        private void SearchStudents_Click(object sender, EventArgs e)
         {
             try
             {
                 string query = txtSearch.Text.ToLower();
                 var result = exam.SessionsResults.Where(s => s.FirstName.ToLower().Contains(query) || s.LastName.ToLower().Contains(query)).ToList();
                 dgStudents.ItemsSource = result;
             }
             catch (Exception ex) 
             {
                 MessageBox.Show($"Ошибка поиска: {ex.Message}");
             }

         }
        private void ClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadStudents();
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнила программу: Сухомяткина Ксения Игоревна\nГруппа: ИСП-34\n\nЗадание:\nВариант 18.\nРезультаты сессии на первом курсе кафедры ВТ. База данных должна содержать \nследующую информацию: индекс группы, фамилию, имя, отчество студента, пол \nстудента, семейное положение и оценки по пяти экзаменам\n\n1. Разработать интерфейс для доступа и управления однотабличной базой данных. \n2. Создать меню.\n3. Реализовать кнопки для функций Добавить, Редактировать, Удалить.\n4. Реализовать функции Добавить, Изменить с помощью окна – бланка.\n5. Реализовать поиск.\n6. Реализовать фильтр.\n7. Использовать исключения.", "Справка о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
