using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Pharmacy_Management_System.controller
{
    public class CartController
    {
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
    }
}

