using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pharmacy_Management_System.model;

namespace Pharmacy_Management_System.controller
{
    public class ProductController
    {
        public void AddProduct(Product p)
        {
            Products ps = new Products();
            ps.AddProduct(p);
        }

        public void UpdateProduct (Product p)
        {
            Products ps = new Products();
            ps.UpdateProduct(p);
        }

        public void DeleteProduct(string productName)
        {
            Products ps = new Products();
            ps.DeleteProduct(productName);
        }

        public Product SearchProductByName(string productName)
        {
            Products ps = new Products();
            Product p = ps.SearchProductByName(productName);
            return p;
        }

        public List<Product> GetAllProducts()
        {
            Products ps = new Products();
            List<Product> productList = ps.GetProducts();
            return productList;
        }


    }
}
