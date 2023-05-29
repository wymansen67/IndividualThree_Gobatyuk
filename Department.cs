using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Department
    {
        public string Name { get; set; }
        public uint BaseSalary { get; set; }
        public double Coefficient { get; set; }

        public Department() {}

        public Department(string name, uint baseSalary, byte coefficient, ushort harmfulness)
        {
            Name = name;
            BaseSalary = baseSalary;
            Coefficient = coefficient;
        }

        public double Quality()
        {
            return BaseSalary * (100 + Coefficient);
        }

        virtual public string GetInformation()
        {
            return $"Name: {Name}\nBase salary: {BaseSalary}\nCoefficient: {Coefficient}\n";
        }
    }
}
