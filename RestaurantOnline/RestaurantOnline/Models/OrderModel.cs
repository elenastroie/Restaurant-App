using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.ViewModels;

namespace RestaurantOnline.Models
{
    public class OrderModel:BaseViewModel
    {
        private int _id;
        private int _idUtilizator;
        private string _stare;
        private DateTime _dataPlasare;
        private double _discount;
        private double _costTransport;
        private double _pretTotal;

        public List<string> ProduseSiCantitati { get; set; }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int IdUtilizator
        {
            get
            {
                return _idUtilizator;
            }
            set
            {
                _idUtilizator = value;
            }
        }
        public string Stare
        {
            get { return _stare; }
            set { _stare = value; }
        }
        public DateTime DataPlasare
        {
            get { return _dataPlasare; }
            set { _dataPlasare = value; }
        }
        public double Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }
        public double CostTransport
        {
            get { return _costTransport; }
            set { _costTransport = value; }
        }
        public double PretTotal
        {
            get { return _pretTotal; }
            set { _pretTotal = value; }
        }

        public OrderModel(DateTime timpInregistrare, double pretTotal, List<string> produse)
        {
            DataPlasare = timpInregistrare;
            PretTotal = pretTotal;
            ProduseSiCantitati = produse;
        }

        public OrderModel()
        {

        }
    }
}

