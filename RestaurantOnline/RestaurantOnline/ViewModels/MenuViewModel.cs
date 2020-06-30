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
    public class MenuViewModel:BaseViewModel
    {
        private ObservableCollection<MenuModel> _products;

        public ObservableCollection<MenuModel> Products
        {
            get { return _products; }
            set
            {
                if (value != null)
                {
                    _products = value;
                    OnPropertyChanged("Products");
                }

            }
        }

        private ICommand _addProductCommand;

        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                    _addProductCommand = new RelayCommand(AddProduct);
                return _addProductCommand;
            }
        }

        public void AddProduct(object sender)
        {
            var productName = (sender as string);
            var exist = false;

            foreach (var product in Products)
            {
                if (!product.Nume.Equals(productName)) continue;
                foreach (var productCart in CurrentSession.cart.Where(productCart => productCart.NumeProdus.Equals(productName)))
                {
                    productCart.CantitateProdus += 1;
                    exist = true;
                    break;
                }
                if (exist == false)
                {
                    CurrentSession.cart.Add(new CartModel(product.Id, product.Nume, product.PretMeniu, true));
                }
                break;
            }
        }

        public MenuViewModel()
        {
            Products = new ObservableCollection<MenuModel>(ProductServices.GetMenus());
        }

    }
}
