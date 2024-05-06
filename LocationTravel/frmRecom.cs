﻿using LocationTravel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationTravel
{
    public partial class frmRecom : Form
    {
        private ModelRecommendation modelRecommendation;
        private List<List<Item>> listItems;
        public frmRecom(List<List<Item>> list)
        {
            InitializeComponent();
            this.listItems = list;
        }

        private void frmRecom_Load(object sender, EventArgs e)
        {
            modelRecommendation = new ModelRecommendation();
            int i = 1;
            foreach (var item in listItems)
            {
                CombinationLoc combinationLoc = new CombinationLoc();
                combinationLoc.NameCombination = "Gợi ý " + i;
                i++;
                var allLocations = item.SelectMany(element => modelRecommendation.Locations.Where(x => x.LocationId == element.Id));
                int j = 1;
                foreach (var element in allLocations)
                {
                    using (MemoryStream ms = new MemoryStream(element.Image))
                    {
                        Image img = Image.FromStream(ms);
                        combinationLoc.DataGrid.Rows.Add(j, element.LocationId, element.TypeLocation.NameType, element.SpecificType, img, element.NameLocation, element.Address, element.Link, element.Cost.Value.ToString("N0", new CultureInfo("vi-VN")) + " VND");
                        j++;
                    }
                }
                flowLoc.Controls.Add(combinationLoc);
            }
        }

        private void flowLoc_Resize(object sender, EventArgs e)
        {
           
        }
    }
}
