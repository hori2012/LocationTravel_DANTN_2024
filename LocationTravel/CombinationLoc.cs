using Guna.UI2.WinForms;
using LocationTravel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationTravel
{
    public partial class CombinationLoc : UserControl
    {
        private string name;
        private ModelRecommendation modelRecommendation = new ModelRecommendation();

        public string NameCombination
        {
            get { return name; }
            set { name = value; groupLoc.Text = value; }
        }
        public DataGridView DataGrid
        {
            get { return dtaGrid; }
        }
        public CombinationLoc()
        {
            InitializeComponent();
        }

        private void dtaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtaGrid.Columns[e.ColumnIndex].Name == "colLink")
            {
                string url = (string)dtaGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                System.Diagnostics.Process.Start(url);
            }
        }

        private async void btnDistance_Click(object sender, EventArgs e)
        {
            List<ItemLoc> listLocation = new List<ItemLoc>();
            foreach (DataGridViewRow row in dtaGrid.Rows)
            {
                int colId = Convert.ToInt32(row.Cells["colId"].Value);
                var location = modelRecommendation.Locations.Find(colId);
                ItemLoc itemloc = new ItemLoc() { Id = location.LocationId, Cost = (decimal)location.Cost, Latitude = (double)location.Latitude, Longitude = (double)location.Longitude };
                listLocation.Add(itemloc);
            }
        }
    }
}
