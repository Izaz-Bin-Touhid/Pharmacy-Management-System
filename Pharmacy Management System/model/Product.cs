using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Product
    {
        private int productId;
        private string name;
        private string category;
        private float price;
        private int discount;
        private int stockQuantity;
        private string expiryDate;
        private int customerId;
        private int adminId;

        public Product() { 
        }

        public Product(int productId, string name, string category, float price, int discount, int stockQuantity, string expiryDate, int customerId, int adminId)
        {
            this.ProductId = productId;
            this.Name = name;
            this.Category = category;
            this.Price = price;
            this.Discount = discount;
            this.StockQuantity = stockQuantity;
            this.ExpiryDate = expiryDate;
            this.CustomerId = customerId;
            this.AdminId = adminId;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public float Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public int StockQuantity { get => stockQuantity; set => stockQuantity = value; }
        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public int AdminId { get => adminId; set => adminId = value; }
    }
}
