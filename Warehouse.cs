using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse
{
    internal class Warehouse
    {
        List<Furniture> FurnitureList;
        public Warehouse()
        {
            FurnitureList = new List<Furniture>();
        }

        public void AddFurniture(Furniture furniture)
        {
            FurnitureList.Add(furniture);
        }

        public bool CheckContainsFurniture(string furniturename)
        {
            bool NotFound = true;

            foreach (Furniture Contact in FurnitureList)
            {
                if (Contact.Name.Contains(furniturename))
                {
                    NotFound = false;
                    break;
                }
            }
            return NotFound;
        }

        public List<Furniture> GetFurniture() { return FurnitureList; }

        public List<Furniture> SearchFurniture(Warehouse warehouse, string furniturename)
        {
            bool search = false;
            List<Furniture> searchResults = new List<Furniture>();
            foreach (Furniture furniture in warehouse.GetFurniture())
            {
                if (furniture.Name.Contains(furniturename))
                {
                    searchResults.Add(furniture);
                    search = true;
                }
            }

            if (search == false)
            {
                MessageBox.Show("Не найдено.");
            }

            return searchResults;
        }

        public void RemoveFurniture(Warehouse warehouse, Furniture selectedfurniture)
        {
            FurnitureList.Remove(selectedfurniture);
        }
    }
}