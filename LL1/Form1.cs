using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LL1
{
    public  partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Thers is no grammer entered!");
                return;
            }
            try
            {

           my_functions.go(richTextBox1.Text);
           
            if (my_functions.IsLL1)
            {
                MessageBox.Show("This grammer is LL(1)! ");
                
            }
            else
            {
                MessageBox.Show("This grammer isnt LL(1). ");
    
            }
            }
            catch (Exception)
            {

                MessageBox.Show("The grammer is invalid!!");
            }
        }

        private void btn_do_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Thers is no grammer entered!");
                return;
            }
            try
            {

                MessageBox.Show(my_functions.ShowFirsts());
            }
            catch (Exception)
            {

                MessageBox.Show("The grammer is invalid!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Thers is no grammer entered");
                return;
            }
            try
            {

                MessageBox.Show(my_functions.ShowFollow());
            }
            catch (Exception)
            {

                MessageBox.Show("The grammer is invalid!!");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

