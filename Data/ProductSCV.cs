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
        public double Rank { get; set; }
        public double Price { get; set; }
        public double Units { get; set; }
        public double UnitPrice { get; set; }
        public double TxOffer { get; set; }
        public double TxAudOffer { get; set; }
        public double ComparableQty { get; set; }
        public double ListPriceChange { get; set; }
        public double ExtraProductValue { get; set; }
        public double NetValueTxAUD { get; set; }
        public double Soundness { get; set; }
        public double SCV { get; set; }
        public double TotalProdPrefWeight { get; set; }
        public double TotalProdValueWeight { get; set; }
        public double NetMatchComparison { get; set; }
        public double ShopperTotalCount { get; set; }
        public double CommunityTotalCount { get; set; }
        public string AttributeString { get; set; }
        public string[] Attributes { get; set; }
        public bool Filter { get; set; } = true;
        public bool Excluded { get; set; } = false;

    }
}
