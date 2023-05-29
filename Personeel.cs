using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Personeel : Department
    {
        private List<string> department;
        private ListBox listBox;

        public int P { get; set; }

        public Personeel(ListBox listBox)
        {
            department = new List<string>();
            this.listBox = listBox;
        }

        public double Qpres()
        {
            return Quality() + (Quality() / P);
        }

        override public string GetInformation()
        {
            return $"Name: {Name}\nBase salary: {BaseSalary}\nCoefficient: {Coefficient}\n, Q={Quality()}, P={P}, Qp={Qpres()}";
        }

        public void AddDepartment()
        {
            department.Add(GetInformation());
        }

        public void RemoveDepartment(string name)
        {
            department.RemoveAll(department => department.Contains($"Name:{Name}"));
        }

        public void FillList()
        {
            foreach (var thing in department)
            {
                listBox.Items.Add(thing);
            }
        }
    }
}
