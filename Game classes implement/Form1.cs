﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Data;


namespace Game_classes_implement
{
    public partial class frmworld : Form
    {
        FileContent filecontent = new FileContent();
        public frmworld(bool load)
        {
            InitializeComponent();
            if (load == false)
            {
                World.Instance.Create(pictureBox1.Size, new System.Drawing.Size(9, 9), 10, 1);
                timer.Enabled = true;
            }
            else if (load == true)
            {
                string filelocation = "";
                OpenFileDialog selectpath = new OpenFileDialog();
                if (selectpath.ShowDialog() == DialogResult.OK)
                {
                    filelocation = selectpath.FileName;
                    Map hallo = filecontent.LoadMap(filelocation);
                    World.Instance.load(hallo);
                    timer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sorry, somthing went wrong");
                }                
            }
            
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
            World.Instance.changelabel(lbwheight);
            

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

        private void button1_Click(object sender, EventArgs e)
        {           
            timer.Enabled = false;
            SaveFileDialog directchoosedlg = new SaveFileDialog();
            directchoosedlg.Filter = "Text Files (*.txt)|*.txt";
            directchoosedlg.DefaultExt = "txt";
            directchoosedlg.AddExtension = true;

            string folderPath = "";
            
            if (directchoosedlg.ShowDialog() == DialogResult.OK )
            {
                folderPath = directchoosedlg.FileName;
            }
            else
            {
                MessageBox.Show("Map not saved");
            }
            filecontent.SaveMap(World.Instance.Map, folderPath);
            World wereld = new World();
            timer.Enabled = true;
        }

    }   
}


