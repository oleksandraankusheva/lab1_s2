using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Opacity == 1.0)
            {
                Opacity = 0.5;
            }
            else Opacity = 1.0;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (BackColor == DefaultBackColor)
            {
                BackColor = Color.Yellow;
            }
            else BackColor = DefaultBackColor;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        delegate void ButtonAction(object sender, EventArgs e);

        private void PerformActionsOnCheckedState(bool isChecked, Action<object, EventArgs> action)
        {
            if (isChecked)
            {
                action.Invoke(null, EventArgs.Empty);
            }
                
        }
        private void button4_Click(object sender, EventArgs e)
        {
            PerformActionsOnCheckedState(checkBox1.Checked, button1_Click);
            PerformActionsOnCheckedState(checkBox2.Checked, button2_Click_1);
            PerformActionsOnCheckedState(checkBox3.Checked, button3_Click_1);

            MessageBox.Show("Я супермегакнопка,\nі цього мене не позбавиш!");
        }
    }
}