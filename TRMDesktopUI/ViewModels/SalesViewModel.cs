using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private IProductEndpoint productEndpoint;
        private BindingList<CartItemModel> cart = new BindingList<CartItemModel>();
        private BindingList<ProductModel> products;
        private ProductModel selectedProduct;
        private int itemQuantity;

        public SalesViewModel(IProductEndpoint _productEndpoint)
        {
            productEndpoint = _productEndpoint;
        }

        // The ctor cannot be an async method, but we can override the OnViewLoaded which we inherit from screen and make it async
        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        public async Task LoadProducts()
        {
            var productList = await productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }

        public BindingList<ProductModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }

        public BindingList<CartItemModel> Cart
        {
            get { return cart; }
            set
            {
                cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }

        // We enter a string into the ItemQuantity TextBox
        // Caliburn micro checks if the input is a number and validates it
        public int ItemQuantity
        {
            get { return itemQuantity; }
            set
            {
                itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
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
                if (ItemQuantity > 0 && SelectedProduct?.QuantityInStock >= ItemQuantity)
                {
                    output = true;
                }

                return output;
            }
        }

        public void AddToCart()
        {
            CartItemModel item = new CartItemModel()
            {
                Product = SelectedProduct,
                QuantityInCart = ItemQuantity
            };

            Cart.Add(item);
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
