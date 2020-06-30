using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Models;
using RestaurantOnline.Services;

namespace RestaurantOnline.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private ObservableCollection<OrderModel> _orders;
        private string _mesaj;

        public ObservableCollection<OrderModel> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }
        public string Mesaj
        {
            get { return _mesaj; }
            set { _mesaj = value; }
        }

        public OrderViewModel()
        {
            Orders = new ObservableCollection<OrderModel>(OrderServices.GetOrders());
            Mesaj = Orders == null ? "Nu exista comenzi" : "";
        }

        public void updateOrdersList()
        {
            CurrentSession.orders = new List<OrderModel>(OrderServices.GetOrders());
            Orders = new ObservableCollection<OrderModel>(CurrentSession.orders);
            OnPropertyChanged("Orders");
        }
    }
}
