using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RestaurantOnline.Commands;
using RestaurantOnline.Models;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    class ProductsViewModel : BaseViewModel
    {
        private List<ProductModel> _products;
        private ObservableCollection<ProductModel> _productsFiltered;
        private string _searchBarText;
        private List<string> _listaAlergeni;

        public List<ProductModel> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public ObservableCollection<ProductModel> ProductsFiltered
        {
            get { return _productsFiltered; }
            set
            {
                if (value != null)
                {
                    _productsFiltered = value;
                    OnPropertyChanged("ProductsFiltered");
                }
            }
        }
        public string SearchBarText
        {
            get { return _searchBarText; }
            set
            {
                if (value != null)
                {
                    _searchBarText = value;
                    OnPropertyChanged("SearchBarText");
                }

            }
        }
        public List<string> ListaAlergeni
        {
            get { return _listaAlergeni; ; }
            set
            {
                if (value != null)
                {
                    _listaAlergeni = value;
                    OnPropertyChanged("ListaAlergeni");
                }
            }
        }

        private ICommand _filterSearch;
        private ICommand _addProductCommand;

        public ICommand FilterSearch
        {
            get
            {
                if (_filterSearch == null)
                    _filterSearch = new RelayCommand(SearchChanged);
                return _filterSearch;
            }
        }
        public ICommand AddProductCommand
        {
            get
            {
                if (_addProductCommand == null)
                    _addProductCommand = new RelayCommand(AddProduct);
                return _addProductCommand;
            }
        }

        public void SearchChanged(object sender)
        {
            if (!string.IsNullOrEmpty(SearchBarText))
            {
                if (ListaAlergeni.Contains(SearchBarText))
                {
                    ProductsFiltered = new ObservableCollection<ProductModel>();
                    foreach (var product in Products.Where(product => !product.Alergeni.Contains(SearchBarText)))
                    {
                        ProductsFiltered.Add(product);
                    }

                }
                else
                {
                    ProductsFiltered = new ObservableCollection<ProductModel>();
                    foreach (var product in Products)
                    {
                        if (product.Nume.ToLower().Contains(SearchBarText.ToLower()) && !ProductsFiltered.Contains(product))
                        {
                            ProductsFiltered.Add(product);
                        }
                    }
                }
            }
        }
        public void AddProduct(object sender)
        {
            var productName = (sender as string);
            var exist = false;


            foreach (var product in Products.Where(product => product.Nume.Equals(productName)))
            {
                foreach (var productCart in CurrentSession.cart.Where(productCart => productCart.NumeProdus.Equals(productName)))
                {
                    productCart.CantitateProdus += 1;
                    productCart.PretTotalProdus = productCart.CantitateProdus * productCart.PretProdus;
                    exist = true;
                    break;
                }
                if (exist == false)
                {
                    CurrentSession.cart.Add(new CartModel(product.Id, product.Nume, product.Pret, false));
                }
                break;
            }
        }

        public ProductsViewModel()
        {
            Products = ProductServices.GetProducts();
            ListaAlergeni = new List<string>(ProductServices.GetAlergensName());
            ProductsFiltered = new ObservableCollection<ProductModel>(Products);
        }
    }
}
