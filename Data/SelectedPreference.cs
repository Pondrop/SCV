using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCV.Data
{
    public class SelectedPreference
    {
        public string Preference { get; set; }
        public double Weighting { get; set; }
        public double ShopperPurch { get; set; }
        public double CommPurch { get; set; }
    }
}
