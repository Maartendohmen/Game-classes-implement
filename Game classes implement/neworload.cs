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
    public partial class neworload : Form
    {
        public bool load;
        public neworload()
        {
            InitializeComponent();          
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            load = false;
            frmworld frmworld = new frmworld(load);
            frmworld.Show();
            frmworld.Focus();
            
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            load = true;
            frmworld frmworld = new frmworld(load);
            frmworld.Show();
            frmworld.Focus();
        }
    }
}
