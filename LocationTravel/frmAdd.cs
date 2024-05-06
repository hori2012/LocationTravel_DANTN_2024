using LocationTravel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationTravel
{
    public partial class frmAdd : Form
    {
        private ModelRecommendation modelRecommendation;
        public frmAdd()
        {
            InitializeComponent();
        }

        private void frmAdd_Load(object sender, EventArgs e)
        {
            modelRecommendation = new ModelRecommendation();
            var area = modelRecommendation.Areas.ToList();
            comArea.DataSource = area;
            comArea.DisplayMember = "NameArea";
            comArea.ValueMember = "AreaId";

            var typeLocation = modelRecommendation.TypeLocations.ToList();
            comTypeLocation.DataSource = typeLocation;
            comTypeLocation.DisplayMember = "NameType";
            comTypeLocation.ValueMember = "TypeId";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.NameLocation = txtName.Text;
            location.Address = txtAddress.Text;
            location.Description = txtDecripstion.Text;
            location.SpecificType = txtType.Text;
            location.Link = txtLink.Text;
            location.Cost = Decimal.Parse(txtCost.Text);
            using (MemoryStream ms = new MemoryStream())
            {
                picImage.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageData = ms.ToArray();
                location.Image = imageData;
            }
            if (comArea.SelectedItem != null)
            {
                location.AreaId = (int)comArea.SelectedValue;
            }
            else
            {
                location.AreaId = 1;
            }
            if (comTypeLocation.SelectedItem != null)
            {
                location.TypeId = (int)comTypeLocation.SelectedValue;
            }
            else
            {
                location.TypeId = 1;
            }
            modelRecommendation.Locations.Add(location);
            modelRecommendation.SaveChanges();
            DialogResult dialog = MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK);
            if (dialog == DialogResult.OK)
            {
                txtName.Clear();
                txtAddress.Clear();
                txtDecripstion.Clear();
                txtLink.Clear();
            }
        }

        private void linkAddImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    picImage.Image = System.Drawing.Image.FromFile(imagePath);
                }
            }
        }
    }
}
