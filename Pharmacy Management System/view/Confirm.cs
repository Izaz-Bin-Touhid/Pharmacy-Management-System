using Pharmacy_Management_System.controller;
using Pharmacy_Management_System.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pharmacy_Management_System.view
{
    public partial class Confirm : Form
    {
        private double totalAmount;
        private List<CartItem> cartItems;

        public Confirm(List<CartItem> items, double amount)
        {
            InitializeComponent();
            cartItems = items;
            totalAmount = amount;
        }

        // Method to display the total amount in the form
        private void DisplayTotalAmount()
        {
            totalAmountLabel.Text = $"Total Amount: {totalAmount:C2}";  // Format as currency (C2)
        }

        // Handle the 'Confirm Order' button click event
        private void ConfirmOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Call CartController to update stock and confirm the order
                CartController cartController = new CartController();
                cartController.ConfirmOrder(cartItems);

                // Show confirmation message
                MessageBox.Show("Order confirmed successfully!");

                // Close the form after confirmation
                this.Close();
            }
            catch (Exception ex)
            {
                // Show error if something went wrong
                MessageBox.Show($"Error confirming the order: {ex.Message}");
            }
        }

        // Load the form and display the total amount
        private void Confirm_Load(object sender, EventArgs e)
        {
            DisplayTotalAmount();  // Display the total amount when the form loads
        }

        private void totalAmountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

