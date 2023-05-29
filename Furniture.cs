using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    internal class Furniture
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }

        public int CurrentYear { get; set; }

        public int ReleaseYear { get; set; }

        public Furniture(string name, double price, int count, int releaseyear)
        {
            Name = name;
            Price = price;
            Count = count;
            CurrentYear = DateTime.Now.Year;
            ReleaseYear = releaseyear;

        }

        public double Quality()
        {
            return Price / Price;
        }

        public virtual double FurnitureQuality()
        {
            return Quality() + 0.5 * (CurrentYear - ReleaseYear);
        }

        public string GetInformation()
        {
            return $"{Name},{Price},{Count},{Quality()},{FurnitureQuality()}";
        }

        public string ToSave()
        {
            return $"{Name}, {Price}, {Count}, {ReleaseYear}";
        }
    }
}