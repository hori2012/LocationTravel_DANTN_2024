using LocationTravel.Model;
using System;
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
            foreach (var item in listItems)
            {

            }
        }

        private void flowLoc_Resize(object sender, EventArgs e)
        {
            foreach (var item in flowLoc)
            {
                if(item is CombinationLoc)
                {
                    item.
                }
            }
        }
    }
}
