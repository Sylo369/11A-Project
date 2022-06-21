using Fruit_Project_Dimitar_Kuzmanov_11_A.Business;
using Fruit_Project_Dimitar_Kuzmanov_11_A.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruit_Project_Dimitar_Kuzmanov_11_A
{
    public partial class Form1 : Form
    {

        FruitBusiness fruitBusiness = new FruitBusiness();
        FruitTypeBusiness fruitTypeBusiness = new FruitTypeBusiness();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Fruit fruit)
        {
            textBox1.BackColor = Color.White;
            textBox1.Text = fruit.Id.ToString();
            textBox2.Text = fruit.Name;
            textBox3.Text = fruit.Description.ToString();
            textBox4.Text = fruit.Price.ToString();
            comboBox1.Text = fruit.FruitType.Name;
        }
        private void ClearScreen()
        {
            textBox1.BackColor = Color.White;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<FruitType> allTypes = fruitTypeBusiness.GetAllTypes();
            comboBox1.DataSource = allTypes;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            button5_Click(sender, e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Error: No name has been entered!");
                return;
            }
            Fruit fruit = new Fruit();
            fruit.Name = textBox2.Text;
            fruit.Description = textBox3.Text;
            fruit.Price = decimal.Parse(textBox4.Text);
            fruit.FruitTypeId = (int)comboBox1.SelectedValue;
            fruitBusiness.Add(fruit);
            button5_Click(sender, e);
            ClearScreen();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            List<Fruit> fruits = fruitBusiness.GetAll();
            listBox1.Items.Clear();

            foreach (var item in fruits)
            {
                listBox1.Items.Add($"ID: {item.Id} | Name: {item.Name} | Description:{item.Description} | Price:{item.Price}BGN | Fruit Type: {item.FruitType.Name}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Error: No ID to be found has been entered!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            Fruit fruit1 = fruitBusiness.Get(id);
            if (fruit1 == null)
            {
                MessageBox.Show("No such fruit has been found! \n Enter new ID!");
                textBox1.BackColor = Color.Red;
                return;
            }
            LoadRecord(fruit1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Error: No ID to be found has been entered!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                Fruit fruit1 = fruitBusiness.Get(id);
                if (fruit1 == null)
                {
                    MessageBox.Show("No such fruit has been found! \n Enter new ID!");
                    textBox1.BackColor = Color.Red;
                    return;
                }
                LoadRecord(fruit1);
            }
            else
            {
                Fruit fruit2 = new Fruit();
                fruit2.Name = textBox2.Text;
                fruit2.Description = textBox3.Text;
                fruit2.Price = decimal.Parse(textBox4.Text);             
                fruit2.FruitTypeId = (int)comboBox1.SelectedValue;
                fruitBusiness.Update(id, fruit2);
                button5_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(textBox1.Text) || !textBox1.Text.All(char.IsDigit))
            {
                MessageBox.Show("Error: No ID has been entered!");
                textBox1.BackColor = Color.Red;
                return;
            }
            else
            {
                id = int.Parse(textBox1.Text);
            }
            Fruit fruit1 = fruitBusiness.Get(id);
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                if (fruit1 == null)
                {
                    MessageBox.Show("No such fruit has been found! \n Enter new ID!");
                    textBox1.BackColor = Color.Red;
                    return;
                }
            }
            LoadRecord(fruit1);

            DialogResult delete = MessageBox.Show("Do you want to delete this fruit?", "Delete", MessageBoxButtons.YesNo);
            if (delete == DialogResult.Yes)
            {
                fruitBusiness.Delete(id);
            }
            button5_Click(sender, e);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       
    }
}
