using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VampireSurvivorsRandomCharacterGenerator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            PopulateDropDown();
            if(Form1.customFieldValues.Count() > 0)
            {
                PopulateAllTextBoxes();
            }
            InitialiseValidation();
        }

        private void PopulateDropDown()
        {
            if(Form1.weaponsAndIds.Count() > 0)
            {
                ComboItem[] items = new ComboItem[Form1.weaponsAndIds.Count()];
                int i = 0;
                foreach(var item in Form1.weaponsAndIds)
                {
                    items[i] = new ComboItem() { ID = i, Text = item.Key };
                    i++;
                }
                weaponDropDown.DataSource = items;
            }
            if (Form1.customFieldValues.ContainsKey("startingWeapon"))
            {
                weaponDropDown.Text = Form1.customFieldValues["startingWeapon"];
            }
        }

        private void InitialiseValidation()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                if(tb.Name != "NameTextBox")
                {
                    tb.KeyPress += NumericValidation;
                }
            }
        }

        void NumericValidation(object sender, KeyPressEventArgs e)
        {
            if ((!(Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))) && e.KeyChar != '-')
            { e.Handled = true; }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Ensure all form data is saved
            this.Close();
        }

        private void PopulateAllTextBoxes()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                string textBoxName = tb.Name.Replace("TextBox", "");
                if (!string.IsNullOrEmpty(textBoxName))
                {
                    textBoxName = Char.ToLower(textBoxName[0]) + textBoxName.Substring(1);
                }
                if (Form1.customFieldValues.ContainsKey(textBoxName))
                {
                    tb.Text = Form1.customFieldValues[textBoxName];
                }
            }
        }

        private void SaveAllFields()
        {
            foreach(TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = tb.Text.Trim();
                bool negative = false;
                if(tb.Text.Length > 0 && tb.Text.Contains("-"))
                {
                    if(tb.Text[0] == '-')
                    {
                        negative = true;
                    }
                    tb.Text = tb.Text.Replace("-", "");
                    tb.Text = "-" + tb.Text;
                }
                string textBoxName = tb.Name.Replace("TextBox", "");
                if(!string.IsNullOrEmpty(textBoxName))
                {
                    textBoxName = Char.ToLower(textBoxName[0]) + textBoxName.Substring(1);
                }
                if(Form1.customFieldValues.ContainsKey(textBoxName))
                {
                    Form1.customFieldValues[textBoxName] = tb.Text;
                }
                else
                {
                    Form1.customFieldValues.Add(textBoxName, tb.Text);
                }
            }
            foreach(ComboBox comboBox in this.Controls.OfType<ComboBox>())
            {
                if(comboBox.Name == "weaponDropDown")
                {
                    if (Form1.customFieldValues.ContainsKey("startingWeapon"))
                    {
                        Form1.customFieldValues["startingWeapon"] = comboBox.Text;
                    }
                    else
                    {
                        Form1.customFieldValues.Add("startingWeapon", comboBox.Text);
                    }
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAllFields();
        }

        private void MaxHPTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class ComboItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }
}
