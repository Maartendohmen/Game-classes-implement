using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_classes_implement
{
    public partial class frmworld : Form
    {
        public frmworld()
        {
            InitializeComponent();

            World.Instance.Create(pictureBox1.Size, new System.Drawing.Size(9, 9), 10);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            World.Instance.draw(e.Graphics);
        }


        private void frmworld_KeyDown(object sender, KeyEventArgs e)
        {
            World.Instance.Player.Interaction(e.KeyCode);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            World.Instance.update();
            pictureBox1.Refresh();

            if (World.Instance.GameOver)
            {
                timer.Enabled = false;
                MessageBox.Show("Verloren");
                this.Close();
            }

            if (World.Instance.GameWon)
            {
                timer.Enabled = false;
                MessageBox.Show("Gewonnen");
                this.Close();
            }
        }


    }
}


