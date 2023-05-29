using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    internal class Saving
    {
        public static void Load(Warehouse warehouse, string FileName)
        {
            if (File.Exists(FileName))
            {
                string[] book = File.ReadAllLines(FileName);

                foreach (string line in book)
                {
                    string[] components = line.Split(',');
                    if (components.Length == 4)
                    {
                        string name = components[0];
                        string price = components[1];
                        string count = components[2];
                        string releaseyear = components[3];
                        warehouse.AddFurniture(new Furniture(name, Convert.ToDouble(price), Convert.ToInt32(count), Convert.ToInt32(releaseyear)));
                    }
                }
            }
            else
            {
                MessageBox.Show("Файл не сущевтсвует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void Save(Warehouse warehouse, string FileName)
        {
            StreamWriter streamwriter = new StreamWriter(FileName);

            foreach(Furniture furniture in warehouse.GetFurniture().ToList())
            {
                streamwriter.WriteLine(furniture.ToSave());
            }

            streamwriter.Close();
        }
    }
}
