using Pr17KS.Models;
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
using System.Windows.Shapes;

namespace Pr17KS
{
    /// <summary>
    /// Логика взаимодействия для AddEditStudentWindow.xaml
    /// </summary>
    public partial class AddEditStudentWindow : Window
    {
        public SessionsResult Student {  get; private set; }
        public AddEditStudentWindow(SessionsResult student)
        {
            InitializeComponent();
            Student = student;
            txtGroupIndex.Text = student.GroupIndex;
            txtLastName.Text = student.LastName;
            txtFirstName.Text = student.FirstName;
            txtMiddleName.Text = student.MiddleName;
            txtGender.Text = student.Gender;
            txtMaritalStatid.Text = student.MaritalStatus;
            txtMath.Text = student.Math.ToString();
            txtRus.Text = student.Rus.ToString();
            txtPhys.Text = student.Phys.ToString();
            txtInf.Text = student.Inf.ToString();
            txtEng.Text = student.Eng.ToString();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                Student.GroupIndex = txtGroupIndex.Text;
                Student.LastName = txtLastName.Text;
                Student.FirstName = txtFirstName.Text;
                Student.MiddleName = txtMiddleName.Text;
                Student.Gender = txtGender.Text;
                Student.MaritalStatus = txtMaritalStatid.Text;
                Student.Math = int.Parse(txtMath.Text);
                Student.Rus = int.Parse(txtRus.Text);
                Student.Phys = int.Parse(txtPhys.Text);
                Student.Inf = int.Parse(txtInf.Text);
                Student.Eng = int.Parse(txtEng.Text);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
        
    }
}
