using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pharmacy_Management_System.controller
{
    public class CartController
    {
        // Add cart item to the cart
        public void AddCartItem(CartItem item)
        {
            try
            {
                Cart cart = new Cart(); // ✔ Correct class that handles database logic
                cart.AddToCart(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the item to cart: {ex.Message}");
            }
        }

        // Delete cart item by cartSerial
        public void DeleteCartItem(string cartSerial)
        {
            try
            {
                Cart cart = new Cart();
                cart.DeleteCartItem(cartSerial);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the cart item: {ex.Message}");
            }
        }

        // Get all cart items
        public List<CartItem> GetAllCartItems()
        {
            try
            {
                Cart cart = new Cart();
                return cart.GetAllCartItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving cart items: {ex.Message}");
                return new List<CartItem>();
            }
        }

        // Search cart item by cartSerial
        public CartItem SearchCartItem(string cartSerial)
        {
            try
            {
                Cart cart = new Cart();
                return cart.SearchCartItem(cartSerial);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the cart item: {ex.Message}");
                return null;
            }
        }

        // Method to confirm order and update stock quantities in the Product table
        public void ConfirmOrder(List<CartItem> cartItems)
        {
            try
            {
                double totalAmount = 0;

                // Iterate through the cart items and calculate the total amount
                foreach (var item in cartItems)
                {
                    // Calculate total for the cart item
                    totalAmount += item.Total;

                    // Update the stock of the product by subtracting the quantity purchased
                    UpdateProductStock(item.ProductName, item.Quantity);
                }

                // Optionally, save the order (e.g., insert into an "Order" table)
                MessageBox.Show($"Order Confirmed! Total Amount: {totalAmount:C2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming order: {ex.Message}");
            }
        }

        // Method to update product stock quantity after the order is placed
        private void UpdateProductStock(string productName, int quantitySold)
        {
            try
            {
                SqlDbDataAccess dba = new SqlDbDataAccess();
                SqlCommand cmd = dba.GetQuery("UPDATE Product SET stockQuantity = stockQuantity - @quantitySold WHERE productName = @productName;");
                cmd.Parameters.AddWithValue("@quantitySold", quantitySold);
                cmd.Parameters.AddWithValue("@productName", productName);
                dba.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stock quantity for {productName}: {ex.Message}");
            }
        }
    }
}

