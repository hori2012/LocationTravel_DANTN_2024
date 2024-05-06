﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationTravel
{
    public partial class CombinationLoc : UserControl
    {
        public string name;
        public DataGridView dataGrid;
        public int width;

        public string NameCombination
        {
            get { return name; }
            set { name = value; groupLoc.Text = value; }
        }
        public DataGridView DataGrid
        {
            get { return dataGrid; }
        }
        public CombinationLoc()
        {
            InitializeComponent();
        }
    }
}