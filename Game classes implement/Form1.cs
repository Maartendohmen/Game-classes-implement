﻿using System;
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
        enum Celltype { Normal, Goal, Wall}
        public frmworld()
        {
            InitializeComponent();
        }
    }
}
