using LocationTravel.Model;
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
        private List<List<ItemLoc>> listItems;
        private decimal countPerson;
        public frmRecom(List<List<ItemLoc>> list, decimal countPerson)
        {
            InitializeComponent();
            this.listItems = list;
            this.countPerson = countPerson;
        }

        private void frmRecom_Load(object sender, EventArgs e)
        {
            modelRecommendation = new ModelRecommendation();
            AddItem();
        }

        private void flowLoc_Resize(object sender, EventArgs e)
        {
            foreach (Control item in flowLoc.Controls)
            {
                if (item is CombinationLoc combinationLoc)
                {
                    combinationLoc.Width = flowLoc.Width - 15;
                }
            }
        }

        private void btnRecom_Click(object sender, EventArgs e)
        {
            List<Control> controlsToRemove = new List<Control>();
            foreach (Control item in flowLoc.Controls)
            {
                if (item is CombinationLoc combinationLoc)
                {
                    controlsToRemove.Add(combinationLoc);
                }
            }
            foreach (Control item in controlsToRemove)
            {
                flowLoc.Controls.Remove(item);
            }
            AddItem();
        }
        public void AddItem()
        {
            List<List<ItemLoc>> backList = listItems.ToList();
            backList = backList.OrderBy(x => Guid.NewGuid()).Take(25).ToList();
            backList = backList.OrderBy(item => item.Sum(x => x.Cost)).ToList();
            int i = 1;
            foreach (var item in backList)
            {
                CombinationLoc combinationLoc = new CombinationLoc();
                combinationLoc.Width = flowLoc.Width;
                combinationLoc.NameCombination = "Gợi ý " + i + " - Tổng chi phí: " + item.Sum(x => x.Cost).ToString("N0", new CultureInfo("vi-VN")) + " VND";
                i++;
                var allLocations = item.SelectMany(element => modelRecommendation.Locations.Where(x => x.LocationId == element.Id));
                int j = 1;
                foreach (var element in allLocations)
                {
                    using (MemoryStream ms = new MemoryStream(element.Image))
                    {
                        Image img = Image.FromStream(ms);
                        combinationLoc.DataGrid.Rows.Add(j, element.LocationId, element.TypeLocation.NameType, element.SpecificType, img, element.NameLocation, element.Address, element.Link, (element.Cost.Value * countPerson).ToString("N0", new CultureInfo("vi-VN")) + " VND");
                        j++;
                    }
                }
                flowLoc.Controls.Add(combinationLoc);
            }
        }
    }
}
