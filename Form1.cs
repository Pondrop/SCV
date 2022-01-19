using ExcelDataReader;
using SCV.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCV
{
    public partial class Form1 : Form
    {
        private List<ProductSCV> _products;
        private List<string> _preferences, _preferences2, _preferences3;
        public Form1()
        {
            InitializeComponent();
            _preferences = new List<string>();
            _products = GetData();
            List<string> categories = _products.Select(x => x.Category).Distinct().ToList();
            _preferences = _preferences.Distinct().ToList();
            _preferences.Add("*****");
            _preferences.Sort();
            _preferences2 = _preferences.ToList();
            _preferences3 = _preferences.ToList();

            categories.Add("*****");
            categories.Sort();

            this.comboBox1.DataSource = _preferences;
            this.comboBox2.DataSource = _preferences2;
            this.comboBox3.DataSource = _preferences3;
            this.cmbCat.DataSource = categories;
            this.SCVGrid.DataSource = _products;

        }

        private List<ProductSCV> GetData()
        {
            var outPutDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var excelPath = Path.Combine(outPutDirectory, "ProductSCV.xlsx");
            string excel_Path = new Uri(excelPath).LocalPath;
            // string excelPath = @"C:\Users\timki\Documents\Pondrop\Code\Data\ProductSCV.xlsx";
            List<ProductSCV> prodList = new List<ProductSCV>();
            FileStream stream = File.Open(excel_Path, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();

            while (excelReader.Read())
            {
                if (excelReader.GetString(0) != "Product")
                {
                    prodList.Add(new ProductSCV
                    {
                        Product = excelReader.GetString(0),
                        Category = excelReader.GetString(1),
                        Rank = excelReader.GetDouble(2),
                        Price = excelReader.GetDouble(3),
                        Units = excelReader.GetDouble(4),
                        UnitPrice = excelReader.GetDouble(5),
                        TxOffer = excelReader.GetDouble(6),
                        TxAudOffer = excelReader.GetDouble(7),
                        ComparableQty = excelReader.GetDouble(8),
                        Soundness = excelReader.GetDouble(9),
                        AttributeString = excelReader.GetString(10),
                        ShopperTotalCount = excelReader.GetDouble(11),
                        CommunityTotalCount = excelReader.GetDouble(12)

                    });
                }              
            }

            excelReader.Close();
            excelReader.Dispose();

            foreach(var p in prodList)
            {
                if (p.AttributeString != "" && p.AttributeString != null)
                {
                    p.Attributes = p.AttributeString.Split(',');
                    
                    foreach (var pr in p.Attributes)
                    {
                        _preferences.Add(pr);
                    }
                }
                
            }

            return prodList;
        }

        private List<ProductSCV> CalculateSCV (List<ProductSCV> prods, ProductSCV selectedProd)
        {
            foreach (var p in prods)
            {
                p.ListPriceChange = selectedProd.Price - p.Price;
                p.ExtraProductValue = (p.Units - selectedProd.Units) * p.UnitPrice;
                p.NetValueTxAUD = p.TxAudOffer - selectedProd.TxAudOffer;

                p.SCV = p.ListPriceChange + p.ExtraProductValue + p.NetValueTxAUD;

            }

            return prods;
        }

        private List<ProductSCV> CalculateFullSCV(List<ProductSCV> prods, ProductSCV selectedProd)
        {
            var maxSCV = prods.Select(x => x.SCV).Max();
            var minSCV = prods.Select(x => x.SCV).Min();
            // .Where(x => x.Product != selectedProd.Product)

            double scvDifference = maxSCV - minSCV;

            List<SelectedPreference> selectedPref = new List<SelectedPreference>();
            if (comboBox1.SelectedValue.ToString() != "*****")
            {
                selectedPref.Add(new SelectedPreference
                {
                    Preference = comboBox1.SelectedValue.ToString(),
                    Weighting = (double)num1.Value,
                    ShopperPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox1.SelectedValue.ToString())).Sum(x => x.ShopperTotalCount),
                    CommPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox1.SelectedValue.ToString())).Sum(x => x.CommunityTotalCount)
                });
            }
            if (comboBox2.SelectedValue.ToString() != "*****")
            {
                selectedPref.Add(new SelectedPreference
                {
                    Preference = comboBox2.SelectedValue.ToString(),
                    Weighting = (double)num2.Value,
                    ShopperPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox2.SelectedValue.ToString())).Sum(x => x.ShopperTotalCount),
                    CommPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox2.SelectedValue.ToString())).Sum(x => x.CommunityTotalCount)
                });
            }
            if (comboBox3.SelectedValue.ToString() != "*****")
            {
                selectedPref.Add(new SelectedPreference
                {
                    Preference = comboBox3.SelectedValue.ToString(),
                    Weighting = (double)num3.Value,
                    ShopperPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox3.SelectedValue.ToString())).Sum(x => x.ShopperTotalCount),
                    CommPurch = prods.Where(x => x.Attributes != null && x.Attributes.Contains(comboBox3.SelectedValue.ToString())).Sum(x => x.CommunityTotalCount)
                });
            }

            double sliderPref, sliderVal;

            switch (this.trackBar1.Value)
            {
                case 1:
                    sliderPref = 1;
                    sliderVal = 0;
                    break;
                case 2:
                    sliderPref = 1;
                    sliderVal = 0.5;
                    break;
                case 3:
                    sliderPref = 1;
                    sliderVal = 1;
                    break;
                case 4:
                    sliderPref = 0.5;
                    sliderVal = 1;
                    break;
                case 5:
                    sliderPref = 0;
                    sliderVal = 1;
                    break;
                default:
                    sliderPref = 1;
                    sliderVal = 1;
                    break;
            }

            double totalShopper;
            double totalCommunity;

            totalShopper = prods.Sum(x => x.ShopperTotalCount);
            totalCommunity = prods.Sum(x => x.CommunityTotalCount);

            // Populate labels
            label24.Text = totalShopper.ToString();
            label25.Text = totalCommunity.ToString();

            if (selectedPref.Count > 0)
            {
                int index = 1;
                foreach(var sp in selectedPref)
                {
                    if (index == 1)
                    {
                        label8.Text = sp.Preference;
                        label16.Text = sp.ShopperPurch.ToString();
                        label17.Text = sp.CommPurch.ToString();
                    }
                    else if (index == 2)
                    {
                        label9.Text = sp.Preference;
                        label18.Text = sp.ShopperPurch.ToString();
                        label19.Text = sp.CommPurch.ToString();
                    }
                    else
                    {
                        label12.Text = sp.Preference;
                        label20.Text = sp.ShopperPurch.ToString();
                        label21.Text = sp.CommPurch.ToString();
                    }

                    index += 1;
                }
            }

            foreach (var p in prods)    // .Where(x => x.Product != selectedProd.Product).ToList()
            {
                double totalProdPrefWeight = 0;
                double totalProdValueWeight = 0;

                
                if (selectedPref.Count != 0 && p.Attributes != null)
                {
                    int countPrefs = selectedPref.Count();
                    // Loop through preferences
                    foreach (var x in selectedPref)
                    {
                        // Skip if no match
                        var match = p.Attributes.Contains(x.Preference);

                        if (!match)
                        {
                            p.Filter = true;
                            continue;  
                        }

                        // Flag product to be unfiltered
                        p.Filter = false;

                        // if matched calculate and add to total
                        // preference weightings
                    
                        // shopper and community weightings
                        int prefPct = 100;
                        int shopPct = 0;
                        int commPct = 0;

                        if (checkBox1.Checked)
                        {
                            shopPct = (int)numericUpDown1.Value;
                            prefPct -= shopPct;
                        }

                        if (checkBox2.Checked)
                        {
                            commPct = (int)numericUpDown2.Value;
                            prefPct -= commPct;
                        }

                        double selectedShopperPreferenceWeighting = ((x.Weighting / 100) * (((double)prefPct / (double)countPrefs) / 100));

                        var shopPopularity = (x.ShopperPurch / totalShopper) * (((double)shopPct / (double)countPrefs) / 100);
                        var commPopularity = (x.CommPurch / totalCommunity) * (((double)commPct / (double)countPrefs) / 100); 

                        var totalPreferenceWeighting = selectedShopperPreferenceWeighting + shopPopularity + commPopularity;

                        totalProdPrefWeight += totalPreferenceWeighting;

                    }
                }
                else if (selectedPref.Count != 0)
                {
                    p.Filter = true;
                }
                else
                {
                    p.Filter = false;
                }


                // Value weighting
                //totalProdValueWeight = p.SCV - (minSCV / scvDifference);
                totalProdValueWeight = (p.SCV - minSCV) / scvDifference;

                // calculate net
                p.NetMatchComparison = (sliderPref * totalProdPrefWeight) + (sliderVal * totalProdValueWeight);

            }

            // get netSCV for selected prod
            var selNMC = prods.Where(x => x.Product == selectedProd.Product).Select(x => x.NetMatchComparison).FirstOrDefault();

            // take away selected prod netSCV from all others
            foreach (var p in prods)
            {
                p.NetMatchComparison -= selNMC;
            }

            prods = prods.Where(x => x.Filter == false).ToList();

            return prods;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _products = GetData();
            _products = _products.Where(x => x.Category == cmbCat.SelectedValue.ToString()).ToList();

            ProductSCV selectedProd = new ProductSCV();

            if (label11.Text != "Select")
            {
                //DataGridViewRow row = this.SCVGrid.SelectedRows[0];
                //string product = row.Cells["Product"].Value.ToString();

                selectedProd = _products.Where(x => x.Product == label11.Text).FirstOrDefault();

                // Calculate latest SCV
                _products = CalculateSCV(_products, selectedProd);

                // Calculate using filters and preferences
                _products = CalculateFullSCV(_products, selectedProd);

                _products = _products.OrderByDescending(x => x.NetMatchComparison).ToList();

                int rank = 1;

                foreach (var r in _products)
                {
                    r.Rank = rank;
                    rank += 1;
                }

                this.SCVGrid.DataSource = _products;               

                this.SCVGrid.Refresh();

            }
            else
            {
                MessageBox.Show("Please select a product to compare.");
            };

            

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _preferences = new List<string>();
            _products = GetData();
            List<string> categories = _products.Select(x => x.Category).Distinct().ToList();
            _preferences = _preferences.Distinct().ToList();
            _preferences.Add("*****");
            _preferences.Sort();
            _preferences2 = _preferences.ToList();
            _preferences3 = _preferences.ToList();

            categories.Add("*****");
            categories.Sort();

            this.comboBox1.DataSource = _preferences;
            this.comboBox2.DataSource = _preferences2;
            this.comboBox3.DataSource = _preferences3;
            this.cmbCat.DataSource = categories;
            this.SCVGrid.DataSource = _products;

            this.checkBox1.Checked = true;
            this.checkBox2.Checked = true;

            this.num1.Value = 100;
            this.num2.Value = 100;
            this.num3.Value = 100;
            this.numericUpDown1.Value = 5;
            this.numericUpDown2.Value = 5;

            this.trackBar1.Value = 3;

            this.label11.Text = "Select";

            label8.Text = "";
            label16.Text = "";
            label17.Text = "";
            label9.Text = "";
            label18.Text = "";
            label19.Text = "";
            label12.Text = "";
            label20.Text = "";
            label21.Text = "";
            label24.Text = "";
            label25.Text = "";

        }

        private void SCVGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            DataGridViewRow row = this.SCVGrid.CurrentRow;
            string product = row.Cells["Product"].Value.ToString();
            label11.Text = product;
            
        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            _preferences = new List<string>();
            _products = GetData();
            _products = _products.Where(x => x.Category == cmbCat.SelectedValue.ToString()).ToList();

            foreach (var p in _products)
            {
                if (p.AttributeString != "" && p.AttributeString != null)
                {
                    p.Attributes = p.AttributeString.Split(',');

                    foreach (var pr in p.Attributes)
                    {
                        _preferences.Add(pr);
                    }
                }

            }

            _preferences = _preferences.Distinct().ToList();
            _preferences.Add("*****");
            _preferences.Sort();
            _preferences2 = _preferences.ToList();
            _preferences3 = _preferences.ToList();

            this.comboBox1.DataSource = _preferences;
            this.comboBox2.DataSource = _preferences2;
            this.comboBox3.DataSource = _preferences3;
            this.SCVGrid.DataSource = _products;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
