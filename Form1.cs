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

            // Get data from spreadsheet
            _products = GetData();

            // Categories and preferences for dropdowns
            List<string> categories = _products.Select(x => x.Category).Distinct().ToList();
            _preferences = _preferences.Distinct().ToList();
            _preferences.Add("*****");
            _preferences.Sort();
            _preferences2 = _preferences.ToList();
            _preferences3 = _preferences.ToList();

            categories.Add("*****");
            categories.Sort();

            // bind data to relevant form controls
            this.comboBox1.DataSource = _preferences;
            this.comboBox2.DataSource = _preferences2;
            this.comboBox3.DataSource = _preferences3;
            this.cmbCat.DataSource = categories;
            this.SCVGrid.DataSource = _products;

        }

        private List<ProductSCV> GetData()
        {
            // Set file path of data file to be the release folder
            var outPutDirectory = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var excelPath = Path.Combine(outPutDirectory, "ProductSCV.xlsx");
            string excel_Path = new Uri(excelPath).LocalPath;
            // Create empty list of products
            List<ProductSCV> prodList = new List<ProductSCV>();
            FileStream stream = File.Open(excel_Path, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();

            // populate list of products
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

            // Split comma delimited attributes and add them to a list
            foreach (var p in prodList)
            {
                if (p.AttributeString != "" && p.AttributeString != null)
                {
                    p.Attributes = p.AttributeString.Split(',');

                    foreach (var pr in p.Attributes)
                    {
                        if (pr != "" && pr != null)
                        {
                            char first = pr[0];

                            if (Char.IsLetterOrDigit(first))
                            {
                                _preferences.Add(pr);
                            }

                        }
                    }
                }

            }

            return prodList;
        }

        private List<ProductSCV> CalculateSCV (List<ProductSCV> prods, ProductSCV selectedProd)
        {

            // PROCESS FLOW - Suggested Comparable Value (SCV)
            foreach (var p in prods)
            {
                // Get the difference in list price
                p.ListPriceChange = selectedProd.Price - p.Price;
                // Calculate any extra product value using unit difference and unit price
                p.ExtraProductValue = (p.Units - selectedProd.Units) * p.UnitPrice;
                // Tanx offer difference
                p.NetValueTxAUD = p.TxAudOffer - selectedProd.TxAudOffer;

                // Combine to create product SCV
                p.SCV = p.ListPriceChange + p.ExtraProductValue + p.NetValueTxAUD;

            }

            return prods;
        }

        private List<ProductSCV> CalculateFullSCV(List<ProductSCV> prods, ProductSCV selectedProd)
        {
            // PROCESS FLOW - SCV Difference
            // Get the max and min SCV values from the list of products and calculate the difference
            var maxSCV = prods.Select(x => x.SCV).Max();
            var minSCV = prods.Select(x => x.SCV).Min();

            double scvDifference = maxSCV - minSCV;

            // PROCESS FLOW - Selected Shopper Preference Weighting (SSPW)
            // Populate the list of selected preferences and their related values (Preference name, weighting, Shopper total and community total)
            List<SelectedPreference> selectedPref = new List<SelectedPreference>();
            if (comboBox1.SelectedValue.ToString() != "*****")
            {
                selectedPref.Add(new SelectedPreference
                {
                    Preference = comboBox1.SelectedValue.ToString(),
                    Weighting = (double)num1.Value,
                    // Get total shopper and community purchases for this preference across all products in the category
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


            // set the preference and value weightings based on the slider position
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

            // Get the total shopper and community purchases across all products in the category
            double totalShopper;
            double totalCommunity;

            totalShopper = prods.Sum(x => x.ShopperTotalCount);
            totalCommunity = prods.Sum(x => x.CommunityTotalCount);

            // Populate labels for reference
            label24.Text = totalShopper.ToString();
            label25.Text = totalCommunity.ToString();

            // Check if any preferences are selected, skip if not.
            if (selectedPref.Count > 0)
            {
                // Populate individual preference values for reference (if selected)
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

            // PROCESS FLOW - For Each <Product>
            // Loop through each product and calculate the NetMatchComparison
            foreach (var p in prods)    
            {
                // variables for final product preference and value weightings
                double totalProdPrefWeight = 0;
                double totalProdValueWeight = 0;

                // If there is only a single preference selected and it has a weighting of zero (exclude), skip to next product
                if (selectedPref.Count == 1)
                {
                    if (selectedPref.FirstOrDefault().Weighting == 0)
                    {
                        p.Filter = false;
                        continue;
                    }
                }

                // PROCESS FLOW - Total Selected Preference Weighting
                // Check for selected preferences. If yes and the product has attributes then calculate preference weight. If not, skip.
                if (selectedPref.Count != 0 && p.Attributes != null)
                {
                    // Get count of selected preferences for use in calculations
                    int countPrefs = selectedPref.Count();
                    // Copy the count to a new variable which will be used to filter relevant products
                    int index = countPrefs;
                    // result from checking if the preference matches a product attribute 
                    bool noMatch = true;
                    // Loop through preferences
                    foreach (var x in selectedPref)
                    {
                        // Skip if no match
                        var match = p.Attributes.Contains(x.Preference);

                        if (!match)
                        {
                            // Set the product to be filtered if there is no match for any of the preferences
                            if (index == 1 && noMatch)
                            {
                                p.Filter = true;
                            }
                            index -= 1;
                            continue;  
                        }

                        // skip to next product when weighting is zero
                        if (x.Weighting == 0)
                        {
                            p.Filter = false;
                            continue;
                        }


                        // Flag product to be unfiltered
                        p.Filter = false;
                        noMatch = false;

                    
                        // preference, shopper and community weightings
                        int prefPct = 100;
                        int shopPct = 0;
                        int commPct = 0;

                        // If shopper and community boxes are checked, set weighting pct and subrtact from overall preference weighting
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

                        // PROCESS FLOW - Selected Shopper Preference Weighting
                        double selectedShopperPreferenceWeighting = ((x.Weighting / 100) * (((double)prefPct / (double)countPrefs) / 100));


                        // default shopper and community popularity to zero
                        double shopPopularity = 0;
                        double commPopularity = 0;

                        // PROCESS FLOW - Shopper Popularity Weighting
                        // Only calculate if total > 0 and shopper is selected
                        if (totalShopper > 0 && checkBox1.Checked)
                        {
                            shopPopularity = (x.ShopperPurch / totalShopper) * (((double)shopPct / (double)countPrefs) / 100);
                        }

                        // PROCESS FLOW - Community Popularity Weighting
                        // Only calculate if total > 0 and community is selected
                        if (totalCommunity > 0 && checkBox2.Checked)
                        {
                            commPopularity = (x.CommPurch / totalCommunity) * (((double)commPct / (double)countPrefs) / 100);
                        }
                        
                        // PROCESS FLOW - Total Selected Product Preference Weighting
                        // Add the calculated preference weightings together
                        var totalPreferenceWeighting = selectedShopperPreferenceWeighting + shopPopularity + commPopularity;

                        // Add preference weighting to total product preference weighting
                        totalProdPrefWeight += totalPreferenceWeighting;

                        index -= 1;
                    }
                }
                // Auto filter products with no attributes if a preference is selected
                else if (selectedPref.Count != 0)
                {
                    p.Filter = true;
                }
                else
                // Allow all products
                {
                    p.Filter = false;
                }

                // PROCESS FLOW - Total Product Value Rating
                // Value weighting - skip if the scvDifference is zero to avoid divide by zero
                if (scvDifference > 0)
                {
                    totalProdValueWeight = (p.SCV - minSCV) / scvDifference;
                }
                
                // Update product fields with totals
                p.TotalProdPrefWeight = totalProdPrefWeight;
                p.TotalProdValueWeight = totalProdValueWeight;

                // PROCESS FLOW - Product Net Match Result Ranking
                // multiply totals by the relevant slider weightings
                p.NetMatchComparison = (sliderPref * totalProdPrefWeight) + (sliderVal * totalProdValueWeight);

                // make sure selected product is always displayed
                if (p.Product == selectedProd.Product)
                {
                    p.Filter = false;
                }


            }

            // get netMatchComparison for selected prod
            var selNMC = prods.Where(x => x.Product == selectedProd.Product).Select(x => x.NetMatchComparison).FirstOrDefault();

            
            // take away selected prod netSCV from all others to get the final ratings
            foreach (var p in prods)
            {
                p.NetMatchComparison -= selNMC;
            }
           

            // remove any products which have a preference weighting of zero
            foreach (var pr in prods)
            {
                if (selectedPref.Count != 0 && pr.Attributes != null)
                {
                    // Loop through preferences
                    foreach (var x in selectedPref)
                    {
                        // Skip if no match
                        var match = pr.Attributes.Contains(x.Preference);

                        if (!match)
                        {                          
                            continue;
                        }

                        // flag to exclude when weighting is zero or already filtered
                        if (x.Weighting == 0 || pr.Filter)
                        {
                            pr.Filter = true;
                            continue;
                        }
                        
                    }
                }
            }

            // Filter the list if required
            prods = prods.Where(x => x.Filter == false).ToList();

            return prods;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // PROCESS FLOW - Calculate
            _products = GetData();
            _products = _products.Where(x => x.Category == cmbCat.SelectedValue.ToString()).ToList();

            ProductSCV selectedProd = new ProductSCV();

            if (label11.Text != "Select")
            {
                selectedProd = _products.Where(x => x.Product == label11.Text).FirstOrDefault();

                // Calculate latest SCV
                _products = CalculateSCV(_products, selectedProd);

                // Calculate using filters and preferences
                _products = CalculateFullSCV(_products, selectedProd);

                // PROCESS FLOW - Sort Product Net Match Result Ranking
                // Ranking the products by netMatchComparison. Then by product shopper total (if shopper [checkBox1] is selected) and then by product community total (if community [checkBox2] is selected)
                if (checkBox1.Checked && checkBox2.Checked)
                {
                    _products = _products.OrderByDescending(x => x.NetMatchComparison).ThenByDescending(x => x.ShopperTotalCount).ThenByDescending(x => x.CommunityTotalCount).ThenByDescending(x => x.Soundness).ToList();
                }
                else if (checkBox1.Checked && !checkBox2.Checked) 
                {
                    _products = _products.OrderByDescending(x => x.NetMatchComparison).ThenByDescending(x => x.ShopperTotalCount).ThenByDescending(x => x.Soundness).ToList();
                }
                else if (!checkBox1.Checked && checkBox2.Checked)
                {
                    _products = _products.OrderByDescending(x => x.NetMatchComparison).ThenByDescending(x => x.CommunityTotalCount).ThenByDescending(x => x.Soundness).ToList();
                }
                else
                {
                    _products = _products.OrderByDescending(x => x.NetMatchComparison).ThenByDescending(x => x.Soundness).ToList();
                }

                // Update Rank column in product list
                int rank = 1;

                foreach (var r in _products)
                {
                    r.Rank = rank;
                    rank += 1;
                }

                // bind product list to the datagrid
                this.SCVGrid.DataSource = _products;

                // Redraw grid with new data
                this.SCVGrid.Refresh();

            }
            else
            {
                MessageBox.Show("Please select a product to compare.");
            };

            

        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reset all controls on the form and reload data from the spreadsheet
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
            // Populate label when a product is selected
            DataGridViewRow row = this.SCVGrid.CurrentRow;
            string product = row.Cells["Product"].Value.ToString();
            label11.Text = product;
            
        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve new product list when a new category is selected
            _products = GetData();
            _products = _products.Where(x => x.Category == cmbCat.SelectedValue.ToString()).ToList();

            _preferences = new List<string>();
            foreach (var p in _products)
            {
                if (p.AttributeString != "" && p.AttributeString != null)
                {
                    p.Attributes = p.AttributeString.Split(',');

                    foreach (var pr in p.Attributes)
                    {
                        if (pr != "" && pr != null)
                        {
                            char first = pr[0];

                            if (Char.IsLetterOrDigit(first))
                            {
                                _preferences.Add(pr);
                            }

                        }
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

        
    }
}
