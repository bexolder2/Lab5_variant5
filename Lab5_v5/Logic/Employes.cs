using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Lab5_v5.Logic
{
    [Serializable]
    public class Employes
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Salary { get; set; }
        public Unit unit { get; set; }

        public Employes()
        {

        }

        public Employes(string fName, string lName, int salary, string uName)
        {
            FirstName = fName;
            LastName = lName;
            Salary = salary;
            unit = new Unit(uName);
        }
    }
}
