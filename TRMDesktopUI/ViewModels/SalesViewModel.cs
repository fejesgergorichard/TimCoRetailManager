﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> cart;
        private BindingList<string> products;
        private int itemQuantity;

        public BindingList<string> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public BindingList<string> Cart
        {
            get { return cart; }
            set
            {
                cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        // We enter a string into the ItemQuantity TextBox
        // Caliburn micro checks if the input is a number
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public string SubTotal
        {
            get
            {
                // TODO - replace with calculation
                return "$0.00";
            }
        }
        public string Tax
        {
            get
            {
                // TODO - replace with calculation
                return "$0.00";
            }
        }
        public string Total
        {
            get
            {
                // TODO - replace with calculation
                return "$0.00";
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                // Make sure something is selected in the Products listbox
                // Make sure item quantity is filled

                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                // Make sure something is selected in the Cart

                return output;
            }
        }

        public void RemoveFromCart()
        {

        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                // Make sure something is in the Cart

                return output;
            }
        }

        public void CheckOut()
        {

        }

    }
}
