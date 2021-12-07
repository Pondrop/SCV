using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCV.Data
{
    public class ProductList
    {
        private List<ProductSCV> _products;
        public List<ProductSCV> Products 
        {
            get { return _products; }
            set { _products = value; }
        }

        public ProductList()
        {

        }
    }
}
