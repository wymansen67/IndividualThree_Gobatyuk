using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Personeel dep;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            dep = new Personeel(listBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                dep.Name = textBox1.Text;
                dep.BaseSalary = uint.Parse(textBox2.Text);
                dep.Coefficient = double.Parse(textBox3.Text);
                dep.P = int.Parse(textBox4.Text);

                dep.AddDepartment();
                listBox1.Items.Clear();
                dep.FillList();
                MessageBox.Show("Data was successfully add", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else  MessageBox.Show("Data cannot be writen. Check entered information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                dep.RemoveDepartment(textBox1.Text);
                listBox1.Items.Clear();
                dep.FillList();
                MessageBox.Show("Data was successfully removes", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Please enter department name to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
