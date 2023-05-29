using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Warehouse
{
    public partial class FormFurnitureWarehouse : Form
    {
        private static Warehouse warehouse;
        public FormFurnitureWarehouse()
        {
            InitializeComponent();
        }

        private void FormFurnitureWarehouse_Load(object sender, EventArgs e)
        {
            if (File.Exists("warehousefurniture.txt"))
            {
                Saving.Load(warehouse, "warehousefurniture.txt");
                RefreshList();
            }
            else
            {
                MessageBox.Show("Файл не сущевтсвует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshList()
        {
            ListBoxFurniture.Items.Clear();
            foreach (Furniture furniture in warehouse.GetFurniture())
            {
                ListBoxFurniture.Items.Add(furniture.GetInformation());
            }
        }

        private void ButtonExite_Click(object sender, EventArgs e)
        {
            Saving.Save(warehouse, "warehousefurniture.txt");
            this.Close();
        }

        private void ButtonRefreshListBox_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void ButtonSearchFurniture_Click(object sender, EventArgs e)
        {
            string SearchComponent = TextBoxSearchFurniture.Text;
            if (SearchComponent != "")
            {
                List<Furniture> searchResults = warehouse.SearchFurniture(warehouse, SearchComponent);
                ListBoxFurniture.Items.Clear();
                foreach (Furniture contact in searchResults)
                {
                    ListBoxFurniture.Items.Add(contact.GetInformation());
                }
            }
        }

        private void ButtonSotrListBox_Click(object sender, EventArgs e)
        {
            ListBoxFurniture.Sorted = true;
        }

        private void ButtonDeleteSelectedFurniture_Click(object sender, EventArgs e)
        {
            string[] components = ListBoxFurniture.SelectedItem.ToString().Split(',');
            string name = components[0];
            string price = components[1];
            string count = components[2];
            string releaseyear = components[3];

            Furniture furniture = new Furniture(name, Convert.ToDouble(price), Convert.ToInt32(count), Convert.ToInt32(releaseyear));

            if (ListBoxFurniture.SelectedIndex != -1)
            {
                warehouse.RemoveFurniture(warehouse, furniture);
            }

            RefreshList();
        }

        private void ButtonFilterPrice_Click(object sender, EventArgs e)
        {
            string SearchComponent = TextBoxSearchFurniture.Text;
            if (SearchComponent != "")
            {
                List<Furniture> searchResults = warehouse.SearchFurniture(warehouse, SearchComponent);
                ListBoxFurniture.Items.Clear();
                foreach (Furniture furniture in searchResults)
                {
                    ListBoxFurniture.Items.Add(furniture.GetInformation());
                }
            }
        }

        static string CheckName(string TextName)
        {
            string message = "";

            if (TextName == "")
            {
                message = "Поле для ввода названия не может быть пустым.";
            }
            else
            {
                foreach (char symbol in TextName)
                {
                    if (!char.IsLetter(symbol) && symbol != ' ')
                    {
                        message = "Поле название может содержать только буквы.";
                        break;
                    }

                }
            }

            return message;
        }

        static string CheckNumberTextBox(string TextPrice, string TextCount, string TextYear)
        {
            string message = "";

            if (TextPrice == "" || TextCount == "" || TextYear == "")
            {
                message = "Поля для ввода цены, количества, и года изготовления не могут быть пустым.";
            }
            else
            {
                if (message == "")
                {
                    foreach (char symbol in TextPrice)
                    {
                        if (!char.IsDigit(symbol) && symbol != '.')
                        {
                            message = "Поле для ввода цены может содержать только дробное значение.";
                            break;
                        }

                    }

                    foreach (char symbol in TextCount)
                    {
                        if (!char.IsDigit(symbol))
                        {
                            message = "Поле для ввода количества может содержать только цифры";
                            break;
                        }

                    }

                    foreach (char symbol in TextYear)
                    {
                        if (!char.IsDigit(symbol))
                        {
                            message = "Поле для ввода года изготовления может содержать только цифры";
                            break;
                        }

                    }
                }

                if (message == "")
                {
                    if (TextYear.Length < 4 || TextYear.Length > 4)
                    {
                        message = "Некорректное количество символов в поле года изготовления.";
                    }
                }

                if (message == "")
                {
                    if (Convert.ToInt32(TextYear) < 2000 || Convert.ToInt32(TextYear) > DateTime.Now.Year)
                    {
                        message = "Год изготовления не может быть больше текущего года и раньше 2000-ного года. На этом складе временно запрещено хранение антиквариата.";
                    }
                }
            }

            return message;
        }

        static void AddFurniture(string TextName, string TextPrice, string TextCount, string TextYear)
        {
            Furniture furniture = new Furniture(TextName, Convert.ToDouble(TextPrice), Convert.ToInt32(TextCount), Convert.ToInt32(TextYear));
            warehouse.AddFurniture(furniture);
        }

        private void ButtonAddFurniture_Click(object sender, EventArgs e)
        {
            string name = TextBoxFurnitureName.Text;
            string price = TextBoxFurniturePrice.Text;
            string count = TextBoxFurnitureCount.Text;
            string releaseyear = TextBoxDateOfManufacture.Text;

            string message;

            message = CheckName(name);

            if (message == "")
            {
                message = CheckNumberTextBox(price, count, releaseyear);

                if (message == "")
                {
                    bool NotFound = warehouse.CheckContainsFurniture(name);
                    if (NotFound == true)
                    {
                        AddFurniture(name, price, count, releaseyear);
                        MessageBox.Show("Мебель добавлена.");
                    }
                    else
                    {
                        MessageBox.Show("Такая мебель уже существует.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}