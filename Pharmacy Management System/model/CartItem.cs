using System;

namespace Pharmacy_Management_System.model
{
    public class CartItem
    {
        private string cartSerial;
        private string productName;
        private float priceAfterDiscount;
        private int quantity;
        private float total;

        public CartItem()
        {
        }

        public CartItem(string cartSerial, string productName, float priceAfterDiscount, int quantity)
        {
            this.CartSerial = cartSerial;
            this.ProductName = productName;
            this.PriceAfterDiscount = priceAfterDiscount;
            this.Quantity = quantity;
            this.Total = priceAfterDiscount * quantity;
        }

        public string CartSerial { get => cartSerial; set => cartSerial = value; }
        public string ProductName { get => productName; set => productName = value; }
        public float PriceAfterDiscount { get => priceAfterDiscount; set => priceAfterDiscount = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public float Total { get => total; set => total = value; }
    }
}
