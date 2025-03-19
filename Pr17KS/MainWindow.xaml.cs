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
            
        }


    }
}