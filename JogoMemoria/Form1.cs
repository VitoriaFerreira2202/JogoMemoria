using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoMemoria
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Label firstClicked = null;
        Label secondClicked = null;

        List<string> icons = new List<string>()
            {
                "A","A","b","b",
                "C","C","d","d",
                "E","E","f","f",
                "G","G","h","h"
            };

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }


        public void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);

                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                return;
            }

            Label clickLabel = sender as Label;

            if (clickLabel != null)
            {
                if (clickLabel.ForeColor == Color.Black)
                {
                    return;
                }

                if (firstClicked == null)
                {
                    firstClicked = clickLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickLabel;
                secondClicked.ForeColor = Color.Black;

                ChecarVencedor();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void ChecarVencedor()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show(" VOCÊ TERMINOU", "PARABÉNS");
            Close();
        }
                    
               

            
        
    }
}
