using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCV.Data
{
    public class ProductSCV
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public int Rank { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }
        public double UnitPrice { get; set; }
        public double TxOffer { get; set; }
        public bool Selected { get; set; }
        public int ComparableQty { get; set; }
        public double ListPriceChange { get; set; }
        public double ExtraProductValue { get; set; }
        public double NetValueTxAUD { get; set; }
        public double SCV { get; set; }

    }
}
