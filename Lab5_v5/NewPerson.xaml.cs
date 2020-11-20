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

namespace Lab5_v5
{
    /// <summary>
    /// Логика взаимодействия для NewPerson.xaml
    /// </summary>
    public partial class NewPerson : Window
    {
        public NewPerson()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int salary_;

            if (string.IsNullOrWhiteSpace(tb_fname.Text))
                MessageBox.Show("Enter correct first name!");
            else if(string.IsNullOrWhiteSpace(tb_lname.Text))
                MessageBox.Show("Enter correct last name!");
            else if (string.IsNullOrWhiteSpace(tb_unit.Text))
                MessageBox.Show("Enter correct unit name!");
            else if (int.TryParse(tb_salary.Text, out salary_) == false)
                MessageBox.Show("Enter correct salary!");
            else
            {
                MyGlobals.company.Add(new Logic.Employes(tb_fname.Text, tb_lname.Text, salary_, tb_unit.Text));
                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
