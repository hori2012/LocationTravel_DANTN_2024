using LocationTravel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocationTravel
{
    public partial class frmMain : Form
    {
        private ModelRecommendation modelRecommendation;
        private decimal _cost;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            modelRecommendation = new ModelRecommendation();
            var area = modelRecommendation.Areas.ToList();
            comArea.DataSource = area;
            comArea.DisplayMember = "NameArea";
            comArea.ValueMember = "AreaId";
            List<TimeTravel> timeTravels = new List<TimeTravel>()
            {
                new TimeTravel{ Id = 1, TypeTime = "1 ngày" },
                new TimeTravel{ Id = 2,TypeTime = "2 ngày 1 đêm"}
            };
            comTimeTravel.DataSource = timeTravels;
            comTimeTravel.DisplayMember = "TypeTime";
            comTimeTravel.ValueMember = "Id";

            var type = modelRecommendation.Locations.Select(x => new { x.SpecificType, x.TypeId }).Distinct().ToList();
            foreach (var item in type)
            {
                if (item.TypeId == 1)
                {
                    listCbHotels.Items.Add(item.SpecificType);
                }
                else if (item.TypeId == 2)
                {
                    listCbFoods.Items.Add(item.SpecificType);
                }
                else if (item.TypeId == 3)
                {
                    listCbPlay.Items.Add(item.SpecificType);
                }
                else
                {
                    listCbCoffee.Items.Add(item.SpecificType);
                }
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out _) == false)
            {
                errorCheck.SetError(txtPrice, "Chỉ nhập số");
            }
            else
            {
                errorCheck.SetError(txtPrice, "");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dtaGrid.Rows.Clear();
            if (decimal.TryParse(txtPrice.Text, out _) == false)
            {
                errorCheck.SetError(txtPrice, "Chỉ nhập số");
            }
            else
            {
                errorCheck.SetError(txtPrice, "");
                listCbHotels.ClearSelected();
                listCbFoods.ClearSelected();
                listCbPlay.ClearSelected();
                listCbCoffee.ClearSelected();
                _cost = decimal.Parse(txtPrice.Text);
                var location = modelRecommendation.Locations.Where(x => x.Cost <= _cost && x.AreaId == (int)comArea.SelectedValue);
                int i = 1;
                foreach (var item in location)
                {
                    using (MemoryStream ms = new MemoryStream(item.Image))
                    {
                        Image img = Image.FromStream(ms);
                        dtaGrid.Rows.Add(i, item.LocationId, item.TypeLocation.NameType, item.SpecificType, img, item.NameLocation, item.Address, item.Description, item.Link, item.Cost.Value.ToString("N0", new CultureInfo("vi-VN")) + " VND");
                        i++;
                    }
                }
            }
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (dtaGrid.Rows.Count > 0)
            {
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in dtaGrid.Rows)
                {
                    if (listCbHotels.CheckedItems.Count > 0)
                    {
                        foreach (var check in listCbHotels.CheckedItems)
                        {
                            if (String.Compare(check.ToString(), row.Cells["colType"].Value.ToString()) != 0 && String.Compare("Lưu trú", row.Cells["colArea"].Value.ToString()) == 0)
                            {
                                rowsToRemove.Add(row);
                            }
                        }
                    }
                    if (listCbFoods.CheckedItems.Count > 0)
                    {
                        foreach (var check in listCbFoods.CheckedItems)
                        {
                            if (String.Compare(check.ToString(), row.Cells["colType"].Value.ToString()) != 0 && String.Compare("Ăn uống", row.Cells["colArea"].Value.ToString()) == 0)
                            {
                                rowsToRemove.Add(row);
                            }
                        }
                    }
                    if (listCbPlay.CheckedItems.Count > 0)
                    {
                        foreach (var check in listCbPlay.CheckedItems)
                        {
                            if (String.Compare(check.ToString(), row.Cells["colType"].Value.ToString()) != 0 && String.Compare("Vui chơi/Tham quan", row.Cells["colArea"].Value.ToString()) == 0)
                            {
                                rowsToRemove.Add(row);
                            }
                        }
                    }
                    if (listCbCoffee.CheckedItems.Count > 0)
                    {
                        foreach (var check in listCbCoffee.CheckedItems)
                        {
                            if (String.Compare(check.ToString(), row.Cells["colType"].Value.ToString()) != 0 && String.Compare("Cà phê", row.Cells["colArea"].Value.ToString()) == 0)
                            {
                                rowsToRemove.Add(row);
                            }
                        }
                    }
                }
                foreach (DataGridViewRow row in rowsToRemove)
                {
                    dtaGrid.Rows.Remove(row);
                }
                int i = 1;
                foreach (DataGridViewRow row in dtaGrid.Rows)
                {
                    row.Cells["colSTT"].Value = i;
                    i++;
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu!");
            }
        }

        private void dtaGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtaGrid.Columns[e.ColumnIndex].Name == "colLink")
            {
                string url = (string)dtaGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                System.Diagnostics.Process.Start(url);
            }
        }

        private void btnRecom_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrice.Text) && dtaGrid.Rows.Count > 0)
            {
                _cost = decimal.Parse(txtPrice.Text);
                List<Location> listLocation = new List<Location>();
                foreach (DataGridViewRow row in dtaGrid.Rows)
                {
                    int colId = Convert.ToInt32(row.Cells["colId"].Value);

                    var location = modelRecommendation.Locations.Where(x => x.LocationId == colId).ToList();

                    listLocation.AddRange(location);
                }
                List<Item> hotels = new List<Item>();
                List<Item> foods = new List<Item>();
                List<Item> entertains = new List<Item>();
                List<Item> coffees = new List<Item>();
                foreach (var item in listLocation)
                {
                    if (item.TypeId == 1)
                    {
                        hotels.Add(new Item() { Id = item.LocationId, Cost = (decimal)item.Cost });
                    }
                    else if (item.TypeId == 2)
                    {
                        foods.Add(new Item() { Id = item.LocationId, Cost = (decimal)item.Cost });
                    }
                    else if (item.TypeId == 3)
                    {
                        entertains.Add(new Item() { Id = item.LocationId, Cost = (decimal)item.Cost });
                    }
                    else
                    {
                        coffees.Add(new Item() { Id = item.LocationId, Cost = (decimal)item.Cost });
                    }
                }
                int numHotel = 0, numFoods = 0, numEntertain = 0, numCoffee = 0;
                List<List<Item>> combinations = new List<List<Item>>();
                if ((int)comTimeTravel.SelectedValue == 1)
                {
                    numHotel = 1;
                    numFoods = 4;
                    numEntertain = 3;
                    numCoffee = 2;
                    numHotel = hotels.Count > 1 ? numHotel : hotels.Count;
                    numFoods = foods.Count > 4 ? numFoods : foods.Count;
                    numEntertain = entertains.Count > 3 ? numEntertain : entertains.Count;
                    numCoffee = coffees.Count > 2 ? numCoffee : coffees.Count;
                    combinations = ModuleCost.FindCombinations(hotels, foods, entertains, coffees, numHotel, numFoods, numEntertain, numCoffee, _cost).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                    if (combinations.Count != 0)
                    {
                        Debug.WriteLine("Tổ hợp địa điểm: \n");
                        foreach (var item in combinations)
                        {
                            Debug.WriteLine(string.Join(", ", item.Select(element => $"Id: {element.Id} - Cost: {element.Cost}")));
                        }
                        frmRecom form = new frmRecom(combinations);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không thể khởi tạo!");
                    }
                }
                else
                {
                    numHotel = 1;
                    numFoods = 5;
                    numEntertain = 4;
                    numCoffee = 3;
                    numHotel = hotels.Count > 1 ? numHotel : hotels.Count;
                    numFoods = foods.Count > 4 ? numFoods : foods.Count;
                    numEntertain = entertains.Count > 3 ? numEntertain : entertains.Count;
                    numCoffee = coffees.Count > 2 ? numCoffee : coffees.Count;
                    combinations = ModuleCost.FindCombinations(hotels, foods, entertains, coffees, numHotel, numFoods, numEntertain, numCoffee, _cost).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                    if (combinations.Count != 0)
                    {
                        Debug.WriteLine("Tổ hợp địa điểm: \n");
                        foreach (var item in combinations)
                        {
                            Debug.WriteLine(string.Join(", ", item.Select(element => $"Id: {element.Id} - Cost: {element.Cost}")));
                        }
                        frmRecom form = new frmRecom(combinations);
                        form.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Không thể khởi tạo!!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể khởi tạo!!");
            }
        }
    }
}
