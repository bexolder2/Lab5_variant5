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
using System.IO;
using System.Xml.Serialization;

namespace Lab5_v5
{
    public partial class MainWindow : Window
    {
        public List<string> ComboBoxUnits = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
            data.ItemsSource = MyGlobals.company;
            cb_unit.ItemsSource = ComboBoxUnits;
        }

        private void AddPerson_Click(object sender, RoutedEventArgs e)
        {
            var newEmpl = new NewPerson();
            newEmpl.ShowDialog();
            UpdateComboBox();
            data.Items.Refresh();
        }

        private void Initialize()
        {
            Logic.Employes cmp;
            cmp = new Logic.Employes("Ivan", "Ivanov", 1250, "UNIT1");
            MyGlobals.company.Add(cmp);
            UpdateComboBox();
            cmp = new Logic.Employes("Dima", "Dmitrov", 9999, "UNIT2");
            MyGlobals.company.Add(cmp);
            UpdateComboBox();
            cmp = new Logic.Employes("Vladimir", "Petrov", 8888, "UNIT3");
            MyGlobals.company.Add(cmp);
            UpdateComboBox();
            cmp = new Logic.Employes("Alex", "Sidorov", 666, "UNIT2");
            MyGlobals.company.Add(cmp);
            cmp = new Logic.Employes("Lena", "Petrova", 500, "UNIT2");
            MyGlobals.company.Add(cmp);
        }

        private void UpdateComboBox()
        {
            string tmp = MyGlobals.company.Last().unit.Name;
            if(ComboBoxUnits.Find(x => x.Contains(tmp)) == null)
            {
                ComboBoxUnits.Add(tmp);
            }
            cb_unit.Items.Refresh();
        }

        private string UnitFilter()
        {
            string selectedrow = cb_unit.Text;
            if(selectedrow != "")
            {
                data.ItemsSource = null;
                data.Items.Clear();
                return selectedrow;
            }
            else
            {
                return null;
            }
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            string sr = UnitFilter();
            if(sr != null)
            {
                MyGlobals.ForFilter = MyGlobals.company.Where(res => res.unit.Name == sr).ToList();
                data.ItemsSource = MyGlobals.ForFilter;
                data.Items.Refresh();
            }
        }

        private void OffFilter_Click(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = null;
            data.ItemsSource = MyGlobals.company;
            data.Items.Refresh();
        }

        private void Serialize_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Logic.Employes>));

            using (FileStream fs = new FileStream("company.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, MyGlobals.company);
            }
        }
    }
}
