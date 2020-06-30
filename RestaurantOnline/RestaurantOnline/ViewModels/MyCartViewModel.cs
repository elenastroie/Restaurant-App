using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RestaurantOnline.Commands;
using RestaurantOnline.Models;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    public class MyCartViewModel : BaseViewModel
    {
        private static ObservableCollection<CartModel> _products;
        private double _subtotal;
        private string _subtotalProduse;
        private string _discount;
        private string _total;

        public ObservableCollection<CartModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged("Products");

            }
        }
        public double Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                OnPropertyChanged("Subtotal");
            }
        }
        public string SubtotalProduse
        {
            get { return _subtotalProduse; }
            set
            {
                _subtotalProduse = value;
                OnPropertyChanged("SubtotalProduse");
            }
        }
        public string Discount
        {
            get { return _discount; }
            set
            {
                _discount = value;
                OnPropertyChanged("Discount");
            }
        }
        public string Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }
       
        private ICommand _addOneProduct;
        private ICommand _deleteOneProduct;

        public ICommand AddOneProductCommand
        {
            get
            {
                if (_addOneProduct == null)
                    _addOneProduct = new RelayCommand(AddOneProduct);
                return _addOneProduct;
            }
        }
        public ICommand DeleteOneProductCommand
        {
            get
            {
                if (_deleteOneProduct == null)
                    _deleteOneProduct = new RelayCommand(DeleteOneProduct);
                return _deleteOneProduct;
            }
        }

        public void AddOneProduct(object sender)
        {
            string numeProdus = sender as string;

            for (int index = 0; index < Products.Count(); index++)
            {
                if (Products[index].NumeProdus.Equals(numeProdus))
                {
                    Products[index].CantitateProdus += 1;
                    Products[index].PretTotalProdus += Products[index].PretProdus;
                    break;
                }
            }

            GetCurrentCart();
        }
        public void DeleteOneProduct(object sender)
        {
            string numeProdus = sender as string;

            for (int index = 0; index < Products.Count(); index++)
            {
                if (Products[index].NumeProdus.Equals(numeProdus))
                {
                    if (Products[index].CantitateProdus > 1)
                    {
                        Products[index].CantitateProdus -= 1;
                        Products[index].PretTotalProdus -= Products[index].PretProdus;
                    }
                    else
                    {
                        CurrentSession.DeleteFromCart(Products[index].NumeProdus);
                    }


                    break;
                }
            }
            GetCurrentCart();
        }

        public MyCartViewModel()
        {
            Products = new ObservableCollection<CartModel>(CurrentSession.cart);
            SubtotalProduse = "Subtotal: 0 Lei";
            Discount = "Discount: 0 Lei";
            Total = "Total: ";
        }
        public double GetCurrentCart()
        {
            Products = new ObservableCollection<CartModel>(CurrentSession.cart);

            Subtotal = 0;
            Discount = "DISCOUNT: 0 LEI";
            Total = "";

            foreach (CartModel product in Products)
            {
                Subtotal += product.PretTotalProdus;
            }

            SubtotalProduse = "SUBTOTAL: ";
            SubtotalProduse += Subtotal.ToString();
            SubtotalProduse += " LEI";

            if (Subtotal > 100)
            {
                Discount = "DISCOUNT: ";
                ;
                Discount += $"{(Subtotal / 100 * 15):0.00}";
                Discount += " LEI";

                Total = "TOTAL: ";
                Total += (Subtotal - (Subtotal / 100 * 15)).ToString();
                Total += " LEI";
                return (Subtotal - (Subtotal / 100 * 15));
            }
            else
            {
                Total = "TOTAL: ";
                Total += Subtotal.ToString();
                Total += " LEI";
                return Subtotal;
            }
        }

        private ICommand _sendOrderCommand;
        public ICommand SendOrderCommand
        {
            get
            {
                if (_sendOrderCommand == null)
                    _sendOrderCommand = new RelayCommand(SendOrder);
                return _sendOrderCommand;
            }
        }

        public void SendOrder(object sender)
        {
            OrderServices.AddOrder(CurrentSession.cart,GetCurrentCart());
            MessageBox.Show("Comanda ta a fost trimisa!");
            ClearData();
        }

        public void ClearData()
        {
            CurrentSession.cart.Clear();
            Products.Clear();
            SubtotalProduse = "Subtotal: 0 Lei";
            Discount = "Discount: 0 Lei";
            Total = "Total: ";
        }
    }
}