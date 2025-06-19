using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Management_System.model
{
    public class Product
    {
       
        private string productName;
        private string category;
        private float price;
        private int discount;
        private float priceAfterDiscount;
        private int stockQuantity;
        private string expiryDate;
        private string adminName;

        public Product() { 
        }

        public Product(string productName, string category, float price, int discount,float priceAfterDiscount, int stockQuantity, string expiryDate, string adminName)
        {
            this.ProductName = productName;
            this.Category = category;
            this.Price = price;
            this.PriceAfterDiscount = priceAfterDiscount;
            this.Discount = discount;
            this.StockQuantity = stockQuantity;
            this.ExpiryDate = expiryDate;
            this.AdminName = adminName;
        }

        public string ProductName { get => productName; set => productName = value; }
        public string Category { get => category; set => category = value; }
        public float Price { get => price; set => price = value; }
        public int Discount { get => discount; set => discount = value; }
        public float PriceAfterDiscount { get => priceAfterDiscount; set => priceAfterDiscount = value; }
        public int StockQuantity { get => stockQuantity; set => stockQuantity = value; }
        public string ExpiryDate { get => expiryDate; set => expiryDate = value; }
        public string AdminName { get => adminName; set => adminName = value; }
    }
}
