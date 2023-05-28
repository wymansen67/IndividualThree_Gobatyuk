using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Department
    {
        public string name;
        public uint baseSalary;
        public byte coefficient;

        public string Name { get; set; }
        public uint BaseSalary { get; set; }
        public byte Coefficient { get; set; }

        public Department() { }
    }
}
